using Microsoft.AspNetCore.SignalR.Client;
using checkerApplication.Services;
using checkerApplication.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using CheckerDTOs;
using System.Text.Json;
using System.Collections.Generic;

namespace checkerApplication
{
    public partial class App : Application
    {
        public static HubConnection HubConn { get; private set; }
        public MainPage mainPage = new MainPage();
        CheckerHttpClient checkerHttpClient = new CheckerHttpClient("http://localhost:7059");
        List<Restaurant> restaurants = new List<Restaurant>();

        public App()
        {
            InitializeComponent();


            HubConn = new HubConnectionBuilder()
                .WithUrl("http://localhost:7059/restaurants")
                .Build();

            HubConn.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await HubConn.StartAsync();

            };

            _ = GetItemsAsync();
            Console.WriteLine(restaurants);
           /* MainPage = new NavigationPage(new MainPage()) { };
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(mainPage) {
                BarBackgroundColor = Color.DarkBlue,BarTextColor = Color.White
            };*/
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

        public async Task<IEnumerable<Restaurant>> GetItemsAsync(bool forceRefresh = false)
        {
            // generate the response into a ToDoList object (list of the DTO with prettier printing)
            /*HttpResponseMessage res = (await client.SendRequest());
            if (res.IsSuccessStatusCode)
            {
                HttpContent content = res.Content;

                List<ToDo> listy = JsonSerializer.Deserialize<List<ToDo>>(await content.ReadAsStringAsync());
                return listy;
            }
            else
            {
                return new List<ToDo>();
            }*/
            restaurants = JsonSerializer.Deserialize<List<Restaurant>>(await checkerHttpClient.SendRequest());
            return restaurants;
        }

    }
}
