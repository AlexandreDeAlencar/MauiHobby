using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class OrdemProducaoCR1VM
    {
        [JsonPropertyName("id")]
        public long id { get; set; }


        [JsonPropertyName("recipe_id")]
        public long recipe_id { get; set; }


        [JsonPropertyName("amount_kg")]
        public decimal amount { get; set; }

        
        [JsonPropertyName("date")]
        public DateTime Data { get; set; }


        [JsonPropertyName("Status")]
        public int status { get; set; }
    }
}
