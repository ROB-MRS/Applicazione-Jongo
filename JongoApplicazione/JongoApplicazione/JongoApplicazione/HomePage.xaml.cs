using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void Button_1_Clicked(System.Object sender, System.EventArgs e)
        {
            
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new PagineLogIn.PageIscrizione()));
        }

        void Bottone_Impostazioni_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new SettingsPage()));
        }

        void Bottone_Contattaci(System.Object sender, System.EventArgs e)
        {
          
        }
    }
}
