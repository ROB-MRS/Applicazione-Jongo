using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota3 : ContentView
    {
        public Prenota3()
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
            
        }
    }
}
