using System;
using MoviesInfo.Services;
using MoviesInfo.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoviesInfo.Services.Movies
{
    public class MoviesService : IMovie
    {

        public string content;
        public string page;

        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");//ver se é dessa forma
            return client;
        }

        public async Task<Response> GetAllMovies(string urlBase, int page)
        {
            try
            {
                this.page = page.ToString();
                HttpClient client = GetClient();
                var uri = new Uri(string.Format(urlBase + this.page, string.Empty));
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }

                var resultado = JsonConvert.DeserializeObject<MoviesNewClass>(content);
                return new Response
                {
                    IsSuccess = true,
                    Resultado = resultado.Results
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

        }

    }
}
