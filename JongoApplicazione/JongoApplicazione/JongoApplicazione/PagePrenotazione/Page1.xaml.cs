using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione.JongoApplicazione.PagePrenotazione
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }



        //Bottone di Conferma
        async void Bottone_Conferma_Cliccato(System.Object sender, System.EventArgs e)
        {
            if(String.IsNullOrEmpty(Nome.Text) || String.IsNullOrEmpty(Cognome.Text) || String.IsNullOrEmpty(Indirizzo.Text) || String.IsNullOrEmpty(Civico.Text) || String.IsNullOrEmpty(Cap.Text) || String.IsNullOrEmpty(Telefono.Text))
                await DisplayAlert("Errore","Tutti i campi devono essere compilati", "OK");
            else
                Navigation.PushAsync(new PagePrenotazione.Page2());
            
        }

    }
}
