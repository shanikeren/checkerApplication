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

namespace checkerApplication
{
    public partial class App : Application
    {
        // public static HubConnection HubConn { get; private set; }
       
        public MainPage mainPage = new MainPage();
        public static HttpClient client { get; private set; }
        public static DishDataStore dishData { get; private set; }
        private readonly HttpClientHandler handler = new HttpClientHandler();
        // List<Restaurant> restaurants = new List<Restaurant>();

        // so the app can work for both the Android and not Android Platforms
        private string BaseAddress =
    DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7059" : "https://localhost:7059";

        public App()
        {
            bool isDebug = false;

            InitializeComponent();
            
            // registering DataStore to be able to send HTTP things
            DependencyService.Register<DishDataStore>();

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



            /*   HubConn = new HubConnectionBuilder()
                   .WithUrl("http://localhost:7059/restaurants")
                   .Build();

               HubConn.Closed += async (error) =>
               {
                   await Task.Delay(new Random().Next(0, 5) * 1000);
                   await HubConn.StartAsync();

               };*/
            /*Task<IEnumerable<Restaurant>> task = GetItemsAsync();*/

//            System.Console.WriteLine("ssss");
           MainPage = new NavigationPage(new test()) { };

           /* DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new test()) {
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

        
       /* private async Task<IEnumerable<Restaurant>> GetItemsAsync(bool forceRefresh = false)
        {
            // generate the response into a ToDoList object (list of the DTO with prettier printing)
            HttpResponseMessage res = (await client.SendRequest());
            if (res.IsSuccessStatusCode)
            {
                HttpContent content = res.Content;

                List<ToDo> listy = JsonSerializer.Deserialize<List<ToDo>>(await content.ReadAsStringAsync());
                return listy;
            }
            else
            {
                return new List<ToDo>();
            }
            restaurants = JsonSerializer.Deserialize<List<Restaurant>>(await checkerHttpClient.SendRequest());
            return restaurants;
        }*/

    }
}
