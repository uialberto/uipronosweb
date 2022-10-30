using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Net;
using System.Text.Json;
using Uibasoft.Domain.CustomEntities;
using Uibasoft.Domain.DTOs;
using Uibasoft.Domain.DTOs.Modulos.Seguridad.Usuarios;
using Uibasoft.Domain.Interfaces;
using LocalizedText = Uibasoft.Domain.Services.Localization.ServiceLogin;

namespace Uibasoft.Domain.Services
{
    public class ServiceLogin : IServiceLogin
    {
        private readonly ILogger<ServiceLogin> _logger;
        private readonly AppPronosSettingsConfigOptions _setting;
        private readonly RestClient _client;
        private readonly ITokenAppService _tokenApp;

        public ServiceLogin(ILogger<ServiceLogin> pLogger, IOptions<AppPronosSettingsConfigOptions> pConfig, ITokenAppService pTokenApp)
        {
            _logger = pLogger ?? throw new ArgumentNullException(nameof(pLogger));
            _setting = pConfig?.Value ?? throw new ArgumentNullException(nameof(pConfig));
            _tokenApp = pTokenApp ?? throw new ArgumentNullException(nameof(pTokenApp));
            var urlBase = UrlComplete(_setting.UrlBaseApi);
            _client = new RestClient(urlBase);

        }
        private string UrlComplete(string url)
        {
            var llave = url;
            if (llave.EndsWith("/"))
                llave = llave.Substring(0, llave.Length - 1);
            return llave;
        }
        public async Task<(bool IsSuccess, string errorMessage, LoginResponse? result)> LoginByCredentials(LoginUsuarioDto param)
        {
            var urlApi = string.Format(LocalizedText.PostBearerTokenCentral);
            var restRequest = new RestRequest(urlApi, Method.Post);
            var request = restRequest;
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(param);
            request.AddHeader("content-type", "application/json");
            var response = await _client.ExecuteAsync(request);
            var status = response.StatusCode;
            if (status == HttpStatusCode.NotFound)
            {
                _logger.LogInformation($"{GetType().Name} Metodo: {nameof(LoginByCredentials)} {nameof(HttpStatusCode.NotFound)}");
                _logger.LogWarning(JsonSerializer.Serialize(response, response.GetType()));
                return (false, LocalizedText.ApiServiceCentralNotFound, null);
            }
            if (status == HttpStatusCode.ServiceUnavailable)
            {
                _logger.LogInformation($"{GetType().Name} Metodo: {nameof(LoginByCredentials)} {nameof(HttpStatusCode.ServiceUnavailable)}");
                _logger.LogError(JsonSerializer.Serialize(response, response.GetType()));
                return (false, LocalizedText.ApiServiceCentralUnavailable, null);
            }
            if (status == HttpStatusCode.InternalServerError)
            {
                _logger.LogInformation($"{GetType().Name} Metodo: {nameof(LoginByCredentials)} {nameof(HttpStatusCode.InternalServerError)}");
                _logger.LogError(JsonSerializer.Serialize(response, response.GetType()));
                return (false, LocalizedText.ApiServiceCentralError, null);
            }
            if (status == HttpStatusCode.OK)
            {
                LoginResponse? result = null;
                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var res = JsonSerializer.Deserialize<RootDataBaseResponse<LoginResponse>>(response.Content ?? string.Empty, options);
                    result = res?.Data;

                }
                return (true, string.Empty, result);
            }
            else
            {
                _logger.LogInformation($"{GetType().Name} Metodo: {nameof(LoginByCredentials)} HttpStatus Desconocido");
                _logger.LogError(JsonSerializer.Serialize(response, response.GetType()));
                return (false, LocalizedText.ApiServiceCentralError, null);
            }
        }

        public bool IsValidTokenJwt(string tokenJwt)
        {
            return _tokenApp.IsValidTokenJwt(_setting.Secret, _setting.Issuer, tokenJwt);
        }

        public UsuarioDto GetInfoUser()
        {
            throw new NotImplementedException();
        }
    }
}
