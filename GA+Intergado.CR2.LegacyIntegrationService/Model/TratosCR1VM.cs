using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class TratosCR1VM
    {
        [JsonPropertyName("TRATO")]
        public int id { get; set; }


        [JsonPropertyName("HORARIO")]
        public DateTime time { get; set; }
    }
}
