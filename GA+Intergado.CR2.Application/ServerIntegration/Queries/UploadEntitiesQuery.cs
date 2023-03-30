using ErrorOr;
using GA_Intergado.CR2.App.ServerIntegration.DTOs;
using GA_Intergado.CR2.Domain.Common.Models;
using MediatR;

namespace GA_Intergado.CR2.App.ServerIntegration.Queries
{
    public record UploadEntitiesQuery(List<ServerIntegrationItemDTO> ItemEntities, List<Entity<ValueObject>> uploadList) : IRequest<ErrorOr<Created>>;

}
