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
    public partial class UpdateMenuPage : ContentPage
    {
        public UpdateMenuPage()
        {
            InitializeComponent();

           switch (Device.RuntimePlatform)
          {
              case Device.iOS:
                  break;
              case Device.Android:
                    
                  break;
              case Device.UWP:
                    DishName.WidthRequest = 175;
                    DishDesc.WidthRequest = 175;
                    DishLine.WidthRequest = 175;
                    break;
          }
        }
    }
}