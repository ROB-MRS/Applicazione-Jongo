using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        void Bottone_Recupero_Password_Cliccato(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageRecuperoPassword());
        }

    }
}
