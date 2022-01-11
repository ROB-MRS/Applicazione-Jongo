using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione.PagineLogIn
{
    public partial class PageIscrizione : ContentPage
    {
        public PageIscrizione()
        {
            InitializeComponent();
        }

        void Bottone_premuto(System.Object sender, System.EventArgs e)
        {
            Etichetta.IsVisible = true;   
        }

    }
}
