﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace notenote
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void StackPanel_Tap(object sender, GestureEventArgs e)
        {
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NoteViewModel _selectedItem = (sender as ListBox).SelectedItem as NoteViewModel;
            
            ((ListBox)sender).SelectedIndex = -1;

            NavigationService.Navigate(new Uri("/Views/Note.xaml", UriKind.Relative));
            FrameworkElement root = Application.Current.RootVisual as FrameworkElement;
            root.DataContext = _selectedItem;
        }

        private void appbar_button1_Click(object sender, EventArgs e)
        {
            NoteViewModel _newItem = App.ViewModel.AddNew("new note", "");
            
            NavigationService.Navigate(new Uri("/Views/Note.xaml", UriKind.Relative));
            FrameworkElement root = Application.Current.RootVisual as FrameworkElement;
            root.DataContext = _newItem;
        }
    }
}