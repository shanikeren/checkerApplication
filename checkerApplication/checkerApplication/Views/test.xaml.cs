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

namespace checkerApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class test : ContentPage
    {
        private string url = "https://localhost:7059/dishes";
        private HttpClient client = new HttpClient(); 
        private ObservableCollection<Dish> _dish;

        public test()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Dish>>(content);
            _dish = new ObservableCollection<Dish>(post); 
            postsListView.ItemsSource = _dish;
            base.OnAppearing();
        }
    }
}