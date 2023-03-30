using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class DescarteFabricacaoCR1VM
    {
        [JsonPropertyName("CR1WDESC_CODIGO")]
        public long id { get; set; }


        [JsonPropertyName("CR1WDESC_CODFAD")]
        public long production_id { get; set; }


        [JsonPropertyName("CR1WDESC_CODUSER")]
        public long user_id { get; set; }


        [JsonPropertyName("CR1WDESC_QTD")]
        public decimal amount_kg { get; set; }


        [JsonPropertyName("CR1WDESC_DATA")]
        public DateTime date { get; set; }


        [JsonPropertyName("CR1WDESC_OBS")]
        public string observation { get; set; }

        public int CR1WDESC_ID_WS { get; set; }
    }
}
