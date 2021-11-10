using System;
using System.Collections.Generic;
using JongoApplicazione.PagineLogIn;

using Xamarin.Forms;

namespace JongoApplicazione
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }


        //Bottone di Recupero Password
        void Bottone_Recupero_Password_Cliccato(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageRecuperoPassword());
        }


        //Bottone di Log In
        void Bottone_Log_In_Cliccato(System.Object sender, System.EventArgs e)
        {
            if (Email.Text == null)
            {
                Errore_Email.TextColor = Color.Red;
                if (Email.Text == null)
                {
                    Errore_Password.TextColor = Color.Red;
                }
            }
            else
            {
                Navigation.PushAsync(new MainPage());
            }
        }

    }
}
