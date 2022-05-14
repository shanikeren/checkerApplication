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
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }
    }
}
