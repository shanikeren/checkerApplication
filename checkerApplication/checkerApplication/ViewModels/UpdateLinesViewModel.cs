using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    internal class UpdateLinesViewModel
    {

        public Command SubmitCommand { get; }

        public UpdateLinesViewModel()
        {
            SubmitCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }
    }
}



