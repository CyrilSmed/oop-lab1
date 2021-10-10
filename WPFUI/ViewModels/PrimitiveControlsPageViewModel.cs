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
        public PrimitiveControlsPageViewModel() 
        {
            Debug.WriteLine("Info: PrimitiveControlsPageViewModel instantiated");
        }
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



        private CreativeColorSelectionHandler colorHandler = new CreativeColorSelectionHandler();
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


        #region WPF Binding
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
