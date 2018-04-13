using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProjectXamarin.Models;

namespace TestProjectXamarin.Data
{
    public class RestService
    {
        private HttpClient client;

        private string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlenconded"));
        }

        public async Task<Token> Login(User user)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));

            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            string weburl = "www.test.com";

            // Token token = await PostResponseLogin<Token>(weburl, content); this will work when we will have an actual server to call
            Token token = new Token() { access_token = "test", expires_in = 30 };
            token.expire_date = DateTime.Now.AddMinutes(token.expires_in);

            return token;
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            HttpResponseMessage httpResponseMessage = await client.PostAsync(weburl, content);

            string jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            Token token = App.TokenDatabase.GetToken();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Berear", token.access_token);

            try
            {
                HttpResponseMessage httpResponseMessage = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, "application/json"));

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(jsonResult);
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }

        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            Token token = App.TokenDatabase.GetToken();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Berear", token.access_token);

            try
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(weburl);

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(jsonResult);
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }
    }
}