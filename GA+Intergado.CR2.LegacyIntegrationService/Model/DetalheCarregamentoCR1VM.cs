using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class DetalheCarregamentoCR1VM
    {
        [JsonPropertyName("DETCAR_CODIGO")]
        public long id { get; set; }

        
        [JsonPropertyName("DETCAR_COD_CARR")]
        public long charging_id { get; set; }


        [JsonPropertyName("DETCAR_LOTE_FAB")]
        public long manufacturing_id { get; set; }


        [JsonPropertyName("DETCAR_COD_VAGAO")]
        public long mixer_id { get; set; }


        [JsonPropertyName("DETCAR_COD_USER")]
        public long user_id { get; set; }


        [JsonPropertyName("DETCAR_HORA_INI")]
        public DateTime start_time { get; set; }


        [JsonPropertyName("DETCAR_HORA_FIM")]
        public DateTime end_time { get; set; }


        [JsonPropertyName("DETCAR_PESO_INI")]
        public decimal start_weight { get; set; }


        [JsonPropertyName("DETCAR_PESO_FIM")]
        public decimal final_weight { get; set; }

       
        [JsonPropertyName("DETCAR_DATA_REG")]
        public DateTime register_Date { get; set; }


        [JsonPropertyName("DETCAR_FLAG_AUTOMATION")]
        public string? automation_flag { get; set; }
    }
}
