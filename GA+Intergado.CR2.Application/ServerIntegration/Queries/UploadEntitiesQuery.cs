using ErrorOr;
using GA_Intergado.CR2.App.ServerIntegration.Commom;
using GA_Intergado.CR2.Domain.Common.Models;
using MediatR;

namespace GA_Intergado.CR2.App.ServerIntegration.Queries
{
    public record UploadEntitiesQuery(List<ItemEntityData> ItemEntities, List<Entity<ValueObject>> uploadList) : IRequest<ErrorOr<Created>>;

}
