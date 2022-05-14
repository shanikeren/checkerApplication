using Microsoft.AspNetCore.SignalR.Client;
using checkerApplication.Services;
using checkerApplication.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using CheckerDTOs;

namespace checkerApplication
{
    public partial class App : Application
    {
        public static HubConnection HubConn { get; private set; }
        public MainPage mainPage = new MainPage();
        public App()
        {
            InitializeComponent();

            HubConn = new HubConnectionBuilder()
                .WithUrl("http://localhost:7059/restaurants")
                .Build();

            HubConn.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0,5) * 1000);
                await HubConn.StartAsync();
               
            };


            MainPage = new NavigationPage(new MainPage()) { };
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
