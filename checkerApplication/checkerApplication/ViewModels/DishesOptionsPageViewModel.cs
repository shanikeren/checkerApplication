using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    public class DishesOptionsPageViewModel : ContentPage
    {
        public AddDishesPage addDishesPage = new AddDishesPage();
        public UpdateDishesPage updateDishesPage = new UpdateDishesPage();

        public Command AddDishesCommand { get; }
        public Command UpdateOrRremoveCommand { get; }
        public ObservableCollection<string> AllNotes { get; set; } = new ObservableCollection<string>();

        public Command GoBackCommand { get; }

        public DishesOptionsPageViewModel()

        {
            AddDishesCommand = new Command(async () => {
                addDishesPage.BindingContext = App.addDishesViewModel;
                await Application.Current.MainPage.Navigation.PushAsync(addDishesPage);
            });

            UpdateOrRremoveCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushAsync(updateDishesPage);
            });
        }
    }
}