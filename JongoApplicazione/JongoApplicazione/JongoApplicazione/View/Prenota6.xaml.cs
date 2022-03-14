using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota6 : ContentView
    {
        public Prenotazione p;
        RepositoryPrenotazione repository = new RepositoryPrenotazione();
        public Prenota6(Prenotazione prenotazione)
        {
            InitializeComponent();
            p = prenotazione;
        }
         void Button_OK_Clicked(System.Object sender, System.EventArgs e)
        {
            var isSaved =   repository.Save(p);
            
            Navigation.PopAsync();

        }
    }
}
