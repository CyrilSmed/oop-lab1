using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Handlers.PrimitiveControlsHandlers;

namespace WPFUI.ViewModels
{
    public class PrimitiveControlsPageViewModel : INotifyPropertyChanged
    {
        public PrimitiveControlsPageViewModel(IPrimitiveControlsPageView view)
        {
            View = view;
            Debug.WriteLine("Info: PrimitiveControlsPageViewModel instantiated");
        }

        public IPrimitiveControlsPageView View { get; set; }
        
        private string _name = "";
        public string Name 
        { 
            get { return _name; }
            set 
            {
                _name = value;
                RaisePropertyChanged();
            } 
        }

        private string _surname = "";
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                RaisePropertyChanged();
            }
        }

        private string _creativeColorOutput = "";
        public string CreativeColorOutput
        {
            get { return _creativeColorOutput; }
            set 
            {
                _creativeColorOutput = value;
                RaisePropertyChanged();
            }
        }

        private int _colorAmplification;
        public int ColorAmplification
        {
            get { return _colorAmplification; }
            set
            {
                _colorAmplification = value;
                CheckIfColorIsAmplified(_colorAmplification);
                RaisePropertyChanged();
            } 
        }

        private CreativeColorSelectionHandler colorHandler = new CreativeColorSelectionHandler();
        public CreativeColorSelectionHandler.Color SelectedColor { 
            get
            {
                return colorHandler.SelectedColor;
            }
            set
            {
                colorHandler.SelectedColor = value;
                RaisePropertyChanged();
            }
        }


        public void SelectColor(CreativeColorSelectionHandler.Color color)
        {
            CreativeColorOutput = colorHandler.SelectColorReturnResponse(color);
        }

        private void CheckIfColorIsAmplified(int value)
        {
            if(value == View.MaxColorAmplification)
            {
                View.ColorIsAmplified(true);
            }
            else
            {
                View.ColorIsAmplified(false);
            }
        }


        #region WPF Binding
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
