using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesInfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            InitializeComponent();
            FadeSplash();
        }

        private async void FadeSplash()
        {
            await Task.Delay(3000);
            //await Navigation.PushModalAsync(new Views.MainPage());
            await Navigation.PushModalAsync(new Views.MasterDetail(0));//passando parametro que definira a pagina que sera iniciada
        }
    }
}