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

namespace checkerApplication
{
    public class Dish
    {

        public int LineId { get; set; }
        public int RestMenuId { get; set; }
        public DishType Type { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
    }
    public enum DishType
    {
        UnDefined,
        Starter,
        Main,
        Dessert
    }
    public partial class App : Application
    {
        // public static HubConnection HubConn { get; private set; }
       
        public MainPage mainPage = new MainPage();
        //CheckerHttpClient checkerHttpClient = new CheckerHttpClient("http://localhost:7059/restaurant");
       // List<Restaurant> restaurants = new List<Restaurant>();

        public App()
        {
            InitializeComponent();


            /*   HubConn = new HubConnectionBuilder()
                   .WithUrl("http://localhost:7059/restaurants")
                   .Build();

               HubConn.Closed += async (error) =>
               {
                   await Task.Delay(new Random().Next(0, 5) * 1000);
                   await HubConn.StartAsync();

               };*/
            /*Task<IEnumerable<Restaurant>> task = GetItemsAsync();*/
            System.Console.WriteLine("ssss");
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
