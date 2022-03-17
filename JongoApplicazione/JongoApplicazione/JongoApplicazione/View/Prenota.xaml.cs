using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.JongoApplicazione.View;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota : ContentPage
    {
        public ViewModel.PrenotazioniVM VM { get; set; }
        public Prenotazione prenotazione = new Prenotazione();

        public Prenota(Utente utente)
        {

            InitializeComponent();
            prenotazione.id++;
            VM = new ViewModel.PrenotazioniVM(prenotazione,utente);
            BindingContext = VM;
            //avanti.Command = VM.ComandoAvanti;
            //indietro.Command = VM.ComandoIndietro;
            VM.CambioPaginaEvent += CambioPagina;

        }

        void CambioPagina(int pagina)
        {
            if (pagina == 6)
                buttons.IsVisible = false;
        }
    }
}
