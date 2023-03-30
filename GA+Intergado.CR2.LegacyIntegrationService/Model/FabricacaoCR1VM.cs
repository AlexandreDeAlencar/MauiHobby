using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class FabricacaoCR1VM
    {
        [JsonPropertyName("CR1FAB_CODIGO")]
        public long id { get; set; }


        [JsonPropertyName("CR1FAB_COD_RECEITA")]
        public long recipe_id { get; set; }


        [JsonPropertyName("CR1FAB_COD_USUARIO")]
        public long user_id { get; set; }


        [JsonPropertyName("CR1FAB_COD_MISTURADOR")]
        public long mixer_id { get; set; }


        [JsonPropertyName("CR1FAB_DATAREGISTRO")]
        public DateTime register_Date { get; set; }


        [JsonPropertyName("CR1FAB_HORA_INICIO")]
        public DateTime start_time { get; set; }


        [JsonPropertyName("CR1FAB_HORA_FIM")]
        public DateTime final_time { get; set; }


        [JsonPropertyName("CR1FAB_MN_PREVISTO")]
        public decimal MNPrevisto { get; set; }


        [JsonPropertyName("CR1FAB_MN_FABRICADO")]
        public decimal MVFabricacao { get; set; }


        [JsonPropertyName("CR1FAB_TIPOUSO")]
        public long user_type { get; set; }


        [JsonPropertyName("CR1FAB_TOTAL_PERDA")]
        public decimal total_loss { get; set; }


        [JsonPropertyName("CR1FAB_KG_SOBRA")]
        public decimal kg_sobra { get; set; }


        [JsonPropertyName("CR1FAB_CODFAB_SOBRA")]
        public long over { get; set; }


        [JsonPropertyName("CR1FAB_COD_OPERADOR")]
        public long operator_id { get; set; }


        [JsonPropertyName("CR1FAB_SYNC_TGC")]
        public string? sync_tgc { get; set; }


        [JsonPropertyName("CR1FAB_DATA_SYNC_TGC")]
        public DateTime sync_tgc_date { get; set; }

        [JsonPropertyName("CR1FAB_NUMERO_TRATO")]
        public int supply_order_id { get; set; }


        [JsonPropertyName("CR1FAB_FLAG_AUTOMATION")]
        public string? automation_flag { get; set; }


        [JsonPropertyName("CR1FAB_FLAG_BATCH_BOX")]
        public string? batch_box_flag { get; set; }

        [JsonPropertyName("cr1fab_cod_ordem_producao")]
        public long? codigo_ordem_producao { get; set; }
    }
}
