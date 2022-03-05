﻿using System;
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
