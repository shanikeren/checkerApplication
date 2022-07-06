using checkerApplication.Models;
using checkerApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace checkerApplication.ViewModels
{
    internal class UpdateLinesViewModel : INotifyPropertyChanged
    {
        public IList<string> outlines { get; set; }
        public Command SubmitCommand { get; }
        public Command addOutlineCommand { get; }
        public Command addLineCommand { get; }
        public Command addMakerCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var hendler = PropertyChanged;
            hendler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string OutlineName;
        public string outlineName{
            get => OutlineName;
            set
            {
                if (OutlineName != value) { OutlineName = value; }
                onPropertyChanged();
            }
        }
        private int OutlineLimit;
        public int outlineLimit
        {
            get => OutlineLimit;
            set
            {
                if (OutlineLimit != value) { OutlineLimit = value; }
                onPropertyChanged();
            }
        }
        private int LineLimit;
        public int lineLimit
        {
            get => LineLimit;
            set
            {
                if (LineLimit != value) { LineLimit = value; }
                onPropertyChanged();
            }
        }

        private string LineName;
        public string lineName
        {
            get => LineName;
            set {
                if (LineName != value) { LineName = value; }
                onPropertyChanged();
            }
        }
        private string MakerName;
        public string makerName
        {
            get => MakerName;
            set
            {
                if(MakerName!= value) { MakerName = value; }
                onPropertyChanged();
            }
        }
        private string MakerLine;
        public string makerLine
        {
            get => MakerLine;
            set
            {
                if(MakerLine != value) { makerLine = value; }
                onPropertyChanged();
            }
        }
        public UpdateLinesViewModel()
        {
            outlines = new List<string>();
            
            SubmitCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            addOutlineCommand = new Command(async () =>
            {
                if(OutlineName != null)
                {
                    ServingArea serving = new ServingArea(App.restaurant.id, OutlineLimit, OutlineName);
                    bool res = await App.servingAreaDataStore.AddItemAsync(serving);
                    outlineLimit = 0;
                    if (res)
                    {
                        foreach (ServingArea servingArea in App.restaurant.servingAreas)
                        {
                            outlines.Add(servingArea.name);
                        }
                        outlineName = null;
                    } 
                }
            });

            addLineCommand = new Command(async () =>
            {
                if (LineName != null && lineLimit != 0)
                {
                    Line line = new Line(lineLimit, lineName, 2);
                    bool res = await App.lineDataStore.AddItemAsync(line);
                    if (res)
                    {
                        lineLimit = 0;
                        lineName = null;
                    }
                }
            });
            addMakerCommand = new Command(async () =>
            {
                Maker maker = new Maker(MakerName, MakerLine);
                bool res = await App.makerDataStore.AddItemAsync(maker);
                if (res)
                {
                    makerLine = null;
                    makerName = null;
                }
            });
        }

     
    }
}



