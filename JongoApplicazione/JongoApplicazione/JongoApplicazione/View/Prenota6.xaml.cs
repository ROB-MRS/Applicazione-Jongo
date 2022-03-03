using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota6 : ContentView
    {
        public Prenota6()
        {
            InitializeComponent();
        }
        void Button_OK_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new HomePage()));

        }
    }
}
