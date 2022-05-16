using Firebase.Database;
using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Threading.Tasks;
using Xamarin.Essentials;

//using System.Data.SqlClient;
using Xamarin.Forms;


namespace JongoApplicazione.PagineLogIn
{
    public partial class PageIscrizione : ContentPage
    {
        //FirebaseClient firebaseClient =
          //  new FirebaseClient("https://jongo-data-default-rtdb.europe-west1.firebasedatabase.app/");
          RepositoryUtente repository = new RepositoryUtente();
          
        

        public PageIscrizione()
        {
            InitializeComponent();
        }

        
        int conta_caratteri_maiuscoli(string passwd)
        {
            int conta = 0;
            foreach(char c in passwd)
            {
                if(c >= 'A' && c <= 'Z')
                {
                    conta++;
                }  
            }
            return conta;
        }

        bool isNumero(string numero)
        {
            foreach(char c in numero)
            {
                if(c < '0' || c > '9')
                {
                    return false;
                }
                
            }
            return true;
        }

        async void Bottone_premuto(System.Object sender, System.EventArgs e)
        {
            bool verifica = true;
            string nome = Nome.Text;
            string cognome = Cognome.Text;
            string numero = Numero.Text;
            string email = Email.Text;
            string password = Password.Text;

            if (string.IsNullOrEmpty(nome))
            {
                await DisplayAlert("Errore", "Inserire il nome", "OK");
                verifica = false;
            }

            else if (string.IsNullOrEmpty(cognome))
            {
                await DisplayAlert("Errore", "Inserire il cognome", "OK");
                verifica = false;
            }

            else if (string.IsNullOrEmpty(numero))
            {
                await DisplayAlert("Errore", "Inserire il numero di telefono", "OK");
                verifica = false;
            }

            else if (!isNumero(numero))
            {
                await DisplayAlert("Errore", "Il numero di telefono deve essere composto da soli numeri senza spazi", "OK");
                verifica = false;
            }

            else if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Errore", "Inserire l' email", "OK");
                verifica = false;
            }

            else if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Errore", "Inserire la password", "OK");
                verifica = false;
            }

            
            else if (password != Conferma_Password.Text)
            {
                await DisplayAlert("Errore", "Password di conferma non corretta", "OK");
                verifica = false;
            }

            else if(password.Length < 6)
            {
                await DisplayAlert("Errore", "Password troppo corta, deve contenere almeno 6 caratteri", "OK");
                verifica = false;
            }

            else if(conta_caratteri_maiuscoli(password) < 2)
            {
                await DisplayAlert("Errore", "Password non corretta, deve contenere almeno 2 caratteri maiuscoli", "OK");
                verifica = false;
            }


            try {
                string token = "";
                if (verifica)
                {
                    token = await repository.SignUp(email, password);
                
                    if (!string.IsNullOrEmpty(token)) 
                    { 

                        List<string> listaEmail = new List<string>();
                        List<Utente> listaUtenti = new List<Utente>(await repository.GetAll());

                        foreach (Utente u in await repository.GetAll())
                        {
                            listaEmail.Add(u.Email);
                        }

                        if (listaEmail.Contains(email) && verifica)
                        {
                            await DisplayAlert("Errore", "Email già presente", "OK");
                        }

                        else if(verifica)
                        {   
                

                            Utente utente = new Utente();
                            utente.Name = nome.ToUpper();
                            utente.Surname = cognome.ToUpper();
                            utente.Email = email;
                            utente.Password = password.GetHashCode();
                            utente.Numero = numero;
                          
                            var isSaved = await repository.Save(utente);
                            if (isSaved)
                            {
                                CreateMail();
                                await DisplayAlert("Informazione", "Controlla la mail per verificare di esserti iscritto con successo ", "OK");
                                await Navigation.PushAsync(new HomePage(utente));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Errore", "Email già presente o inesistente", "OK");
            }
        }

        void CreateMail()
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("info.jongo@gmail.com");
                mail.To.Add(Email.Text);
                mail.Subject = "GRAZIE PER ESSERTI ISCRITTO! ";
                mail.Body = "Hai completato con successo l'iscrizione a Jongo!\nPer saperne di piu sui nostri servizi visita https://www.jongomontaggi.it/";

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("info.jongo@gmail.com", "Info2022");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                DisplayAlert("Faild", ex.Message, "OK");
            }
        }

    }
}
