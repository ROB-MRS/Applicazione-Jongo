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
            /* List<string> listOfNames = new List<string>()
            {
                "John Doe",
                "Jane Doe",
                "Joe Doe"
            }; */

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

        void bottone_conferma(System.Object sender, System.EventArgs e)
        {
            int selectedIndex = categoria.SelectedIndex;
            p.servizio = categoria.Items[selectedIndex];
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
