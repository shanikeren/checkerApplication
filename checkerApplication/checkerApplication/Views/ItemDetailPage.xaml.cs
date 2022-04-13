using checkerApplication.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace checkerApplication.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}