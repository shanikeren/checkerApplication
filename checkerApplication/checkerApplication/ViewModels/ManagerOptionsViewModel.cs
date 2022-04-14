using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    internal class ManagerOptionsViewModel
    {
        public Command UpdateLinesCommand { get; set; }
        public Command UpdateMenuCommand { get; set; }
        public Command UpdateIngredientsCommand { get; set; }
        public Command DiniedDishesCommand { get; set; }
        public Command StatisitcsCommand { get; set; }


        public ManagerOptionsViewModel()
        {
            UpdateLinesCommand = new Command(async () => {
                var UpdateLinesVM = new UpdateLinesViewModel();
                var UpdateLinesPage = new UpdateLinesPage();
                UpdateLinesPage.BindingContext = UpdateLinesVM;
                await Application.Current.MainPage.Navigation.PushAsync(UpdateLinesPage);
            });

            UpdateMenuCommand = new Command(async () => {
                var UpdateMenuVM = new UpdateMenuViewModel();
                var UpdateMenuPage = new UpdateMenuPage();
                UpdateMenuPage.BindingContext = UpdateMenuVM;
                await Application.Current.MainPage.Navigation.PushAsync(UpdateMenuPage);
            });

            StatisitcsCommand = new Command(async () => {
                var loggedVm = new OptionsPageViewModel();
                var loggedPage = new OptionsPage();
                loggedPage.BindingContext = loggedVm;
                await Application.Current.MainPage.Navigation.PushAsync(loggedPage);
            });

            DiniedDishesCommand = new Command(async () => {
                var loggedVm = new SignUpViewModel();
                var loggedPage = new SignUpPage();
                loggedPage.BindingContext = loggedVm;
                await Application.Current.MainPage.Navigation.PushAsync(loggedPage);
            });
            UpdateIngredientsCommand = new Command(async () => {
                var loggedVm = new OptionsPageViewModel();
                var loggedPage = new OptionsPage();
                loggedPage.BindingContext = loggedVm;
                await Application.Current.MainPage.Navigation.PushAsync(loggedPage);
            });
        }
    }
}
