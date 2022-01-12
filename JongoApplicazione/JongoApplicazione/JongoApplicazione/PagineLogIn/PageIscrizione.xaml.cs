using System;
using System.Collections.Generic;

using System.Data.SqlClient;
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
            try {
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
            }
            
            Etichetta.IsVisible = true;   
        }

    }
}
