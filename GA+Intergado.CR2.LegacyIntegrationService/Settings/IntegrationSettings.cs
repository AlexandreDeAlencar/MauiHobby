using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.IntegrationService.Settings
{
    public class IntegrationSettings
    {
        private const string SectionName = "IntegrationServiceHostAdress";
        public string HostAdress { get; set; } = String.Empty;
    }
}
