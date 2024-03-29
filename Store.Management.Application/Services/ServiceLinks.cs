using Newtonsoft.Json;
using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Store.Management.Application.Services
{
    public class ServiceLinks : IServiceLinks
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private string _MimeTypeDefault => "application/json";

        public ServiceLinks()
        {
            this._jsonSerializerOptions = new JsonSerializerOptions()
            {
                AllowTrailingCommas = false,
                MaxDepth = 64,
                Encoder = JavaScriptEncoder.Default,
                WriteIndented = true,
                IncludeFields = false,
                IgnoreReadOnlyFields = false,
                IgnoreReadOnlyProperties = false,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            this._jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            };
        }

        public List<Category> GetTheListOfCategory(string uri)
        {
            List<Category> listItem = new List<Category>();

            try
            {
                using (var webClient = new WebClient() { Encoding = Encoding.UTF8 })
                {
                    if (string.IsNullOrEmpty(uri))
                    {
                        throw new Exception("Route do not informed.");
                    }

                    webClient.Headers[HttpRequestHeader.ContentType] = _MimeTypeDefault;
                    webClient.Headers[HttpRequestHeader.Allow] = _MimeTypeDefault;
                    webClient.Headers[HttpRequestHeader.Accept] = _MimeTypeDefault;

                    return JsonConvert.DeserializeObject<List<Category>>(webClient.DownloadString(uri), this._jsonSerializerSettings);
                }
            }
            catch (WebException ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public List<SubCategory> LoadObjectSubCategoryById(string uri)
        {
            List<SubCategory> listItem = new List<SubCategory>();

            try
            {
                using (var webClient = new WebClient() { Encoding = Encoding.UTF8 })
                {
                    if (string.IsNullOrEmpty(uri))
                    {
                        throw new Exception("Route do not informed.");
                    }

                    webClient.Headers[HttpRequestHeader.ContentType] = _MimeTypeDefault;
                    webClient.Headers[HttpRequestHeader.Allow] = _MimeTypeDefault;
                    webClient.Headers[HttpRequestHeader.Accept] = _MimeTypeDefault;

                    return JsonConvert.DeserializeObject<List<SubCategory>>(webClient.DownloadString(uri), this._jsonSerializerSettings);
                }
            }
            catch (WebException ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public List<Product> GetTheListOfProductBySubCategoryId(string uri)
        {
            List<SubCategory> listItem = new List<SubCategory>();

            try
            {
                using (var webClient = new WebClient() { Encoding = Encoding.UTF8 })
                {
                    if (string.IsNullOrEmpty(uri))
                    {
                        throw new Exception("Route do not informed.");
                    }

                    webClient.Headers[HttpRequestHeader.ContentType] = _MimeTypeDefault;
                    webClient.Headers[HttpRequestHeader.Allow] = _MimeTypeDefault;
                    webClient.Headers[HttpRequestHeader.Accept] = _MimeTypeDefault;

                    return JsonConvert.DeserializeObject<List<Product>>(webClient.DownloadString(uri), this._jsonSerializerSettings);
                }
            }
            catch (WebException ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        private StringContent ConvertObjectToStringContent(HttpClient httpClient, object obj)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_MimeTypeDefault));

            var jsonContent = JsonConvert.SerializeObject(obj);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, _MimeTypeDefault);
            contentString.Headers.ContentType = new MediaTypeHeaderValue(_MimeTypeDefault);

            return contentString;
        }
    }
}