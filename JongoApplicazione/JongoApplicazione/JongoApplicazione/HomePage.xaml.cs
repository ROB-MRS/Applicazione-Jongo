using System;
using System.Collections.Generic;
using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.View;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net.Mail;

namespace JongoApplicazione
{
    public partial class HomePage : ContentPage
    {
        public Utente utenteHomePage;

        public HomePage(Utente utente)
        {
            InitializeComponent();
            utenteHomePage = utente;
            if (utente == null)
            {
                bottone_logout.IsVisible = false;
                bottone_login.IsVisible = true;
                
                
            }
            else
            {
                bottone_login.IsVisible = false;
                bottone_logout.IsVisible = true;
                Utente_loggato.IsVisible = true;
                Utente_loggato.Text = utente.Name + " " + utente.Surname;
            }
        }

        void Button_1_Clicked(System.Object sender, System.EventArgs e)
        {
            CreateMail();
            Browser.OpenAsync("https://www.jongomontaggi.it/", BrowserLaunchMode.SystemPreferred);
        }

        void Bottone_login(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }

        void Bottone_logout(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomePage(null));
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if(utenteHomePage == null)
            {
                await DisplayAlert("Attenzione", "Per prenotare è necessario autenticarsi", "OK");
                return;
            }
            await Navigation.PushAsync(new View.Prenota(utenteHomePage));
        }

        async void bottone_cronologia(System.Object sender, System.EventArgs e)
        {
            if (utenteHomePage == null)
            {
                await DisplayAlert("Attenzione", "Per accedere alla cronologia è necessario autenticarsi", "OK");
                return;
            }
            await Navigation.PushAsync(new Cronologia(utenteHomePage));
        }

        //void Bottone_Impostazioni_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    Navigation.PushAsync(new NavigationPage(new SettingsPage()));
        //}

        async void SendWhatsapp()
        {
           
            try
            {
                await Launcher.OpenAsync("https://wa.me/+393927288821?text=prova");
            }
            catch
            {
               await DisplayAlert("Attenzaione", "Errore", "OK");
            }
        }

        void Bottone_Contattaci(System.Object sender, System.EventArgs e)
        {
            SendWhatsapp();
        }

        async void Bottone_Mappa(System.Object sender, System.EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                await Launcher.OpenAsync("http://maps.apple.com/?q=Roma&z=2");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                await Launcher.OpenAsync("geo:0,0?q=Roma");
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                await Launcher.OpenAsync("bingmaps:?where=Roma");
            }
        }

        async void bottone_impostazioni(System.Object sender, System.EventArgs e)
        {
            if (utenteHomePage == null)
            {
                await DisplayAlert("Attenzione", "Per accedere alle impostazioni è necessario autenticarsi", "OK");
                return;
            }
            await Navigation.PushAsync(new Impostazioni(utenteHomePage));
        }

        //public static void CreateMessage(string server)
        //{
        //    string to = "rmarsella80@gmail.com";
        //    string from = "rmarsella80@gmail.com";
        //    MailMessage message = new MailMessage(from, to);
        //    message.Subject = "Prova";
        //    message.Body = "questa è una prova di invio di una mail.";
        //    SmtpClient client = new SmtpClient(server);
        //    // Credentials are necessary if the server requires the client
        //    // to authenticate before it will send email on the client's behalf.
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new System.Net.NetworkCredential("rmarsella80@gmail.com", "Polletto01-");

        //    try
        //    {
        //        client.Send(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
        //            ex.ToString());
        //    }
        //}

        void CreateMail()
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("rmarsella80@gmail.com");
                mail.To.Add("raffle.rob00@gmail.com");
                mail.Subject = "prova";
                mail.Body = "prova dell'invio di una mail.";

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("rmarsella80@gmail.com", "Roberto01");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                DisplayAlert("Faild", ex.Message, "OK");
            }
        }
    }
}
