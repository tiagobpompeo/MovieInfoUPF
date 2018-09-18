using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesInfo.Layouts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LayoutSamples : ContentPage
	{
		public LayoutSamples ()
		{
			InitializeComponent ();
		}

        public async void ContentView(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ContentView());
        }
        public async void Frame(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Frame());
        }
        public async void ScroollView(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ScroollView());
        }

        public async void StackLayout(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new StackLayout());
        }
        public async void AbsoluteLayout(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AbsoluteLayout());
        }
        public async void Grid(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Grid());
        }
        public async void FlexLayout(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FlexLayout());
        }

        public async void RelativeLayout(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RelativeLayout());
        }
    }
}