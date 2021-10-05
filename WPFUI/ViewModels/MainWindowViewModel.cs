using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region private fields

        #endregion

        #region public properties
        public IMainWindow View { get; set; }
        #endregion

        public MainWindowViewModel() { }

        #region WPF Binding
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
