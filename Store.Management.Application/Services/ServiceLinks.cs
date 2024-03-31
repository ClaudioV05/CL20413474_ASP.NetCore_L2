using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Store.Management.Application.Services
{
    public class ServiceLinks : IServiceLinks
    {
        private readonly IConfiguration _configuration;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private string _MimeTypeDefault => "application/json";

        public ServiceLinks(IConfiguration configuration)
        {
            _configuration = configuration;

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

        #region Configuration.

        public string? ReturnStoreManagementUriApi() => _configuration["StoreManagementApi:StoreManagementUriApi"];

        public string? ReturnStoreManagementNameController() => _configuration["StoreManagementApi:ControllerNameProduct"];

        public string? ReturnStoreManagementActionNameGetTheListOfCategory() => _configuration["StoreManagementApi:ActionNameGetTheListOfCategory"];

        public string? ReturnStoreManagementActionNameGetTheListOfSubCategoryByCategoryId() => _configuration["StoreManagementApi:ActionNameGetTheListOfSubCategoryByCategoryId"];

        public string? ReturnStoreManagementActionNameGetTheListOfProductBySubCategoryId() => _configuration["StoreManagementApi:ActionNameGetTheListOfProductBySubCategoryId"];
        
        public string? ReturnStoreManagementActionNameLoginUser() => _configuration["StoreManagementApi:ActionNameLoginUser"];

        public string? ReturnStoreManagementActionNameRegistrationUser() => _configuration["StoreManagementApi:ActionNameRegistrationUser"];

        private string? SerializeModel(User user) => JsonConvert.SerializeObject(user);

        #endregion Configuration.

        #region Store management products.

        public List<Category> GetTheListOfCategory(string uri)
        {
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

        public List<SubCategory> GetTheListOfSubCategoryByCategoryId(string uri)
        {
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

        #endregion Store management products.

        #region Store management login user.

        public User LoginUser(string uri, User user)
        {
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

                    var obj = this.SerializeModel(user);

                    return JsonConvert.DeserializeObject<User>(webClient.UploadString(uri, obj), this._jsonSerializerSettings);
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

        #endregion Store management login user.

        #region Store management registration user.

        public User RegisterUser(string uri, User user)
        {
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

                    var obj = this.SerializeModel(user);

                    return JsonConvert.DeserializeObject<User>(webClient.UploadString(uri, obj), this._jsonSerializerSettings);
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

        #endregion Store management registration user.
    }
}