using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace checkerApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateLinesPage : ContentPage
    {
        public UpdateLinesPage()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    break;
                case Device.Android:
                    break;
                case Device.UWP:
                    OutlineName.WidthRequest = 205;
                    OutlineLimit.WidthRequest = 205;
                    LineName.WidthRequest = 135;
                    ChooseOutline.WidthRequest = 135;
                    LineLimit.WidthRequest = 135;
                    break;
            }
        }
    }
}
