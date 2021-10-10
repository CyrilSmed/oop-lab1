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

            foreach (Border border in gridColorUtilization.Children)
            {
                border.MouseEnter += panel_MouseEnter;
            }


            //TODO: where to do that
            panelCreativeColors.Visibility = Visibility.Hidden;
            panelColorAmplification.Visibility = Visibility.Hidden;
            panelColorUtilization.Visibility = Visibility.Hidden;
        }

        private void submitRegistration_Click(object sender, RoutedEventArgs e)
        {
            // TODO: how to properly validate fields
            SolidColorBrush highlightColor = FindResource("AccentNegative") as SolidColorBrush;
            SolidColorBrush defaultColor = FindResource("DarkAccent") as SolidColorBrush;

            if (ViewModel.Name == "")
            {
                textBoxName.Background = highlightColor;
            }
            else if(ViewModel.Surname == "")
            {
                textBoxSurname.Background = highlightColor;
            }
            else if(checkBoxAgree.IsChecked == false)
            {
                checkBoxAgree.Background = highlightColor;
            }
            else
            {
                textBoxName.Background = defaultColor;
                textBoxSurname.Background = defaultColor;
                checkBoxAgree.Background = defaultColor;

                //TODO: Where to handle that
                panelCreativeColors.Visibility = Visibility.Visible;
            }
        }

        //TODO: How to organize highlight, dehighlight logic
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

        //TODO: Where to handle that better

        private void submitColor_Click(object sender, RoutedEventArgs e)
        {
            if(ViewModel.SelectedColor != CreativeColorSelectionHandler.Color.Undefined)
            {
                ViewModel.CreativeColorOutput = "";
                panelColorAmplification.Visibility = Visibility.Visible;
                borderChosenCreativeColor.Background = GetColor(ViewModel.SelectedColor);

                ViewModel.ColorAmplification = 0;
            }
        }

        private SolidColorBrush GetColor(CreativeColorSelectionHandler.Color color)
        {
            SolidColorBrush returnColor = new SolidColorBrush(); ;
            switch (color)
            {
                case CreativeColorSelectionHandler.Color.Blue:
                    returnColor = FindResource("Blue") as SolidColorBrush;
                    break;
                case CreativeColorSelectionHandler.Color.Red:
                    returnColor = FindResource("Red") as SolidColorBrush;
                    break;
                case CreativeColorSelectionHandler.Color.Green:
                    returnColor = FindResource("Green") as SolidColorBrush;
                    break;
            }
            return returnColor;
        }

        private void autofill_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Name = "Guest";
            ViewModel.Surname = "None";
            checkBoxAgree.IsChecked = true;
        }

        public int MaxColorAmplification
        {
            get { return (int)sliderColorAmplifier.Maximum; }
        }

        public void ColorIsAmplified(bool isAmplified)
        {
            if(isAmplified == true)
            {
                panelColorUtilization.Visibility = Visibility.Visible;
                sliderColorAmplifier.Maximum = panelColorAmplification.ActualWidth
                    - panelColorAmplification.Margin.Left - panelColorAmplification.Margin.Right;
                postAmplificationInstructionBox.Text = "Utilize your amlified creative color";
            }
            else
            {
                panelColorUtilization.Visibility = Visibility.Hidden;
                postAmplificationInstructionBox.Text = "";
            }
        }

        public void panel_MouseEnter(object sender, EventArgs e)
        {
            ((Border)sender).Background = GetColor(ViewModel.SelectedColor);
        }
    }
}
