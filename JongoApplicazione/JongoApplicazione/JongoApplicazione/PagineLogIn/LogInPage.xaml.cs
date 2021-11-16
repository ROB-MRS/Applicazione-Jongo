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
            if (!String.IsNullOrEmpty(Email.Text) && !String.IsNullOrEmpty(Password.Text))
            {
                Errore_Password.IsVisible = false;
                Console.WriteLine("stampa: " + Email.Text + Password.Text);
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                if(String.IsNullOrEmpty(Email.Text))
                {
                    Errore_Email.IsVisible = true;
                }
                else
                {
                    Errore_Email.IsVisible = false;
                }

                if(String.IsNullOrEmpty(Password.Text))
                {
                    Errore_Password.IsVisible = true;
                }
                else
                {
                    Errore_Password.IsVisible = false;
                }
            }
                
        }

    }
}
