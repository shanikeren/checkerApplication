using Microsoft.AspNetCore.SignalR.Client;
using checkerApplication.Services;
using checkerApplication.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using checkerApplication.Models;
namespace checkerApplication
{
    public partial class App : Application
    {
        public static Restaurant restaurant = new Restaurant();
       
        public MainPage mainPage = new MainPage();
        public static RestaurantDataStore restaurantDataStore { get; private set; }
        public static HttpClient client { get; private set; }
        public static DishDataStore dishData { get; private set; }
        public static ServingAreaDataStore servingAreaDataStore { get; private set; }
        public static LineDataStore lineDataStore { get; private set; }
        public static RestMenuDataStore restMenuDataStore { get; private set; }
        public static MakerDataStore makerDataStore { get; private set; }
        private readonly HttpClientHandler handler = new HttpClientHandler();

        // so the app can work for both the Android and not Android Platforms
        private string BaseAddress =
    DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7059" : "https://localhost:7059";

        public App()
        {
            bool isDebug = false;

            InitializeComponent();
            
            // registering DataStore to be able to send HTTP things
            DependencyService.Register<DishDataStore>();
            DependencyService.Register<RestaurantDataStore>();
            DependencyService.Register<ServingAreaDataStore>();
            DependencyService.Register<LineDataStore>();
            DependencyService.Register<RestMenuDataStore>();
            DependencyService.Register<MakerDataStore>();
            // makes SSL certificate for using localhost at debug
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            
#if DEBUG
            isDebug = true;
#endif
            // creating the client as needed with baseAddress
            client = isDebug ? new HttpClient(handler) : new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);
            client.Timeout = new TimeSpan(0, 0, 30);

            dishData = new DishDataStore();
            restaurantDataStore = new RestaurantDataStore();
            servingAreaDataStore = new ServingAreaDataStore();
            lineDataStore = new LineDataStore();
            restMenuDataStore = new RestMenuDataStore();
            makerDataStore = new MakerDataStore();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(mainPage) { };

            /*MainPage = new NavigationPage(new test()) {
                BarBackgroundColor = Color.DarkBlue,BarTextColor = Color.White
            };*/
        }


        protected override async void OnStart()
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
