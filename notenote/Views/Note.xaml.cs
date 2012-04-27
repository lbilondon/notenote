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
        private string _noteID = null;

        public Note()
        {
            InitializeComponent();

            if (_noteID != null)
            {
                DataContext = App.ViewModel;
            }
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _noteID = NavigationContext.QueryString["ID"];
        }
    }
}