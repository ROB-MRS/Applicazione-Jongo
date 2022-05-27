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
            descrizione.Placeholder = "Descrizione lavoro da svolgere\nes: nome, marca e codice del\nmobile da montare";
            
        }

        void Bottone_conferma(System.Object sender, System.EventArgs e)
        {
            try
            {
                int selectedIndex = categoria.SelectedIndex;
                p.servizio = categoria.Items[selectedIndex];
                categoria.TextColor = Color.Gray;
            }
            catch(Exception ex)
            {
                p.servizio = categoria.Items[4];
            }
            
            p.descrizione = descrizione.Text;
            
            descrizione.TextColor = Color.Gray;
            descrizione.IsReadOnly = true;

            conferma.IsVisible = false;
            modifica.IsVisible = true;
             
            
            
        }

        void Bottone_modifica(System.Object sender, System.EventArgs e)
        {
            categoria.TextColor=Color.Black;
            descrizione.TextColor=Color.Black;

            descrizione.IsReadOnly=true;

            modifica.IsVisible = false;
            conferma.IsVisible = true;
        }
    }
}
