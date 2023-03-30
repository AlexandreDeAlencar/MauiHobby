using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class UserAPIVM
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataRegistro { get; set; }
        public int TipoUsuario { get; set; }
        public string SaltSenha { get; set; }
    }

    public class UserResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("user")]
        public string user { get; set; }


        [JsonProperty("token")]
        public string token { get; set; }


        [JsonProperty("username")]
        public string UserName { get; set; }
    }

    public class UsuarioRespostaLogin
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; }


        [JsonProperty("refresh_token")]
        public string refresh_token { get; set; }

        [JsonProperty("expires_in")]
        public double expires_in { get; set; }
    }
    public class UsuarioRespostaLogin_Nome_Token
    {
        public string access_token { get; set; }
        public string Nome { get; set; }
        public string refresh_token { get; set; }
    }

    public class TypeUserResponsa
    {
        public int Index { get; set; }

        [JsonPropertyName("description")]
        public string Descricao { get; set; }
    }
}
