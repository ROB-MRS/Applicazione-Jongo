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
            
            Nome.TextColor = Color.Gray;
            Cognome.TextColor = Color.Gray;
            Mail.TextColor = Color.Gray;
            Indirizzo.TextColor = Color.Gray;
            CAP.TextColor = Color.Gray;
            Telefono.TextColor = Color.Gray;

            Nome.IsReadOnly = true;
            Cognome.IsReadOnly = true;
            Mail.IsReadOnly = true;
            Indirizzo.IsReadOnly = true;
            CAP.IsReadOnly = true;
            Telefono.IsReadOnly = true;

            conferma.IsVisible = false;
            modifica.IsVisible = true;
        }

        void bottone_modifica(System.Object sender, System.EventArgs e)
        {
            Nome.TextColor = Color.Black;
            Cognome.TextColor = Color.Black;
            Mail.TextColor = Color.Black;
            Indirizzo.TextColor = Color.Black;
            CAP.TextColor = Color.Black;
            Telefono.TextColor = Color.Black;

            Nome.IsReadOnly = false;
            Cognome.IsReadOnly = false;
            Mail.IsReadOnly = false;
            Indirizzo.IsReadOnly = false;
            CAP.IsReadOnly = false;
            Telefono.IsReadOnly = false;

            modifica.IsVisible = false;
            conferma.IsVisible = true;
        }

    }
}
