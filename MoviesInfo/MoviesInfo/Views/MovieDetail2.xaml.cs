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

namespace MoviesInfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetail2 : ContentPage
    {
        private readonly IMovieDetails _movieDetailService;
        readonly MoviesDetailsManager managerMoviesDetail = new MoviesDetailsManager();
        #region Services
        private NetWorkService apiService;
        readonly IList<Models.MoviesNewClass.Resultado> SimilarMovies = new ObservableCollection<Models.MoviesNewClass.Resultado>();
        #endregion
        public readonly MoviesManager managerMovies = new MoviesManager();
        public MovieDetail2(string id)
        {
            InitializeComponent();
            this.apiService = new NetWorkService();

            _movieDetailService = new MovieDetailService();

            LoadDetails(id);
            ReturnData();
        }

        private async void ReturnData()
        {

            var connection = await this.apiService.CheckConnection();

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

        public async void LoadDetails(string id)
        {

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Conexão de Rede", connection.Message, "OK");
                return;
            }

            var response = await _movieDetailService.GetAllDetail(id);

            var resultado = response.ResultadoDetail;
            MovieDetailsClass dados = (MovieDetailsClass)resultado;

            if (dados != null)
            {
                Title.Text = dados.title;
                Release.Text = dados.release_date;
                OverviewTitle.Text = dados.overview;
                ImgBig.Source = "https://image.tmdb.org/t/p/w500" + dados.poster_path;
            }

        }



        public void PlayMyAudio(object sender, EventArgs args)
        {
            //https://github.com/juniandotnet/xamarin-audio-player
            //https://audioboom.com/posts/5766044-follow-up-305.mp3
            //nao quero usar dependencias e quero rodar videos https://github.com/martijn00/XamarinMediaManager
            DependencyService.Get<IAudio>().Play("followup305.mp3");
        }
    }
}