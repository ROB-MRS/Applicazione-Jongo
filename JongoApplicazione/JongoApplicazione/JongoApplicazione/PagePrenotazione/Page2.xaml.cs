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
         void Bottone_Avanti_Cliccato(System.Object sender, System.EventArgs e)
        {
           

        }

        //Bottone Indietro
         void Bottone_Indietro_Cliccato(System.Object sender, System.EventArgs e)
        {
                Navigation.PushAsync(new NavigationPage(new PagePrenotazione.Page1()));

        }
    }
}
