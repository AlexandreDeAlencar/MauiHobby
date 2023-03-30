using AutoMapper;
using ErrorOr;
using GA_Intergado.CR2.App.Common.UnitOfWork;
using GA_Intergado.CR2.App.ServerIntegration.DTOs;
using GA_Intergado.CR2.App.ServerIntegration.Services;
using GA_Intergado.CR2.Domain.Common.Persistence.Base;
using MediatR;
using System.Collections.Generic;
using System.Reflection;

namespace GA_Intergado.CR2.App.ServerIntegration.Commands
{
    public class DownloadEtitiesCommandHandler : IRequestHandler<DownloadEtitiesCommand, ErrorOr<Created>> 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIntegrationService _integrationService;

        public DownloadEtitiesCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IIntegrationService integrationService)
        {
            _unitOfWork = unitOfWork;
            _integrationService = integrationService;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Created>> Handle(DownloadEtitiesCommand request, CancellationToken cancellationToken)
        {
            if (_unitOfWork == null)
            {
                return Error.Validation("Componente de persistência não inicializado");
            }
            else if (_integrationService == null)
            {
                return Error.Validation("Componente de comunicação para sincronismo não inicializado");
            }
            else
            {
                int total = request.ItemEntities.Count;
                int idx = 1;
                MethodInfo syncMethod = this.GetType().GetTypeInfo().GetDeclaredMethod("Receive");
                try
                {
                    foreach (ServerIntegrationItemDTO t in request.ItemEntities)
                    {
                        syncMethod.MakeGenericMethod(t.EntityTypeSource, t.EntityTypeDestination).Invoke(
                            this,
                            new object[3] {
                            _unitOfWork,
                            _integrationService,
                            t
                            });
                    }
                }
                catch (Exception ex)
                {
                    return Error.Failure("ServiceSincronismo", $"RecebeDados:{ex.Message}");
                }
            }

            return Result.Created;
        }

        void Receive<T, R>(
          IUnitOfWork unitOfWork,
          IIntegrationService integrationService,
          ServerIntegrationItemDTO entidade) 
            where T : class, new()
            where R : class, new()
        {
            try
            {
                List<T> sourceList = integrationService.Download<T>(entidade);

                foreach (T sourceobject in sourceList)
                {
                    R destObject = _mapper.Map<R>(sourceobject);    
                    unitOfWork
                        .CreateRepositoryDefault<R>()
                        .Add(destObject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
