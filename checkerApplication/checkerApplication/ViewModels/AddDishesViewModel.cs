using checkerApplication.Models;
using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    public class AddDishesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> makers { get; set; }
        public ObservableCollection<string> lines { get; set; }
        public Command SubmitAllCommand { get; set; }
        public Command AddDishCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var hendler = PropertyChanged;
            hendler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<string> types
        {
            get
            {
                return Enum.GetNames(typeof(eDishType)).ToList();
            }
        }
        private eDishType SelectedDishType;
        public eDishType selectedDishType
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
        private float DishPrice;
        public float dishPrice
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
        private float EstMakeTime;
        public float estMakeTime
        {
            get => EstMakeTime;
            set
            {
                if (EstMakeTime != value) { EstMakeTime = value; }
                onPropertyChanged();
            }
        }
        private string SelectedLine;
        public string selectedLine
        {
            get => SelectedLine;
            set
            {
                if (SelectedLine != value) { SelectedLine = value; }
                onPropertyChanged();
            }
        }
        private string SelectedMaker;
        public string selectedMaker
        {
            get => SelectedMaker;
            set
            {
                if (SelectedMaker != value) { SelectedMaker = value; }
                onPropertyChanged();
            }
        }
        public AddDishesViewModel()
        {
            updateLines();
            updateMakers();
            lines = new ObservableCollection<string>();
            makers = new ObservableCollection<string>();
            SubmitAllCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            AddDishCommand = new Command(async () =>
            {
                int lineId = getLineId(selectedLine);
                int makerId = getMakerId(selectedMaker);
                Dish dish = new Dish(lineId, App.restaurant.menus[0].id,SelectedDishType, DishPrice, dishName, DishDesc,makerId, dishMakerFit, estMakeTime);
                bool res = await App.dishData.AddItemAsync(dish);
                if (res)
                {
                    dishDesc = null; 
                    dishName = null;
                    dishPrice = 0;
                    dishMakerFit = 0;
                    estMakeTime = 0;
                    selectedDishType = eDishType.UnDefined;
                    selectedLine = null;
                    selectedMaker = null;
                }
            });
        }
        public int getLineId(string lineToGet)
        {
            foreach (Line line in App.restaurant.lines)
            {
                if (line.name.Equals(lineToGet)) { return line.id; }
            }
            return -1;

        }
        public int getMakerId(string makerToGet)
        {
            foreach (Maker maker in App.restaurant.makers)
            {
                if (maker.name.Equals(makerToGet)) { return maker.id; }
            }
            return -1;

        }
        public void updateLines()
        {
            if (App.restaurant.lines.Count != 0)
            {
                foreach (Line line in App.restaurant.lines)
                {
                    if (!lines.Contains(line.name))
                    {
                        lines.Add(line.name);
                    }
                }
            }
        }
        public void updateMakers()
        {
            if (App.restaurant.makers.Count != 0)
            {
                foreach (Maker maker in App.restaurant.makers)
                {
                    if (!makers.Contains(maker.name))
                    {
                        makers.Add(maker.name);
                    }
                }
            }
        }
    }
}
