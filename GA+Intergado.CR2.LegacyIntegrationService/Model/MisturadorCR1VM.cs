using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class MisturadorCR1VM
    {
        [JsonPropertyName("CODIGO")]
        public long id { get; set; }


        [JsonPropertyName("MODELO")]
        public string model { get; set; }


        [JsonPropertyName("FABRICANTE")]
        public string maker { get; set; }


        [JsonPropertyName("CAPACIDADEMAXIMA")]
        public decimal maximum_capacity { get; set; }


        [JsonPropertyName("NUMERO")]
        public string number { get; set; }


        [JsonPropertyName("CAPACIDADEMINIMA")]
        public int minimum_capacity { get; set; }
        //public DateTime DATAREGISTRO { get; set; }


        [JsonPropertyName("CODIGOBALANCA")]
        public long balance_id { get; set; }
    }
}
