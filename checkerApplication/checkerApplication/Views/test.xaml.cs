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
        private ObservableCollection<Restaurant> _dish;

        public test()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            _dish = new ObservableCollection<Restaurant>(await App.restaurantDataStore.GetItemsAsync());
            dishListView.ItemsSource = _dish;
            base.OnAppearing();
        }
    }
}