using System;
using System.Collections.Generic;
using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.PagineLogIn;

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
            /*if (!String.IsNullOrEmpty(Email.Text) && !String.IsNullOrEmpty(Password.Text))
            {
                Errore_Password.IsVisible = false;
                Console.WriteLine("stampa: " + Email.Text + Password.Text);
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                if(String.IsNullOrEmpty(Email.Text))
                {
                    Errore_Email.IsVisible = true;
                }
                else
                {
                    Errore_Email.IsVisible = false;
                }

                if(String.IsNullOrEmpty(Password.Text))
                {
                    Errore_Password.IsVisible = true;
                }
                else
                {
                    Errore_Password.IsVisible = false;
                }
            }
            */

            /*List<Utente> listaUtenti = new List<Utente>(await repository.GetAll());
            Utente ut = null;
            foreach (Utente utente in listaUtenti)
            {
                if(utente.Email == Email.Text)
                {
                    ut = utente;
                }
            }

            if(ut == null)
            {
                await DisplayAlert("Errore", "Email errata", "OK");
            }

            else
            {
                if(ut.Password == Password.Text.GetHashCode())
                {
                    descrizioneUtente = ut.Name + " " + ut.Surname;
                    Errore_Password.IsVisible = false;
                    Console.WriteLine("stampa: " + Email.Text + Password.Text);
                    await Navigation.PushAsync(new HomePage(descrizioneUtente));
                }

                else
                {
                    await DisplayAlert("Errore", "Password errata", "OK");
                }
            }*/

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
