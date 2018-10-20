using MoviesInfo.Layouts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        //readonly IList<ItemsMenu> MenuItems = new ObservableCollection<ItemsMenu>();
        private ObservableCollection<ItemsMenu> _menuItems;


        public Menu()
        {
            InitializeComponent();
            Loadmenu();
            BindingContext = _menuItems;
        }

        public void Loadmenu()
        {

            _menuItems = new ObservableCollection<ItemsMenu>()
            {
                new ItemsMenu()
                {
                    Title = "Main Page",
                    Icon = "download",
                    Id=0
                },
                new ItemsMenu(){
                    Title = "Tipos Layouts",
                    Icon = "download",
                    Id=1
                },
                new ItemsMenu(){
                    Title = "Meu Filme Favorito",
                    Icon = "download",
                    Id=2
                },
                 new ItemsMenu(){
                    Title = "Calculadora no Codigo",
                    Icon = "download",
                    Id=3
                },
                 new ItemsMenu(){
                    Title = "Calculadora no XAML",
                    Icon = "download",
                    Id=4
                },
                 new ItemsMenu(){
                    Title = "Cadastro",
                    Icon = "download",
                    Id=5
                },
                 new ItemsMenu(){
                    Title = "StackLayout Demonstracao",
                    Icon = "download",
                    Id=6
                },
                new ItemsMenu(){
                    Title = "OnPlatform",
                    Icon = "download",
                    Id=7
                }

            };


        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            var itemClicado = e.Item as ItemsMenu;
            int caseSwitchId = itemClicado.Id;

            switch (caseSwitchId)
            {
                case 0:
                    await Navigation.PushModalAsync(new MasterDetail(0));
                    break;
                case 1:
                    await Navigation.PushModalAsync(new MasterDetail(1));
                    break;

                case 2:
                    await Navigation.PushModalAsync(new MasterDetail(2));
                    break;

                case 3:
                    await Navigation.PushModalAsync(new MasterDetail(3));
                    break;

                case 4:
                    await Navigation.PushModalAsync(new MasterDetail(4));
                    break;

                case 5:
                    await Navigation.PushModalAsync(new MasterDetail(5));
                    break;
                case 6:
                    await Navigation.PushModalAsync(new MasterDetail(6));
                    break;
                case 7:
                    await Navigation.PushModalAsync(new MasterDetail(7));
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }
    }
}