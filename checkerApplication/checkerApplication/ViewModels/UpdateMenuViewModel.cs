using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    internal class UpdateMenuViewModel
    {
        public Command SubmitAllCommand { get; set; }

        public UpdateMenuViewModel()
        {
            SubmitAllCommand = new Command(async () => {
                var ManagerOptionsVM = new ManagerOptionsViewModel();
                var ManagerOptionsPage = new ManagerOptionsPage();
                ManagerOptionsPage.BindingContext = ManagerOptionsVM;
                await Application.Current.MainPage.Navigation.PushAsync(ManagerOptionsPage);
            });
        }
    }
}
