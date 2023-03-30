using Newtonsoft.Json;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class Pack
    {
        [JsonProperty("PosicaoMisturador")]
        public int PosicaoMisturador { get; set; }

        
        [JsonProperty("CodigoMisturador")]
        public int MisturadorId { get; set; }


        [JsonProperty("LoteFabReceita")]
        public long LoteFabReceita { get; set; }


        [JsonProperty("CodigoReceita")]
        public long ReceitaId { get; set; }


        [JsonProperty("NomeRacao")]
        public string NomeRacao { get; set; }


        [JsonProperty("DataFabricacao")]
        public string DataFabricacao { get; set; }


        [JsonProperty("CheckSum")]
        public int CheckSum { get; set; }


        [JsonProperty("Peso")]
        public int Peso { get; set; }


        [JsonProperty("DataCriacao")]
        public long DataCriacao { get; set; }


        [JsonProperty("codigo_usuario_cr1")]
        public int codigo_usuario_cr1 { get; set; }


        [JsonProperty("codigo_usuario_tgt")]
        public int codigo_usuario_tgt { get; set; }


        public DateTime DataRegistro { get; set; }

        /// <summary>
        /// Status da fabricação
        /// A = aberto (pode ser carregado pelo TGT)
        /// T = terminado (não pode ser carregado pelo TGT)
        /// </summary>
        [JsonProperty("Status")]
        public string Status { get; set; }


        [JsonProperty("hora_carregamento")]
        public DateTime? Hora_carregamento { get; set; }
    }
}