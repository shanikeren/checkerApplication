using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using checkerApplication.Models;
using System.Runtime.CompilerServices;

namespace checkerApplication.ViewModels
{
    public class SignUpViewModel : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        public ManagerOptionsPage menagerOptionsPage = new ManagerOptionsPage();

        public event PropertyChangedEventHandler PropertyChanged;

        public void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var hendler = PropertyChanged;
            hendler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string Email;
        public string email
        {
            get => Email;
            set
            {
                if (Email != value) { Email = value; }
                onPropertyChanged();
            }
        }
        private string ReEmail;
        public string reEmail
        {
            get => ReEmail;
            set
            {
                if (ReEmail != value) { ReEmail = value; }
                onPropertyChanged();
            }
        }
        private string Password;
        public string password
        {
            get => Password;
            set
            {
                if (Password != value) { Password = value; }
                onPropertyChanged();
            }
        }
        private string RePassword;
        public string rePassword
        {
            get => RePassword;
            set
            {
                if (RePassword != value) { RePassword = value; }
                onPropertyChanged();
            }
        }
        private string RestName;
        public string restName
        {
            get => RestName;
            set
            {
                if (RestName != value) { RestName = value; }
                onPropertyChanged();
            }
        }



        protected override void Invoke(ImageButton sender)
        {

        }

        public Command SignCommand { get; }

        public SignUpViewModel()
        {
            SignCommand = new Command(async () =>
            {

                if (makeRest())
                {
              //      ObservableCollection<Restaurant> res = new ObservableCollection<Restaurant>(await App.restaurantDataStore.GetItemsAsync());
                     
                    await App.restaurantDataStore.AddItemAsync(App.restaurant);
                    await Application.Current.MainPage.Navigation.PushAsync(menagerOptionsPage);
                }
            });
        }
        private bool makeRest()
        {
            try
            {
                if (email.Equals(reEmail) && password.Equals(rePassword))
                {
                    App.restaurant = new Restaurant(restName, email, password);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}