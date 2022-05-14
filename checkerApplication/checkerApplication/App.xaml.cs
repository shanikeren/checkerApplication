using checkerApplication.Services;
using checkerApplication.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace checkerApplication
{
    public partial class App : Application
    {
        public MainPage mainPage = new MainPage();
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(mainPage) {
                BarBackgroundColor = Color.DarkBlue,BarTextColor = Color.White
            };
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
