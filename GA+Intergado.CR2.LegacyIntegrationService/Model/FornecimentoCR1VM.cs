using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class FornecimentoCR1VM
    {
        [JsonPropertyName("TGTWFORN_CODIGO")]
        public long id { get; set; }

        [JsonPropertyName("TGTWFORN_KG_FORNECIDO")]
        public decimal provided_weight { get; set; }


        [JsonPropertyName("TGTWFORN_KG_PREVISTO")]
        public decimal fixed_weight { get; set; }


        [JsonPropertyName("TGTWFORN_FORNECIDO")]
        public long provided { get; set; }

        
        [JsonPropertyName("TGTWFORN_DATA")]
        public DateTime date { get; set; }


        [JsonPropertyName("TGTWFORN_TAG_INICIAL")]
        public string start_tag { get; set; }


        [JsonPropertyName("TGTWFORN_TAG_FINAL")]
        public string final_tag { get; set; }


        [JsonPropertyName("TGTWFORN_ORDEM_TRATO")]
        public long supply_order_sequence { get; set; }


        [JsonPropertyName("TGTWFORN_KG_INICIAL")]
        public decimal start_weight { get; set; }


        [JsonPropertyName("TGTWFORN_KG_FINAL")]
        public decimal final_weight { get; set; }



        [JsonPropertyName("TGTWFORN_HORA_INI")]
        public DateTime start_time { get; set; }


        [JsonPropertyName("TGTWFORN_HORA_FIM")]
        public DateTime final_time { get; set; }


        [JsonPropertyName("TGTWFORN_CODCARREGAMENTO")]
        public long charging_id { get; set; }

        //[JsonPropertyName("TGTWFORN_ORDEM_CURRAL")]
        //public long corral_order { get; set; }



        [JsonPropertyName("TGTWFORN_CODCURRAL")]
        public long corral_id { get; set; }



        [JsonPropertyName("TGTWFORN_CODUSUARIO")]
        public long user_id { get; set; }


        [JsonPropertyName("TGTWFORN_CODMISTURADOR")]
        public long mixer_id { get; set; }


        [JsonPropertyName("TGTWFORN_TRATO")]
        public int supply_order_id { get; set; }


        [JsonPropertyName("TGTWFORN_COD_RACAO")]
        public int recipe_id { get; set; }
    }
}
