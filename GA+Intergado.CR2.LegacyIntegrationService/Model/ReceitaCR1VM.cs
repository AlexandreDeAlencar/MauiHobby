using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class ReceitaCR1VM
    {
        [JsonPropertyName("CODIGO")]
        public string id { get; set; }


        [JsonPropertyName("codigoalfa")]
        public string alpha_code { get; set; }


        [JsonPropertyName("DATAREGISTRO")]
        public DateTime register_Date { get; set; }


        [JsonPropertyName("DATAPREVISTODIA")]
        public DateTime expected_date_day { get; set; }


        [JsonPropertyName("MATERIASECA")]
        public decimal dry_matter { get; set; }


        [JsonPropertyName("IMNPORCABECADIA")]
        public int IMN_per_head { get; set; } // Índice Massa Natural ....


        [JsonPropertyName("CUSTOTONELADAMATERIANATURAL")]
        public int tonne_cost_natural_material { get; set; }


        [JsonPropertyName("TOTALPREVISTODIA")]
        public int total_day_prediction { get; set; }


        [JsonPropertyName("TIPORECEITA")]
        public string recipe_type { get; set; }


        [JsonPropertyName("NOME")]
        public string name { get; set; }


        [JsonPropertyName("DATACRIACAO")]
        public DateTime creation_Date { get; set; }


        [JsonPropertyName("STATUS")]
        public string status { get; set; }


        [JsonPropertyName("TEMPOMISTURA")]
        public decimal mixing_Time { get; set; }


        [JsonPropertyName("VERSAO")]
        public long versao { get; set; }
    }
}