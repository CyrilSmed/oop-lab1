using System;
using System.Collections.Generic;
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
    /// Interaction logic for PrimitiveControlsPageView.xaml
    /// </summary>
    public partial class PrimitiveControlsPageView : UserControl
    {
        public PrimitiveControlsPageViewModel PrimitiveControlsVM { get; set; }
        public PrimitiveControlsPageView()
        {
            InitializeComponent();
            PrimitiveControlsVM = new PrimitiveControlsPageViewModel();
        }

        private void buttonBlue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonRed_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonGreen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
