using checkerApplication.Models;
using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    internal class AddDishesViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var hendler = PropertyChanged;
            hendler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Command SubmitAllCommand { get; set; }
        public Command AddDishCommand { get; set; }
        public List<string> types
        {
            get
            {
                return Enum.GetNames(typeof(DishType)).ToList();
            }
        }
        private DishType SelectedDishType;
        public DishType selectedDishType
        {
            get
            {
                return SelectedDishType;
            }
            set
            {
                if(SelectedDishType != value) { SelectedDishType = value; }
            }
        }

        //public List<string> makers
        //{
        //    get
        //    {
        //        if (App.restaurant.makers != null)
        //        {
        //            return App.restaurant.makers.Select(x => x.name).ToList();
        //        }
        //        else return null;
        //    }
        //}
        public List<string> lines { get; set; }
        private string DishName;
        public string dishName
        {
            get => DishName;
            set
            {
                if(DishName!= value) { DishName = value; }
                onPropertyChanged();
            }
        }
        private int DishPrice;
        public int dishPrice
        {
            get => DishPrice;
            set
            {
                if (DishPrice != value) { DishPrice = value; }
                onPropertyChanged();
            }
        }
        private string DishDesc;
        public string dishDesc
        {
            get => DishDesc;
            set
            {
                if (DishDesc != value) { DishDesc = value; }
                onPropertyChanged();
            }
        }
        private int DishMakerFit;
        public int dishMakerFit
        {
            get => DishMakerFit;
            set
            {
                if (DishMakerFit != value) { DishMakerFit = value; }
                onPropertyChanged();
            }
        }
        public AddDishesViewModel()
        {
            if (App.restaurant.servingAreas.Count != 0)
            {
                lines = App.restaurant.servingAreas.Select(x => x.name).ToList();
            }
            SubmitAllCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            AddDishCommand = new Command(async () =>
            {
                Dish dish = new Dish(1, 1,SelectedDishType, DishPrice, dishName, DishDesc);
                await App.dishData.AddItemAsync(dish);
            });
        }
    }
}
