using checkerApplication.ViewModels;
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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Grid.SetRow(SL1, 2);
                    break;
                case Device.Android:
                    Cover.WidthRequest = 395;
                    break;
                case Device.UWP:
                    Cover.WidthRequest = 700;
                    break;
            }



        }
    }
}