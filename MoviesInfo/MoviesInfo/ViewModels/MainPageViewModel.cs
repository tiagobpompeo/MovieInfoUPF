using System;
using System.Linq;
using System.Collections.ObjectModel;
using MoviesInfo.Data;
using System.Collections.Generic;
using MoviesInfo.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviesInfo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
             
        public readonly MoviesManager managerMovies = new MoviesManager();
        public int moviescount;
        public string genreOut;
        public string _poster_path;
        public string _title;
        public string _release_date;
        public string _genresOut;
        public List<MoviesNewClass.Resultado> _results;
        private string _idMovie;
        public ObservableCollection<Models.MoviesNewClass.Resultado> ListMovies { get; set; }


        public MainPageViewModel()
        {
            ListMovies = new ObservableCollection<Models.MoviesNewClass.Resultado>();
            ReturnData();
        }

        private async void ReturnData()
        {
           
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


        public ICommand ItemClickCommandMovie
        {
            get
            {
                return new Command((item) =>
                {
                    var allData = item;
                    
                });
            }
        }

        private void ItemMovie(Models.MoviesNewClass.Resultado movie)
        {
           //ir para detalhes           
        }
    }
}