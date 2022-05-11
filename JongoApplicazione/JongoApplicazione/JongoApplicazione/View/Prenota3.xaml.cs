using JongoApplicazione.JongoApplicazione.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota3 : ContentView
    {
        Prenotazione p;
        public Prenota3(Prenotazione prenotazione)
        {
           

            InitializeComponent();

            /* Creo una lista per utilizzarla nello xaml nel picker */
            List<string> categorie = new List<string>();
            categorie.Add("Montaggio");
            categorie.Add("Fabbro");
            categorie.Add("Idraulico");
            categorie.Add("Muratore");
            categorie.Add("Altro");

            categoria.ItemsSource = categorie;
            p = prenotazione;
            
        }

        void Bottone_conferma(System.Object sender, System.EventArgs e)
        {
            
            
            int selectedIndex = categoria.SelectedIndex;
            p.servizio = categoria.Items[selectedIndex];
            p.descrizione = descrizione.Text;
            conferma.IsVisible = false;
            modifica.IsVisible = true;
             
            
            
        }

        void Bottone_modifica(System.Object sender, System.EventArgs e)
        {
            modifica.IsVisible = false;
            conferma.IsVisible = true;
        }
    }
}
