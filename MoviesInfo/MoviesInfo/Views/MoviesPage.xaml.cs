using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using MoviesInfo.Data;
using MoviesInfo.Services;
using MoviesInfo.Services.Movies;
using MoviesInfo.Models;

namespace MoviesInfo.Views
{
    public partial class MoviesPage : ContentPage
    {
        private readonly IMovie _movieservice;
        readonly IList<Models.MoviesNewClass.Resultado> ListMovies = new ObservableCollection<Models.MoviesNewClass.Resultado>();
        public int moviescount;
        public string genreOut;
        public string _poster_path;
        public string _title;
        public string _release_date;
        public string _genresOut;
        #region Services
        private NetWorkService apiService;
        #endregion

        public MoviesPage()
        {
            InitializeComponent();

            _movieservice = new MoviesService();
            if (Application.Current.Properties.ContainsKey("appName"))
            {
                var nameApp = Application.Current.Properties["appName"];
                //lblWelcome.Text = nameApp.ToString();
            }
            this.apiService = new NetWorkService();
            ReturnData();
            BindingContext = ListMovies;
        }

        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            ReturnData();
        }

        private async void ReturnData()
        {
            listView.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Conexão de Rede", connection.Message, "OK");
                return;
            }

            var response = await _movieservice.GetAllMovies("https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language=pt-BR&page=", 2);

            var resultado = response.Resultado;


            if (response!= null)
            {
                foreach (MoviesNewClass.Resultado outView in (List<MoviesNewClass.Resultado>)resultado)
                {
                    var genreIds = outView.Genre_ids;//list id genres of movie in upcoming compare to another list                   
                    ListMovies.Add(new Models.MoviesNewClass.Resultado
                    {
                        Id = outView.Id,
                        Poster_path = "https://image.tmdb.org/t/p/w200" + outView.Poster_path,
                        Title = outView.Title,
                        Release_date = outView.Release_date,
                        //GenresOut = genreOut
                    });
                }
            }

            listView.IsRefreshing = false;
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            var filmetodo = e.Item as Models.MoviesNewClass.Resultado;
            ((ListView)sender).SelectedItem = null; // de-select the row           
            await Navigation.PushAsync(new MovieDetail2(filmetodo.Id.ToString()));
        }
    }
}
