using Firebase.Database;
using JongoApplicazione.JongoApplicazione;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

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
                if(c > 'A' && c < 'Z')
                {
                    conta++;
                }  
            }
            return conta;
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
                await DisplayAlert("Errore", "Inserire il numero", "OK");
                verifica = false;
            }

            else if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Errore", "Inserire la password", "OK");
                verifica = false;
            }

            else if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Errore", "Inserire l' email", "OK");
                verifica = false;
            }

            else if (password != Conferma_Password.Text)
            {
                await DisplayAlert("Errore", "Password non corretta", "OK");
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
                utente.Name = nome;
                utente.Surname = cognome;
                utente.Email = email;
                utente.Password = password;
                utente.Numero = numero;
                          
                var isSaved = await repository.Save(utente);
                if (isSaved)
                {
                    await DisplayAlert("Informazione", "Registrazione effettuata!", "OK");
                }


                /*try {
                    string srvrdbname = "Jongo";
                    string srvrname = "192.168.1.254";
                    string srvrusername = "adp";
                    string srvrpasswd = "Anto4700";
                    string sqlconn = $"Data Source = {srvrname};Initial Catalog = {srvrdbname};User Id = {srvrusername};Password = {srvrpasswd}; Trudted_connection = true";

                    SqlConnection connessione = new SqlConnection(sqlconn);
                    connessione.Open();
                }

                catch (Exception ex){
                    Console.WriteLine(ex.Message);
                    throw;
                }*/
            }
            Etichetta.IsVisible = true;

        }

    }
}
