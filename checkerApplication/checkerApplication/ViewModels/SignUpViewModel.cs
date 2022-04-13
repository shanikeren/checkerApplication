using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    public class SignUpViewModel : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> UserDetails { get; set; } = new ObservableCollection<string>();
        public Command SignCommand { get; }
        public Command ReturnCommand { get; }


        private string _mTempUserName;
        private string _mTempPassword;
        private string _mTempEmail;
        public string TempUserName
        {
            get => _mTempUserName;
            set
            {
                _mTempUserName = value;
                var args = new PropertyChangedEventArgs(nameof(TempUserName));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string TempEmail
        {
            get => _mTempEmail;
            set
            {
                _mTempEmail = value;
                var args = new PropertyChangedEventArgs(nameof(TempEmail));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string TempPassword
        {
            get => _mTempPassword;
            set
            {
                _mTempPassword = value;
                var args = new PropertyChangedEventArgs(nameof(TempPassword));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string ShowIcon { get; set; }
        public string HideIcon { get; set; }

        bool _hidePassword = true;


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

        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }
        public SignUpViewModel()
        {
            /*SignCommand = new Command(async () =>
            {
                //Check if to last notes are good user name and password if so next page?
                // else -Bad

                /*var loggedVm = new ManagerOptionsPageViewModel();
                var loggedPage = new ManagerOptionsPage();
                loggedPage.BindingContext = loggedVm;
                await Application.Current.MainPage.Navigation.PushAsync(loggedPage);
            });

            ReturnCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });*/
        }
    }
}