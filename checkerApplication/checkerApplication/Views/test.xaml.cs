using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using checkerApplication.Models;

namespace checkerApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class test : ContentPage
    {
        /*private string url = "https://localhost:44319/dishes";
        private HttpClient client = new HttpClient();*/
        private ObservableCollection<Dish> _dish;

        public test()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            /*var content = await client.GetStringAsync(url);*/
            /*var content = App.checkerHttpClient.GetStringAsync("/dishes").Result;
            var post = JsonConvert.DeserializeObject<List<Dish>>(content);*/

            _dish = new ObservableCollection<Dish>(await App.dishData.GetItemsAsync());
            dishListView.ItemsSource = _dish;
            base.OnAppearing();
            
            
        }
    }
}