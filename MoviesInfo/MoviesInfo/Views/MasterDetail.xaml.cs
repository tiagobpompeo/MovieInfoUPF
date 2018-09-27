using MoviesInfo.LayoutInCode;
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
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail(int page)
        {
            InitializeComponent();
            //this.Detail = new MainPage();

            if (page==0)
            {
                Detail = new NavigationPage(new MainPage());//Pagina Principal
            }

            if (page == 1)
            {
                Detail = new NavigationPage(new LayoutSamples());//Examples de Layouts
            }

            if (page == 2)
            {
                Detail = new NavigationPage(new MyFavoriteMovie());//Exercicio Meu Filme Favorita
            }
            if (page == 3)
            {
                Detail = new NavigationPage(new CalculatorInCode());//Page in Code
            }

            if (page == 4)
            {
                Detail = new NavigationPage(new Calculator());//Page in Xaml
            }

            if (page == 5)
            {
                Detail = new NavigationPage(new Cadastro());//Page in Xaml
            }

        }
    }
}