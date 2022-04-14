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
    public class MainPageViewModel : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        public Command LogInCommand { get; set; }
        public Command SignUpCommand { get; set; }
        public ObservableCollection<string> AllNotes { get; set; } = new ObservableCollection<string>();
        string _mUserName;
        private string _mPassword;
        public MainPageViewModel()
        {
            LogInCommand = new Command(async () => {
                var OptionsVM = new OptionsPageViewModel();
                var OptionsPage = new OptionsPage();
                OptionsPage.BindingContext = OptionsVM;
                await Application.Current.MainPage.Navigation.PushAsync(OptionsPage);
            });

            SignUpCommand = new Command(async () => {
                var SignUpVM = new SignUpViewModel();
                var SignUpPage = new SignUpPage();
                SignUpPage.BindingContext = SignUpVM;
                await Application.Current.MainPage.Navigation.PushAsync(SignUpPage);
            });
        }

        public string ShowIcon { get; set; }
        public string HideIcon { get; set; }

        bool _hidePassword = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            get => _mUserName;
            set
            {
                _mUserName = value;
                var args = new PropertyChangedEventArgs(nameof(UserName));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public bool HidePassword
        {
            set
            {
                if (_hidePassword != value)
                {
                    _hidePassword = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HidePassword)));
                }
            }
            get => _hidePassword;
        }
        public string Password
        {
            get => _mPassword;
            set
            {
                _mPassword = value;
                var args = new PropertyChangedEventArgs(nameof(Password));
                PropertyChanged?.Invoke(this, args);
            }
        }
        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }
       

    }
}