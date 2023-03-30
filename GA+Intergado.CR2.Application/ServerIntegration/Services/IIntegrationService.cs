using GA_Intergado.CR2.App.ServerIntegration.DTOs;
using GA_Intergado.CR2.Domain.Common.Models;

namespace GA_Intergado.CR2.App.ServerIntegration.Services
{
    public interface IIntegrationService
    {
        List<T> Download<T>(ServerIntegrationItemDTO itemEntity) where T : class;
        List<T> Upload<T>(ServerIntegrationItemDTO itemEntity, List<T> uploadList) where T : class;
    }
}
