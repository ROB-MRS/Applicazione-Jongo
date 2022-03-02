using System;
using System.Collections.Generic;
using JongoApplicazione.View;
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
            Navigation.PushAsync(new NavigationPage(new JongoApplicazione.PagePrenotazione.Page1()));

        }

        void Button_utente_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new PagineLogIn.PageIscrizione()));
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
             Navigation.PushAsync(new NavigationPage(new View.Prenota()));
        }
    }
}
