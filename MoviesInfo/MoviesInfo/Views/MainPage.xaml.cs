using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using MoviesInfo.Data;
using MoviesInfo.Services;

namespace MoviesInfo.Views
{
    public partial class MainPage : ContentPage
    {
        readonly List<int> teste = new List<int>();
        public readonly MoviesManager managerMovies = new MoviesManager();
        readonly IList<Models.MoviesNewClass.Resultado> ListMovies = new ObservableCollection<Models.MoviesNewClass.Resultado>();
        public int moviescount;
        public string genreOut;
        public string _poster_path;
        public string _title;
        public string _release_date;
        public string _genresOut;
        #region Services
        private ApiService apiService;
        #endregion

        public MainPage()
        {
            InitializeComponent();
          
            if (Application.Current.Properties.ContainsKey("appName"))
            {
                var nameApp = Application.Current.Properties["appName"];
                //lblWelcome.Text = nameApp.ToString();
            }
            this.apiService = new ApiService();
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
            //var listGenres = await managerMovies.GetAllGenres();
            var moviesCollection = await managerMovies.GetAll(1);//page 1//create command to continue...

            if (moviesCollection.Results != null)
            {
                foreach (Models.MoviesNewClass.Resultado outView in moviesCollection.Results)
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
			await Navigation.PushAsync(new MovieDetail(filmetodo.Id.ToString()));
        }
    }
}
