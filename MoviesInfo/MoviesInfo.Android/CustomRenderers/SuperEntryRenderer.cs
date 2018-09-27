using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using MoviesInfo.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(SuperEntryRenderer))]
namespace MoviesInfo.Droid.CustomRenderers
{
    public class SuperEntryRenderer : EntryRenderer
    {
        public SuperEntryRenderer(Context context) : base(context)
        {

        }


        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if ((this.Control.Background != null) && (Control != null))
            {
                //this.Control.Background = Resources.GetDrawable(Resource.Drawable.RoundedEntry);          
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(4); // increase or decrease to changes the corner look
                gd.SetColor(Android.Graphics.Color.White);
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
            }
        }
    }
}