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
                    await DisplayAlert("La tua password è: ", utente.Password.ToString(), "OK");
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
