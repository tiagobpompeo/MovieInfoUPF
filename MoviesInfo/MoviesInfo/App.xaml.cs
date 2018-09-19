using MoviesInfo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviesInfo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SplashScreen();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
           // Handle when your app sleeps
            Application.Current.Properties["appName"] = "MoviesInfo";//gravar persistencia de dados
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
