using FFImageLoading.Forms;
using MoviesInfo.Layouts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesInfo.Views
{
    public partial class MainPage : ContentPage
    {
        readonly List<int> teste = new List<int>();
        readonly IList<Movie> Filmes = new ObservableCollection<Movie>();

        public MainPage()
        {
            InitializeComponent();
            //PopularLista();
            //Lista1.ItemsSource = teste;         
            //acessar dados gravados pelo OnSleep() da App.cs
            if (Application.Current.Properties.ContainsKey("appName"))
            {
                var nameApp = Application.Current.Properties["appName"];
                //lblWelcome.Text = nameApp.ToString();
            }

            LoadMovies();
            BindingContext = Filmes;
        }

        private void LoadMovies()
        {
            int count = 1;

            do
            {
                Filmes.Add(new Movie
                {
                    Title = "O Pianista",
                    BackgroundImage = "pianista.jpg"
                });

                count++;
            } while (count==10);

        }

        private void PopularLista()
        {
            teste.Add(1);
            teste.Add(2);
            teste.Add(3);
            teste.Add(4);
            teste.Add(1);
            teste.Add(2);
            teste.Add(3);
            teste.Add(4);
            teste.Add(1);
            teste.Add(2);
            teste.Add(3);
            teste.Add(4);
            teste.Add(1);
            teste.Add(2);
            teste.Add(3);
            teste.Add(4);

        }




        public async void FotoTapped(object sender, EventArgs e)
        {
            var id = (CachedImage)sender;
            await Navigation.PushAsync(new MovieDetail());
            await DisplayAlert("Imagem Clicada", "", "OK");
        }


    }
}
