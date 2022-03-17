﻿using System;
using System.Collections.Generic;
using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.View;
using Xamarin.Forms;

namespace JongoApplicazione
{
    public partial class HomePage : ContentPage
    {
        public Utente utenteHomePage;

        public HomePage(Utente utente)
        {
            InitializeComponent();
            utenteHomePage = utente;
            if (utente == null)
            {
                bottone_logout.IsVisible = false;
                bottone_login.IsVisible = true;
                Utente_loggato.Text = "---";
                
                
            }
            else
            {
                bottone_login.IsVisible = false;
                bottone_logout.IsVisible = true;
                Utente_loggato.Text = utente.Name + " " + utente.Surname;
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
            Navigation.PushAsync(new HomePage(null));
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if(Utente_loggato.Text == "---")
            {
                await DisplayAlert("Attenzione", "Per prenotare è necessario autenticarsi", "OK");
                return;
            }
            await Navigation.PushAsync(new View.Prenota(utenteHomePage));
        }

        async void bottone_cronologia(System.Object sender, System.EventArgs e)
        {
            if (Utente_loggato.Text == "---")
            {
                await DisplayAlert("Attenzione", "Per accedere alla cronologia è necessario autenticarsi", "OK");
                return;
            }
            await Navigation.PushAsync(new Cronologia(utenteHomePage));
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
