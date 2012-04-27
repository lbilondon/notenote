using System;
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
    public partial class Note : PhoneApplicationPage
    {

        public Note()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            FrameworkElement root = Application.Current.RootVisual as FrameworkElement;
            App.ViewModel.Remove(root.DataContext as NoteViewModel);
            NavigationService.GoBack();
        }
    }
}