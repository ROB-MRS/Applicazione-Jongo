using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione.View
{
    public partial class Prenota : ContentPage
    {
        public ViewModel.PrenotazioniVM VM { get; set; }

        public Prenota()
        {
            VM = new ViewModel.PrenotazioniVM();
            InitializeComponent();

            content.BindingContext = VM;
            avanti.Command = VM.ComandoAvanti;
            indietro.Command = VM.ComandoIndietro;
        }
    }
}
