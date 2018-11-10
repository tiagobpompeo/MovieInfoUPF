using System;
using System.Collections.Generic;
using MoviesInfo.ViewModels;
using Xamarin.Forms;

namespace MoviesInfo.Views
{
    public partial class MainPageByVM : ContentPage
    {
        public MainPageByVM()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
