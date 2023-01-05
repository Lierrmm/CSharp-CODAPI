using Newtonsoft.Json;
using RestSharp;

namespace CSharp_CODAPI
{
    public static class Http
    {
        private static readonly RestClient apiClient = new("https://my.callofduty.com");
        private const string apiPath = "/api/papi-client";
        private const string baseCookie = "new_SiteId=cod;ACT_SSO_LOCALE=en_US;country=US;";
        public static string globalSsoToken = string.Empty;

        public static async Task<T?> sendRequest<T>(string uri)
        {
            var requestUrl = $"{apiPath}{uri}";

            Console.WriteLine(requestUrl);

            var request = new RestRequest
            {
                Method = Method.Get,
                Resource = requestUrl,
            };

            var response = await apiClient.ExecuteAsync(request);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                var responseBody = JsonConvert.DeserializeObject<T>(response.Content);

                return responseBody;
            }
            else throw new Exception(response.ErrorMessage ?? "Something went wrong");
        }

        public static bool login(string ssoToken)
        {
            if (ssoToken == null || ssoToken.Length == 0) return false;

            var fakeXSRF = "68e8b62e-1d9d-4ce1-b93f-cbe5ff31a041";

            var defaultParams = apiClient.DefaultParameters;

            foreach (var parameter in defaultParams.ToList())
            {
                apiClient.DefaultParameters.RemoveParameter(parameter);
            }

            apiClient.AddDefaultHeaders(new Dictionary<string, string>
            {
                { "X-XSRF-TOKEN", fakeXSRF },
                { "X-CSRF-TOKEN", fakeXSRF },
                { "Atvi-Auth", ssoToken },
                { "ACT_SSO_COOKIE", ssoToken },
                { "atkn", ssoToken }
            });

            apiClient.AddDefaultHeader("cookie", $"{baseCookie}ACT_SSO_COOKIE={ssoToken};XSRF-TOKEN={fakeXSRF};API_CSRF_TOKEN={fakeXSRF};ACT_SSO_EVENT=\"LOGIN_SUCCESS:1644346543228\";ACT_SSO_COOKIE_EXPIRY=1645556143194;comid=cod;ssoDevId=63025d09c69f47dfa2b8d5520b5b73e4;tfa_enrollment_seen=true;gtm.custom.bot.flag=human;");

            apiClient.AddDefaultHeader("Content-Type", "application/json");

            apiClient.AddDefaultHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");

            globalSsoToken = ssoToken;
            return true;
        }
    }
}
