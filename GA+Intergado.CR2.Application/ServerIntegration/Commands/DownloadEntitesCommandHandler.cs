using ErrorOr;
using GA_Intergado.CR2.App.Common.UnitOfWork;
using GA_Intergado.CR2.App.ServerIntegration.Commom;
using GA_Intergado.CR2.App.ServerIntegration.Services;
using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Persistence.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.App.ServerIntegration.Commands
{
    public class DownloadEtitiesCommandHandler : IRequestHandler<DownloadEtitiesCommand, string> 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntegrationService _integrationService;

        public DownloadEtitiesCommandHandler(IUnitOfWork unitOfWork, IIntegrationService integrationService)
        {
            _unitOfWork = unitOfWork;
            _integrationService = integrationService;
        }

        public async Task<string> Handle(DownloadEtitiesCommand request, CancellationToken cancellationToken)
        {
            //if (_unitOfWork == null)
            //{
            //    return Error.Validation("Componente de persistência não inicializado");
            //}
            //else if (_integrationService == null)
            //{
            //    return Error.Validation("Componente de comunicação para sincronismo não inicializado");
            //}
            //else
            //{
                int total = request.ItemEntities.Count;
                int idx = 1;
                MethodInfo syncMethod = this.GetType().GetTypeInfo().GetDeclaredMethod("Receive");
                try
                {
                    foreach (ItemEntityData t in request.ItemEntities)
                    {
                        string result = (string)syncMethod.MakeGenericMethod(t.EntityType).Invoke(
                            this,
                            new object[3] {
                            _unitOfWork,
                            _integrationService,
                            t
                            });
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //return Error.Failure("ServiceSincronismo", $"RecebeDados:{ ex.Message}");
                }
            //}

            return "";
        }

        string Receive<T>(
          IUnitOfWork unitOfWork,
          IIntegrationService integrationService,
          ItemEntityData entidade) where T : class
        {
            try
            {
                string listaRecebidos = integrationService.Download<T>(entidade);
                return listaRecebidos;

                //foreach (T registro in listaRecebidos)
                //{
                //    unitOfWork.InsertOrUpdate(registro.GetType(), registro);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
