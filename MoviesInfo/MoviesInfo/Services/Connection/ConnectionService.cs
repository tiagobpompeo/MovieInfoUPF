using System;
using System.Threading.Tasks;
using MoviesInfo.Model;
using MoviesInfo.Services.RequestProvider;
using Plugin.Connectivity;

namespace MoviesInfo.Services.Connection
{
    public class ConnectionService: IConnectionService
    {
        private readonly IRequestProvider _requestProvider;

       

        public async Task<Response> CheckConnection()
        {

            try
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
