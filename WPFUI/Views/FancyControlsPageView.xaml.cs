using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFUI.ViewModels;

namespace WPFUI.Views
{
    /// <summary>
    /// Interaction logic for FancyControlsPageView.xaml
    /// </summary>
    public partial class FancyControlsPageView : UserControl, IFancyControlsPageView
    {
        public FancyControlsPageView()
        {
            Debug.WriteLine("Info: FancyControlsPageView instantiated");
            ViewModel = new FancyControlsPageViewModel(this);
            InitializeComponent();
        }

        FancyControlsPageViewModel _viewModel;
        public FancyControlsPageViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }
    }
}
