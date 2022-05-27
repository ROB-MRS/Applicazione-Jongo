using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione.PagineLogIn
{
    public partial class PageRecuperoPassword : ContentPage
    {
        RepositoryUtente repository = new RepositoryUtente();   
        

        public PageRecuperoPassword()
        {
            InitializeComponent();
        }

        async void Bottone_premuto(System.Object sender, System.EventArgs e)
        {
            List<Utente> listaUtenti =  new List<Utente>(await repository.GetAll());
            bool trovato = false;
            foreach(Utente utente in listaUtenti)
            {
                if(utente.Email == Inserimento.Text)
                {   
                    bool isSend = await repository.ResetPassword(utente.Email);
                    if (isSend)
                    {
                        await DisplayAlert("Informazione", "Controlla la tua email per cambiare la password", "OK");
                        await Navigation.PushAsync(new LogInPage());
                    }
                    else
                    {
                        await DisplayAlert("Errore", "Invio messaggio non riuscito", "OK");
                    }
                    trovato = true;
                }
            }
            if (!trovato)
            {
                await DisplayAlert("Errore", "Email non corretta", "OK");
            }
            
        }
    }
}
