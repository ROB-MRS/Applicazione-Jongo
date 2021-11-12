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
            if (Email.Text != null && Password.Text != null)
            {
                Console.WriteLine("stampa: " + Email.Text + Password.Text);
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                if(Email.Text == null)
                {
                    Errore_Email.IsEnabled = true;
                }
                else
                {
                    Errore_Email.IsEnabled = false;
                }

                if(Password.Text == null)
                {
                    Errore_Password.IsEnabled = true;
                }
                else
                {
                    Errore_Password.IsEnabled = false;
                }
            }
                
        }

    }
}
