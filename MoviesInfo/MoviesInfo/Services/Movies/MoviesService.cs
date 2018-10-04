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

        public async Task<Response> GetAllMovies(string urlBase,int page)
        {
            try
            {       
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");//ver se é dessa forma
                var uri = new Uri(string.Format(urlBase + page.ToString(), string.Empty));
                var response = await client.GetAsync(uri);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var resultado = JsonConvert.DeserializeObject<MoviesNewClass>(result);

                return new Response
                {
                    IsSuccess = true,
                    Result = resultado            
               };
             }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }
            
        }

        
    }
}
