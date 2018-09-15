using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesInfo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //acessar dados gravados pelo OnSleep() da App.cs
            if (Application.Current.Properties.ContainsKey("appName"))
            {
                var nameApp = Application.Current.Properties["appName"];
                lblWelcome.Text = nameApp.ToString();

            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
