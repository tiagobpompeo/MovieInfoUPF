using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesInfo.LottieAnimation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimacaoLottie : ContentPage
    {
        public AnimacaoLottie()
        {
            InitializeComponent();
        }

        private void Handle_OnFinish(object sender, System.EventArgs e)
        {
            //DisplayAlert($"{nameof(animationView.OnFinish)} invoked!");
        }

    }

    //https://www.lottiefiles.com/?page=13
}