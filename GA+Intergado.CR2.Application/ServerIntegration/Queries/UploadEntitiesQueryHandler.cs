using ErrorOr;
using GA_Intergado.CR2.App.Common.UnitOfWork;
using GA_Intergado.CR2.App.ServerIntegration.Commands;
using GA_Intergado.CR2.App.ServerIntegration.Services;
using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Common.Persistence.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.App.ServerIntegration.Queries
{
    public class UploadEntitiesQueryHandler : IRequestHandler<UploadEntitiesQuery, ErrorOr<Created>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntegrationService _integrationService;
        public UploadEntitiesQueryHandler(IUnitOfWork unitOfWork, IIntegrationService integrationService)
        {
            _unitOfWork = unitOfWork;
            _integrationService = integrationService;
        }
        public Task<ErrorOr<Created>> Handle(UploadEntitiesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
