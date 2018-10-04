using System;
using System.Threading.Tasks;
using MoviesInfo.Services.Movies;
using MoviesInfo.Models;

namespace MoviesInfo.Services.Movies
{
    public interface IMovie
    {

        Task<Response> GetAllMovies(string urlBase,int page);
    }
}
