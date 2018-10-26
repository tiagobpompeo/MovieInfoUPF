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

namespace MoviesInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetail : ContentPage
	{
       
        readonly MoviesDetailsManager managerMoviesDetail = new MoviesDetailsManager();
        #region Services
        private ApiService apiService;
        readonly IList<Models.MoviesNewClass.Resultado> SimilarMovies = new ObservableCollection<Models.MoviesNewClass.Resultado>();
        #endregion
        public readonly MoviesManager managerMovies = new MoviesManager();
        public MovieDetail (string id)
		{
			InitializeComponent ();
            this.apiService = new ApiService();

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




            var moviesCollection = await managerMovies.GetAll(3);//page 1//create command to continue...

            if (moviesCollection.Results != null)
            {
                foreach (Models.MoviesNewClass.Resultado outView in moviesCollection.Results)
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

                listaSimilar.ItemsSource = SimilarMovies;
               
            }
           


        }

        public async void LoadDetails(string id)
		{

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Conexão de Rede", connection.Message, "OK");
                return;
            }

              var detailsMovie = await managerMoviesDetail.GetAllDetail(id);
   
                Title.Text = detailsMovie.title;
                Release.Text = detailsMovie.release_date;
                OverviewTitle.Text = detailsMovie.overview;
                ImgBig.Source = "https://image.tmdb.org/t/p/w500"+detailsMovie.poster_path;
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