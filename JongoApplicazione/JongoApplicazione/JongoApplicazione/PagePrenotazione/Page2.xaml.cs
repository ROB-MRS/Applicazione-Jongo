using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione.JongoApplicazione.PagePrenotazione
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        //Bottone AVANTI
         async void Bottone_Avanti_Cliccato(System.Object sender, System.EventArgs e)
        {
           // if(Data.Date==null && Orario.Time==null)
            //    await DisplayAlert("Errore", "Seleziona data e orario", "OK");

            Navigation.PushAsync(new NavigationPage(new View.Prenota()));


        }

        //Bottone Indietro
         void Bottone_Indietro_Cliccato(System.Object sender, System.EventArgs e)
        {
                Navigation.PushAsync(new NavigationPage(new PagePrenotazione.Page1()));

        }
    }
}
