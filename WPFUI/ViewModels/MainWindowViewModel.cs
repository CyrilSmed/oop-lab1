using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFUI.Views;
using System.Diagnostics;

namespace WPFUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                RaisePropertyChanged();
            }
        }

        public PrimitiveControlsPageView PrimitiveControlsView { get; set; }

        public IMainWindow View { get; set; }

        public MainWindowViewModel() 
        {
            Debug.WriteLine("Info: MainWindowViewModel instantiated");

            PrimitiveControlsView = new PrimitiveControlsPageView();
            CurrentView = PrimitiveControlsView;
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
