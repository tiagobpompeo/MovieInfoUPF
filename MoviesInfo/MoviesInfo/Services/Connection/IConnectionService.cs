using System;
using System.Threading.Tasks;
using MoviesInfo.Model;

namespace MoviesInfo.Services.Connection
{
    public interface IConnectionService
    {
        Task<Response> CheckConnection();
    }
}
