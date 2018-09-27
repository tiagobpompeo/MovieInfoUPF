using MoviesInfo.Layouts;
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
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        public async void IrMainPage(object obj, EventArgs args)
        {
            await Navigation.PushModalAsync(new MasterDetail(0));
        }

        public async void IrLayouts(object obj, EventArgs args)
        {
            await Navigation.PushModalAsync(new MasterDetail(1));
        }

        public async void IrFavorito(object obj, EventArgs args)
        {
            await Navigation.PushModalAsync(new MasterDetail(2));
        }

        public async void IrPaginaCodigo(object obj, EventArgs args)
        {
            await Navigation.PushModalAsync(new MasterDetail(3));
        }

        public async void IrPaginaXaml(object obj, EventArgs args)
        {
            await Navigation.PushModalAsync(new MasterDetail(4));
        }

        public async void IrCadastro(object obj, EventArgs args)
        {
            await Navigation.PushModalAsync(new MasterDetail(5));
        }
    }
}