using FFImageLoading.Forms;
using MoviesInfo.Layouts;
using MoviesInfo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MoviesInfo.Data;
using MoviesInfo.Models;

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


        public MainPage()
        {
            InitializeComponent();
          
            if (Application.Current.Properties.ContainsKey("appName"))
            {
                var nameApp = Application.Current.Properties["appName"];
                //lblWelcome.Text = nameApp.ToString();
            }

            ReturnData();
            BindingContext = ListMovies;               
           

        }


        private async void ReturnData()
        {
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

        }


        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row
           await Navigation.PushAsync(new MovieDetail());

        }


    }
}
