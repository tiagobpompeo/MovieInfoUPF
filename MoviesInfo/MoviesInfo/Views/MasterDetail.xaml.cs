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
                Detail = new NavigationPage(new MainPage());//Gera o Icon Hamburger
            }

            if (page == 1)
            {
                Detail = new NavigationPage(new LayoutSamples());//Gera o Icon Hamburger
            }


        }
    }
}