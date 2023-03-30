using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class LogUsuarioCR1VM
    {
        [JsonPropertyName("LOG_ID")]
        public long id { get; set; }


        [JsonPropertyName("USUARIO_CODIGO")]
        public long user_id { get; set; }


        [JsonPropertyName("USUARIO_NOME")]
        public string user_name { get; set; }


        [JsonPropertyName("USUARIO_LOGIN")]
        public string user_login { get; set; }


        [JsonPropertyName("ACAO")]
        public string action { get; set; }


        [JsonPropertyName("NUMERO_DISPOSITIVO")]
        public int device_number { get; set; }


        [JsonPropertyName("DATA")]
        public DateTime date { get; set; }


        [JsonPropertyName("FLAG_ENVIO")]
        public int send_flag { get; set; }


        [JsonPropertyName("DATA_ENVIO")]
        public DateTime send_date { get; set; }


        [JsonPropertyName("NUMERO_VAGAO")]
        public long mixer_id { get; set; }
    }
}
