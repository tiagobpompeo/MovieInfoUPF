using System;
using System.Collections.Generic;
using MoviesInfo.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MoviesInfo.Data;
using Plugin.Geolocator;
using Plugin.Permissions.Abstractions;
using MoviesInfo.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;
using MoviesInfo.Models;

namespace MoviesInfo.Services
{
    public class ApiService
    {
        public string data;

        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please turn on your internet settings.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Verifique sua conexao com a rede.",
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }


        public async Task<Response> CheckLocation()
        {
            if (!CrossGeolocator.Current.IsGeolocationEnabled)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Para verificar sua localização em relação aos mercados, ative sua localização",
                };
            }
                       
            return new Response
            {
                IsSuccess = true,
                Message = "Ativado",
            };
        }

        public async Task<Response> DeleteListCompras(string urlBase, string id_cript)
        {
            try
            {


                var url = urlBase;
                var client = new HttpClient();


                client.DefaultRequestHeaders.Add("token", "582bc29a313ad74224b1f996c9fe5a39");//id uniom pode mudar de acordo com o mercado
                client.DefaultRequestHeaders.Add("Accept", "application/json");//ver se é dessa forma

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("id_cript", id_cript),

               });

                var response = await client.PostAsync(url, formContent);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                //var resultado = JsonConvert.DeserializeObject<ProdutosLista>(result);
                return new Response
                {
                    IsSuccess = true,
                    //Message = resultado.Mensagem,

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

        public async Task<Response> GetList<T>(
           string urlBase,
           string servicePrefix,
           string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
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