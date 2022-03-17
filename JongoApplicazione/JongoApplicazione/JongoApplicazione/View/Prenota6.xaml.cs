using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.JongoApplicazione.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota6 : ContentView
    {
        public Prenotazione p;
        public Utente u;
        RepositoryPrenotazione repository = new RepositoryPrenotazione();
        RepositoryUtente repositoryU = new RepositoryUtente();

        public Prenota6(Prenotazione prenotazione,Utente utente)
        {
            InitializeComponent();
            p = prenotazione;
            u = utente;
        }
         void Button_OK_Clicked(System.Object sender, System.EventArgs e)
        {
            u.prenotazioni.Add(p);
            repositoryU.Update(u);
            var isSaved =   repository.Save(p);
            
            Navigation.PopAsync();

        }
    }
}
