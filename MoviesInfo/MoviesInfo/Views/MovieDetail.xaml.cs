using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesInfo.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviesInfo.Data;

namespace MoviesInfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetail : ContentPage
	{
        readonly MoviesDetailsManager managerMoviesDetail = new MoviesDetailsManager();

		public MovieDetail (string id)
		{
			InitializeComponent ();
			LoadDetails(id);
		}


		public async void LoadDetails(string id)
		{
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