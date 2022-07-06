using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    internal class OptionsPageViewModel
    {

        public Command LinesCommand { get; }
        public Command ManagerOptionsCommand { get; }
        public ObservableCollection<string> AllNotes { get; set; } = new ObservableCollection<string>();
        public Command GoBackCommand { get; }
    
        public OptionsPageViewModel()

        {
            LinesCommand = new Command(async () => {
                var UpdateLinesVM = new UpdateLinesViewModel();
                var UpdateLinesPage = new UpdateLinesPage();
                UpdateLinesPage.BindingContext = UpdateLinesVM;
                await Application.Current.MainPage.Navigation.PushAsync(UpdateLinesPage);
            });

            ManagerOptionsCommand = new Command(async () => {
                var ManagerOptionsVM = new ManagerOptionsViewModel();
                var ManagerOptionsPage = new ManagerOptionsPage();
                ManagerOptionsPage.BindingContext = ManagerOptionsVM;
                await Application.Current.MainPage.Navigation.PushAsync(ManagerOptionsPage);
            });
        }
    }
}

