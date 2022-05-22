using System;
using System.Collections.Generic;
using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.PagineLogIn;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JongoApplicazione
{
    public partial class LogInPage : ContentPage
    {   
        RepositoryUtente repository = new RepositoryUtente();
        string descrizioneUtente;

        public LogInPage()
        {   
            InitializeComponent();
        }

        //Bottone per mostrare la Password
        void bottone_password_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Password.IsPassword)
            {
                Password.IsPassword = false;
                Bottone_password.Source = "occhioaperto.png";
            }
            else
            {
                Password.IsPassword = true;
                Bottone_password.Source = "occhiochiuso.png";
            }
        }

        //Bottone di Recupero Password
        void Bottone_Recupero_Password_Cliccato(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageRecuperoPassword());
        }

        //Bottone di Iscrizione
        void Bottone_Iscrizione(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageIscrizione());
        }


        //Bottone di Log In
        async void Bottone_Log_In_Cliccato(System.Object sender, System.EventArgs e)
        {
            
            if (string.IsNullOrEmpty(Email.Text))
            {
                await DisplayAlert("Errore", "Inserisci l'email", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Password.Text))
            {
                await DisplayAlert("Errore", "Inserisci la password", "OK");
                return;
            }
            try
            {
                string token = await repository.SignIn(Email.Text, Password.Text);
                if (!string.IsNullOrEmpty(token))
                {
                    List<Utente> listaUtenti = new List<Utente>(await repository.GetAll());
                    Utente ut = null;
                    foreach (Utente utente in listaUtenti)
                    {
                        if (utente.Email == Email.Text)
                        {
                            ut = utente;
                        }
                    }
                    Preferences.Set("token", token);
                    Errore_Password.IsVisible = false;
                    Console.WriteLine("stampa: " + Email.Text + Password.Text);
                    await Navigation.PushAsync(new HomePage(ut));
                }


            }
            
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    await DisplayAlert("Errore", "Email sbagliata", "OK");
                }
                else
                {
                    await DisplayAlert("Errore", "Password errata", "OK");
                }
            }
            
            
        }

    }
}
