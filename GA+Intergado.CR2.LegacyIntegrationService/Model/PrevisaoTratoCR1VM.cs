using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class PrevisaoTratoCR1VM
    {
        [JsonPropertyName("CODIGO")]
        public long id { get; set; }


        [JsonPropertyName("CODIGOTGTCURRAL")]
        public long corral_id { get; set; }


        [JsonPropertyName("CODIGOTGTTRATO")]
        public long supply_order_id { get; set; }


        [JsonPropertyName("CODIGORECEITA")]
        public long recipe_id { get; set; }


        [JsonPropertyName("DATAFORNECIMENTO")]
        public DateTime supply_date { get; set; }


        [JsonPropertyName("PREVISTOKG")]
        public double expected_weight { get; set; }


        [JsonPropertyName("REALIZADOKG")]
        public double realized_weight { get; set; }


        [JsonPropertyName("QUANTIDADECABECA")]
        public int head_quantity { get; set; }
    }
}