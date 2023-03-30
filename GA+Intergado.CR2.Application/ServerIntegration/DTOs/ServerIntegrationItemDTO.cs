using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.App.ServerIntegration.DTOs
{
    public record ServerIntegrationItemDTO(Type EntityTypeSource, Type EntityTypeDestination, string Name, string Endpoint);

}
