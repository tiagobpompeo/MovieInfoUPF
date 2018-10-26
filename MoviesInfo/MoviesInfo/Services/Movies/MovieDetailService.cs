using System;
using System.Net.Http;
using System.Threading.Tasks;
using MoviesInfo.Data;
using MoviesInfo.Models;
using Newtonsoft.Json;

namespace MoviesInfo.Services.Movies
{
    public class MovieDetailService : IMovieDetails
    {
        public string content;
        public string page;
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");//ver se é dessa forma
            return client;
        }

        public async Task<Response> GetAllDetail(string movie)
        {

            try
            {
                string id = movie;
                HttpClient client = GetClient();
                var uri = new Uri(string.Format("https://api.themoviedb.org/3/movie/" + id + "?api_key=1f54bd990f1cdfb230adb312546d765d", string.Empty));
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
                var resultado = JsonConvert.DeserializeObject<MovieDetailsClass>(content);
                return new Response
                {
                    IsSuccess = true,
                    Resultado = resultado
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


        public async Task<Response> GetAllSimilar(string urlBase, int page)
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
