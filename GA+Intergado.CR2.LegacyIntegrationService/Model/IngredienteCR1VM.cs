using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class IngredienteCR1VM
    {
        [JsonPropertyName("CODIGO")]
        public int id { get; set; }


        [JsonPropertyName("NOME")]
        public string name { get; set; }


        [JsonPropertyName("TIPO")]
        public string tipo { get; set; } = "";


        [JsonPropertyName("CUSTOKG")]
        public decimal weight_cost { get; set; }


        [JsonPropertyName("DATAREGISTRO")]
        public DateTime register_Date { get; set; }


        [JsonPropertyName("ESTOQUEMINIMOKG")]
        public decimal minimum_stock_weight { get; set; }


        [JsonPropertyName("MATERIASECA")]
        public decimal dry_matter { get; set; }


        [JsonPropertyName("CODIGOALFA")]
        public string alpha_code { get; set; }


        [JsonPropertyName("ESTOQUEATUAL")]
        public long current_inventory { get; set; }
    }
}