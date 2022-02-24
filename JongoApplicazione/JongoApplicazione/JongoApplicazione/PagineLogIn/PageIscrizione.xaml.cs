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

        async void Bottone_premuto(System.Object sender, System.EventArgs e)
        {
            Etichetta.IsVisible = true;
            string nome = Nome.Text;
            string cognome = Cognome.Text;
            string numero = Numero.Text;
            string email = Email.Text;
            string password = Password.Text;



            if(string.IsNullOrEmpty(nome))
            {
                await DisplayAlert("Errore", "Inserire il nome", "OK");
            }

            if (string.IsNullOrEmpty(cognome))
            {
                await DisplayAlert("Errore", "Inserire il cognome", "OK");
            }

            if (string.IsNullOrEmpty(numero))
            {
                await DisplayAlert("Errore", "Inserire il numero", "OK");
            }

            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Errore", "Inserire la password", "OK");
            }

            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Errore", "Inserire l' email", "OK");
            }

            if(password != Conferma_Password.Text)
            {
                await DisplayAlert("Errore", "Password non corretta", "OK");
            }

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

    }
}
