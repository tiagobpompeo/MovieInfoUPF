using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesInfo.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviesInfo.Data;
using MoviesInfo.Services;
using System.Collections.ObjectModel;
using MoviesInfo.Services.Movies;
using MoviesInfo.Models;
using MoviesInfo.Services.Connection;

namespace MoviesInfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailFinal : ContentPage
    {
       
        private readonly IConnectionService _connectionService;
        private readonly IMovieDetails _movieDetailService;
        readonly IList<Models.MoviesNewClass.Resultado> SimilarMovies = new ObservableCollection<Models.MoviesNewClass.Resultado>();    
        readonly MoviesDetailsManager managerMoviesDetail = new MoviesDetailsManager();
        public readonly MoviesManager managerMovies = new MoviesManager();


        public MovieDetailFinal(string id)
        {
            InitializeComponent();
            _connectionService = new ConnectionService();
            _movieDetailService = new MovieDetailService();
            LoadDetails(id);
            LoadSimilar();
        }

        public async void LoadDetails(string id)
        {
            var connection = await this._connectionService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Conexão de Rede", connection.Message, "OK");
                return;
            }

            var response = await _movieDetailService.GetAllDetail(id);
            var resultado = response.ResultadoDetail;
            MovieDetailsClass dados = (MovieDetailsClass)resultado;

            if(dados!=null)
            {
                Title.Text = dados.title;
                Release.Text = dados.release_date;
                OverviewTitle.Text = dados.overview;
                ImgBig.Source = "https://image.tmdb.org/t/p/w500" + dados.poster_path;
            }
            
        
        }


        private async void LoadSimilar()
        {
            var connection = await this._connectionService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Conexão de Rede", connection.Message, "OK");
                return;
            }
            //var listGenres = await managerMovies.GetAllGenres();
            var response = await _movieDetailService.GetAllSimilar("https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language=pt-BR&page=", 5);
            var resultado = response.Resultado;

            if (response != null)
            {
                foreach (MoviesNewClass.Resultado outView in (List<MoviesNewClass.Resultado>)resultado)
                {
                    var genreIds = outView.Genre_ids;//list id genres of movie in upcoming compare to another list                   
                    SimilarMovies.Add(new Models.MoviesNewClass.Resultado
                    {
                        Id = outView.Id,
                        Poster_path = "https://image.tmdb.org/t/p/w200" + outView.Poster_path,
                        Title = outView.Title,
                        Release_date = outView.Release_date,
                        //GenresOut = genreOut
                    });
                }
            }

            listaSimilar.ItemsSource = SimilarMovies;
        }



    }
}