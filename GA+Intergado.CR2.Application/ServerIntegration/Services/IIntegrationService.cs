using GA_Intergado.CR2.App.ServerIntegration.Commom;
using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.App.ServerIntegration.Services
{
    public interface IIntegrationService
    {
        string Download<T>(ItemEntityData itemEntity) where T : class;
        string Upload<T>(ItemEntityData itemEntity, List<T> uploadList) where T : class;
    }
}
