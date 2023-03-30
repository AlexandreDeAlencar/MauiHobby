using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class CurralCR1VM
    {
        [JsonPropertyName("CODIGO")]
        public long id { get; set; }


        [JsonPropertyName("LINHA")]
        public string line { get; set; }


        [JsonPropertyName("NUMERO")]
        public int number { get; set; }

        
        [JsonPropertyName("NOME")]
        public string name { get; set; }


        [JsonPropertyName("ORDEMTRATO")]
        public int supply_order_sequence { get; set; }


        [JsonPropertyName("TAGINICIAL")]
        public string start_tag { get; set; }


        [JsonPropertyName("tagfinal")]
        public string end_tag { get; set; }
    }
}