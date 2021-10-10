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
using WPFUI.Handlers.PrimitiveControlsHandlers;

namespace WPFUI.Views
{
    /// <summary>
    /// Interaction logic for PrimitiveControlsPageView.xaml
    /// </summary>
    public partial class PrimitiveControlsPageView : UserControl, IPrimitiveControlsPageView
    {
        PrimitiveControlsPageViewModel _viewModel;
        public PrimitiveControlsPageViewModel ViewModel 
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
        public PrimitiveControlsPageView()
        {
            Debug.WriteLine("Info: PrimitiveControlsPageView instantiated");
            ViewModel = new PrimitiveControlsPageViewModel(this);
            InitializeComponent();

            panelCreativeColors.Visibility = Visibility.Hidden;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            // Super ugly and it smells too
            if (ViewModel.Name == "")
            {
                textBoxName.Background = FindResource("AccentNegative") as SolidColorBrush;
            }
            else if(ViewModel.Surname == "")
            {
                textBoxSurname.Background = FindResource("AccentNegative") as SolidColorBrush;
            }
            else if(checkBoxAgree.IsChecked == false)
            {
                checkBoxAgree.Background = FindResource("AccentNegative") as SolidColorBrush;
            }
            else
            {
                textBoxName.Background = FindResource("DarkAccent") as SolidColorBrush;
                textBoxSurname.Background = FindResource("DarkAccent") as SolidColorBrush;
                checkBoxAgree.Background = FindResource("DarkAccent") as SolidColorBrush;

                panelCreativeColors.Visibility = Visibility.Visible;
                panelRegistration.IsEnabled = false;
            }
        }

        private void buttonBlue_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectColor(CreativeColorSelectionHandler.Color.Blue);
            borderBlue.Background = FindResource("Blue") as SolidColorBrush;
            borderRed.Background = FindResource("DarkRed") as SolidColorBrush;
            borderGreen.Background = FindResource("DarkGreen") as SolidColorBrush;
        }

        private void buttonRed_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectColor(CreativeColorSelectionHandler.Color.Red);
            borderBlue.Background = FindResource("DarkBlue") as SolidColorBrush;
            borderRed.Background = FindResource("Red") as SolidColorBrush;
            borderGreen.Background = FindResource("DarkGreen") as SolidColorBrush;
        }

        private void buttonGreen_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectColor(CreativeColorSelectionHandler.Color.Green);
            borderGreen.Background = FindResource("DarkGreen") as SolidColorBrush;
        }

    }
}
