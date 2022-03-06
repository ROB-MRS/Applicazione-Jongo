using JongoApplicazione.JongoApplicazione.PagineLogIn;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione
{
    public partial class HomePage : ContentPage
    {
        
        public HomePage(string utente)
        {
            InitializeComponent();
            Utente_loggato.Text = utente;
            if (Utente_loggato.Text == "---")
            {
                bottone_logout.IsVisible = false;
                bottone_login.IsVisible = true;
            }
            else
            {
                bottone_login.IsVisible=false;
                bottone_logout.IsVisible=true;
            }
        }

        void Bottone_login(System.Object sender, System.EventArgs e)
        {   
             Navigation.PushAsync(new NavigationPage(new LogInPage()));
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new PagineLogIn.PageIscrizione()));
        }

        void Bottone_logout(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new HomePage("---")));
        }

    }
}
