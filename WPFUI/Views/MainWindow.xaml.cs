﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindowViewModel ViewModel { get; set; }
        public MainWindow()
        {
            Debug.WriteLine("Info: MainWindow instantiated");

            InitializeComponent();

            ViewModel = new MainWindowViewModel();
            ViewModel.View = this;

            DataContext = ViewModel;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && Mouse.GetPosition(window).Y <= TopBar.Height)
            {
                this.DragMove();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void PrimitiveControlsPage_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentView = ViewModel.PrimitiveControlsView;
        }

        private void FancyPage_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentView = ViewModel.FancyControlsView;
        }

        private void PrivatePage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
