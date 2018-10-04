using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MoviesInfo.Models;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace MoviesInfo.Data
{
    public class MoviesManager
    {
        const string Url = "https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language=pt-BR&page=";
        const string UrlGender = "https://api.themoviedb.org/3/genre/movie/list?api_key=1f54bd990f1cdfb230adb312546d765d&language=pt-BR";
        public string content;
        public string page;

        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");//ver se é dessa forma
            return client;
        }

        public async Task<MoviesNewClass> GetAll(int page)
        {            
            this.page = page.ToString();
            HttpClient client = GetClient();
            var uri = new Uri(string.Format(Url + this.page.ToString(), string.Empty));
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<MoviesNewClass>(content);
        }
    }
}