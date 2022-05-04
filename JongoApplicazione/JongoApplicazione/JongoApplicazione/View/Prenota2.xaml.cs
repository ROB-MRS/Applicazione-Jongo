using JongoApplicazione.JongoApplicazione.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota2 : ContentView
    {
        Prenotazione p;
        public Prenota2(Prenotazione prenotazione)
        {
            InitializeComponent();
            p = prenotazione;
        }

        void bottone_conferma(System.Object sender, System.EventArgs e)
        {
            p.data = Data.Date.ToShortDateString();
            p.ora = Orario.Time.ToString();
            p.informazioniExtra = Info.Text;
            conferma.IsVisible = false;
            modifica.IsVisible = true;
        }

        void bottone_modifica(System.Object sender, System.EventArgs e)
        {
            modifica.IsVisible = false;
            conferma.IsVisible = true;
        }
    }
}
