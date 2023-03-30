using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class BalancaCR1VM
    {
        [JsonPropertyName("Codigo")]
        public int Code { get; set; }
        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public string Precisao { get; set; }
        public string CodigoProtocolo { get; set; }
    }
}
