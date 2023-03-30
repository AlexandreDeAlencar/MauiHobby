using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class CarregamentoCR1VM
    {
        [JsonPropertyName("TGTWCAR_CODIGO")]
        public long id { get; set; }


        [JsonPropertyName("TGTWCAR_COD_MIST")]
        public long mixer_id { get; set; }


        [JsonPropertyName("TGTWCAR_COD_TRATO")]
        public long supply_order_id { get; set; }


        [JsonPropertyName("TGTWCAR_KG_CARREGADO")]
        public decimal weight_loaded { get; set; }


        [JsonPropertyName("TGTWCAR_DATA_REGISTRO")]
        public DateTime register_date { get; set; }


        [JsonPropertyName("TGTWCAR_ID_WS")]
        public long ws_id { get; set; }


        [JsonPropertyName("TGTWCAR_PESO_BALANCAO")]
        public int? weight_balance { get; set; }


        [JsonPropertyName("TGTWCAR_FLAG_AUTOMATION")]
        public string? automatic_flag { get; set; }


        [JsonPropertyName("TGTWCAR_PESO_BALANCAO_RETORNO")]
        public int? weight_return_balance { get; set; }
    }
}