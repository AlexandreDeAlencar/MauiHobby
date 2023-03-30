using GA_Intergado.CR2.App.ServerIntegration.DTOs;
using GA_Intergado.CR2.App.ServerIntegration.Services;
using GA_Intergado.CR2.IntegrationService.Settings;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;

namespace GA_Intergado.CR2.IntegrationService
{
    public class IntegrationService : IIntegrationService
    {
        private const int NEW_REQUEST_TIMEOUT = 5000;
        private const int CLIENT_CONNECTION_TIMEOUT = 5000;
        string baseURL;
        private RestClient _client;
        private DateTime? _lastRequestTime = null;
        private string _standardSchema = null;

        public RestClient Client
        {
            get { return _client; }
            private set { _client = value; }
        }

        public string BaseURL
        {
            get => baseURL;
            protected set
            {
                if (value == null)
                    baseURL = value;
                else
                {
                    if (!value.StartsWith("http://"))
                    {
                        value = "http://" + value;
                    }
                    if (!value.EndsWith("/"))
                    {
                        value = value + "/";
                    }
                    baseURL = value;
                }

            }
        }

        public IntegrationService(
            IConfiguration configuration
            , string standardSchema = null
            , string authorizarionToken = null)
        {
            this.BaseURL = configuration.GetRequiredSection("IntegrationServiceHostAdress").Get<IntegrationSettings>().HostAdress;
            ;
            Client = new RestClient(BaseURL);
            if (!string.IsNullOrEmpty(standardSchema))
            {
                Client.AddDefaultHeader("Accept-Profile", standardSchema);
                Client.AddDefaultHeader("Content-Profile", standardSchema);
            }
            if (!string.IsNullOrEmpty(authorizarionToken))
            {
                Client.AddDefaultHeader("Authorization", "Bearer " + authorizarionToken);
            }
        }

        public List<T> Download<T>(ServerIntegrationItemDTO itemEntity) where T : class
        {

            Client.Timeout = CLIENT_CONNECTION_TIMEOUT;
            var request = new RestRequest(itemEntity.Endpoint);

            try
            {
                var response = Client.Execute<List<T>>(request);

                if (response.StatusCode == 0 && response.ErrorMessage != null)
                {
                    throw new Exception(response.ErrorMessage);
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK && response.Content != null)
                {
                    throw new Exception(response.Content);
                }
                JArray jArray = JArray.Parse(response.Content);
                string name = "";
                // Get the value of a specific key for each object in the array
                foreach (JObject jObject in jArray)
                {
                    name += (string)jObject["NOME"] + "\n"; // Replace "name" with the desired key
                }

                List<T> responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(response.Content);
                response.Data = responseData;

                return responseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> Upload<T>(ServerIntegrationItemDTO itemEntity, List<T> uploadList) where T : class
        {

            var json = JsonConvert.SerializeObject(uploadList);
            var request = new RestRequest(itemEntity.Endpoint, Method.POST);

            Client.Timeout = 180000;
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            try
            {
                var response = Client.Execute(request);
                if (response.StatusCode == 0 && response.ErrorMessage != null)
                {
                    throw new Exception(response.ErrorMessage);
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK
                && response.StatusCode != System.Net.HttpStatusCode.Created
                && response.StatusCode != System.Net.HttpStatusCode.Accepted
                && response.StatusCode != System.Net.HttpStatusCode.NonAuthoritativeInformation
                && response.StatusCode != System.Net.HttpStatusCode.ResetContent
                && response.StatusCode != System.Net.HttpStatusCode.PartialContent
                && response.Content != null)
                {
                    throw new Exception(response.Content);
                }

                return uploadList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
