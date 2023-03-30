using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class IngredienteReceitaCR1VM
    {
        [JsonPropertyName("ID")]
        public long id { get; set; }


        [JsonPropertyName("CODIGORECEITA")]
        public long recipe_id { get; set; }


        [JsonPropertyName("CODIGOINGREDIENTE")]
        public long ingredient_id { get; set; }


        //[JsonPropertyName("PERCENTUALMATERIASECA")]
        //public decimal dry_matter_percent { get; set; }


        [JsonPropertyName("PERCENTUALMATERIANATURAL")]
        public decimal natural_matter_percent { get; set; }


        [JsonPropertyName("TOLERANCIA")]
        public decimal tolerance { get; set; }


        [JsonPropertyName("TIPOTOLERANCIA")]
        public string tolerance_type { get; set; } = "PORCENTAGEM";


        [JsonPropertyName("ORDEMBATIDA")]
        public int beat_order { get; set; }


        [JsonPropertyName("MISTURADOR")]
        public long mixer_id { get; set; }


        [JsonPropertyName("AUTOMATIZADO")]
        public int automation { get; set; }
    }
}
