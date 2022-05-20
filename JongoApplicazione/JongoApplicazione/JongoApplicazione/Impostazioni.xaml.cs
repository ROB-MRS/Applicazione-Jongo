using JongoApplicazione.JongoApplicazione.PagineLogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JongoApplicazione.JongoApplicazione
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class Impostazioni : ContentPage
    {
        RepositoryUtente repositoryUtente = new RepositoryUtente();
        Utente utente;

        public Impostazioni(Utente utente)
        {
            InitializeComponent();
            this.utente = utente;
            Nome.Text = "•Nome: " + utente.Name;
            Cognome.Text = "•Cognome: " + utente.Surname;
            Email.Text = "•Email: " + utente.Email;
        }

        async void bottone_password(System.Object sender, System.EventArgs e)
        {
            string password = await DisplayPromptAsync("Informazione", "Inserisci la tua vecchia password");
            if (password != null)
            {
                try
                {
                    string tok = await repositoryUtente.SignIn(utente.Email, password);
                    if (!string.IsNullOrEmpty(tok))
                    {
                        string nuovaPassword = await DisplayPromptAsync("Informazione", "Inserisci la nuova password");
                        if (nuovaPassword != null)
                        {
                            string token = Preferences.Get("token", "");
                            string newToken = await repositoryUtente.ChangePassword(token, nuovaPassword);
                            if (!string.IsNullOrEmpty(newToken))
                            {
                                await DisplayAlert("Informazione", "Password cambiata con successo", "OK");
                            }
                            else
                            {
                                await DisplayAlert("Errore", "Password non cambiata", "OK");
                            }
                        }

                    }
                }

                catch (Exception ex)
                {
                    if (!ex.Message.Contains("EMAIL_NOT_FOUND"))
                    {
                        await DisplayAlert("Errore", "Password errata", "OK");
                    }
                }

            }
        }

        public async void bottone_telefono(System.Object sender, System.EventArgs e)
        {
            string numeroNuovo = await DisplayPromptAsync("Informazione", "Inserisci il tuo nuovo numero di telefono");
            if (numeroNuovo != null)
            {
                utente.Numero = numeroNuovo;
                repositoryUtente.Update(utente);
            }
        }
    }
}