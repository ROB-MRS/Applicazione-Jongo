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

            List<string> categorie = new List<string>();
            categorie.Add("Armadio");
            categorie.Add("Comodino");
            categorie.Add("Lampadine");
            categorie.Add("Scrivania");
            categorie.Add("Sedia");
            categorie.Add("Altre cose");

            categoria.ItemsSource = categorie;
            
        }
    }
}
