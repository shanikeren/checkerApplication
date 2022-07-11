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
        public ObservableCollection<string> outlines { get; set; }
        public ObservableCollection<string> lines { get; set; }

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
        public string outlineName {
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

        private string SelectedOutline;
        public string selectedOutline
        {
            get => SelectedOutline;
            set
            {
                if(SelectedOutline != value) { SelectedOutline = value; }
                onPropertyChanged();
            }
        }

        private string MakerName;
        public string makerName
        {
            get => MakerName;
            set
            {
                if (MakerName != value) { MakerName = value; }
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
      
        public UpdateLinesViewModel()
        {
            outlines = new ObservableCollection<string>();
            lines = new ObservableCollection<string>();

            SubmitCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            addOutlineCommand = new Command(async () =>
            {
                if (OutlineName != null)
                {
                    ServingArea serving = new ServingArea(App.restaurant.id, OutlineLimit, OutlineName);
                    bool res = await App.servingAreaDataStore.AddItemAsync(serving);

                    if (res)
                    {
                        updateServingAreas();
                        outlineLimit = 0;
                        outlineName = null;
                    }
                }
            });

            addLineCommand = new Command(async () =>
            {
                if (LineName != null && lineLimit != 0)
                {
                    int outlineid = getOutlineId(selectedOutline);
                    Line line = new Line(lineLimit, lineName, outlineid);
                   

                    bool res = await App.lineDataStore.AddItemAsync(line);
                    if (res)
                    {
                        updateLines();
                        lineLimit = 0;
                        lineName = null;
                        selectedOutline = null;
                        App.addDishesViewModel.updateLines();
                    }
                }
            });

            addMakerCommand = new Command(async () =>
            {
                int lineId = getLineId(selectedLine);
                Maker maker = new Maker(MakerName, lineId);
                bool res = await App.makerDataStore.AddItemAsync(maker);
                if (res)
                {
                    selectedLine = null;
                    makerName = null;
                    App.addDishesViewModel.updateMakers();
                }
            });
        }

        public int getOutlineId(string outline)
        {
            foreach (ServingArea servingArea in App.restaurant.servingAreas)
            {
                if (servingArea.name.Equals(outline)) { return servingArea.id; }
            }
            return -1;

        }
        public int getLineId(string lineToGet)
        {
            foreach (Line line in App.restaurant.lines)
            {
                if (line.name.Equals(lineToGet)) { return line.id; }
            }
            return -1;

        }

        public void updateServingAreas()
        {
            foreach (ServingArea servingArea in App.restaurant.servingAreas)
            {
                if (!outlines.Contains(servingArea.name))
                {
                    outlines.Add(servingArea.name);
                }
            }
        }

        public void updateLines()
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
}



