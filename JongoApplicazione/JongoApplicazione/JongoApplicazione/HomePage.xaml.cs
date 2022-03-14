using System;
using System.Collections.Generic;
using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.View;
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
                bottone_login.IsVisible = false;
                bottone_logout.IsVisible = true;
            }
        }

        void Button_1_Clicked(System.Object sender, System.EventArgs e)
        {
            

        }

        void Bottone_login(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }

        void Bottone_logout(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomePage("---"));
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if(Utente_loggato.Text == "---")
            {
                await DisplayAlert("Attenzione", "Per prenotare è necessario autenticarsi", "OK");
                return;
            }
            await Navigation.PushAsync(new View.Prenota());
        }

        async void bottone_cronologia(System.Object sender, System.EventArgs e)
        {
            if (Utente_loggato.Text == "---")
            {
                await DisplayAlert("Attenzione", "Per prenotare è necessario autenticarsi", "OK");
                return;
            }
            await Navigation.PushAsync(new Cronologia(Utente_loggato.Text));
        }
    }
}
