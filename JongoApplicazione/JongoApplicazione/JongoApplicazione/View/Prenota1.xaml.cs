using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.JongoApplicazione.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota1 : ContentView
    {
        Prenotazione p;
        
        public Prenota1(Prenotazione prenotazione,Utente utente)
        {
            InitializeComponent();
            Nome.Text = utente.Name;
            Cognome.Text = utente.Surname;
            Mail.Text = utente.Email;
            p = prenotazione;
        }

        void bottone_conferma(System.Object sender, System.EventArgs e)
        {
            p.name = Nome.Text;
            p.cognome = Cognome.Text;
            p.cap = CAP.Text;
            p.via = Indirizzo.Text;
            p.numero = Telefono.Text;
            p.mail = Mail.Text;
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
