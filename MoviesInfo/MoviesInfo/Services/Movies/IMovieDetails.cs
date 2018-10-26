using System;
using System.Threading.Tasks;

namespace MoviesInfo.Services.Movies
{
    public interface IMovieDetails
    {
        Task<Response> GetAllDetail(string movie);
        Task<Response> GetAllSimilar(string urlbase,int page);
       
    }
}
