using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.JongoApplicazione.View;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace JongoApplicazione.ViewModel
{
    public class PrenotazioniVM :  INotifyPropertyChanged
    {
        public int pagina { get; set; }
        private Prenotazione p;
        private Utente u;

        public ContentView content { get; set; }

        public View.Prenota1 Prenota1 { get; set; }
        public View.Prenota2 Prenota2 { get; set; }
        public View.Prenota3 Prenota3 { get; set; }
        public View.Prenota4 Prenota4 { get; set; }
        public View.Prenota5 Prenota5 { get; set; }
        public View.Prenota6 Prenota6 { get; set; }

        public Action<int> CambioPaginaEvent { get; set; }

        public ICommand ComandoAvanti { private set; get; }
        public ICommand ComandoIndietro { private set; get; }

        public PrenotazioniVM(Prenotazione prenotazione,Utente utente)
        {
            pagina = 1;

            content = new ContentView();
            Prenota1 = new View.Prenota1(prenotazione,utente);
            Prenota2 = new View.Prenota2(prenotazione);
            Prenota3 = new View.Prenota3(prenotazione);
            Prenota4 = new View.Prenota4();
            Prenota5 = new View.Prenota5();
            Prenota6 = new View.Prenota6(prenotazione,utente);
            this.p = prenotazione;
            this.u = utente;


            ComandoAvanti = new Command(Avanti);
            ComandoIndietro = new Command(Indietro);

            CambiaPagina();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Avanti()
        {

            if(pagina<6)
                pagina++;
            
            CambiaPagina();
            
                   
        }

        public void Indietro()
        {
            if(pagina>1)
                pagina--;
            CambiaPagina();
            
        }

        void CambiaPagina()
        {
            switch (pagina)
            {
                case 1:
                    content = Prenota1;
                    AggiornaPagina();
                    return;
                case 2:
                    content = Prenota2;
                    AggiornaPagina();
                    return;
                case 3:
                    content = Prenota3;
                    AggiornaPagina();
                    return;
                case 4:
                    content = Prenota4;
                    AggiornaPagina();
                    return;
                case 5:
                    content = Prenota5;
                    AggiornaPagina();
                    return;
                case 6:
                    content = Prenota6;
                    string dest = "";
                    if (string.IsNullOrEmpty(p.mail)) { dest = u.Email; } else { dest = p.mail; }
                    CreateMail("info.jongo@gmail.com", $"PRENOTAZIONE LAVORO n'{this.p.id.ToString()}", CreateMessage(false));
                    CreateMail(dest, $"RIEPILOGO ORDINE JONGO n'{this.p.id.ToString()} " , CreateMessage(true));
                    AggiornaPagina();
                    return;
                default:
                    throw new NullReferenceException();
            }
        }

        void AggiornaPagina()
        {
            OnPropertyChanged("content");
            CambioPaginaEvent?.Invoke(pagina);
        }

        void CreateMail(string email, string subject, string message)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("info.jongo@gmail.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("info.jongo@gmail.com", "Info2022");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        string CreateMessage(bool valore)
        {
            var i = (nome:this.p.name, cognome: this.p.cognome, cell: this.p.numero, via:this.p.via, cap: this.p.cap, data: this.p.data,
                        ora: this.p.ora, servizio: this.p.servizio, descrizione:this.p.descrizione, infoExtra: this.p.informazioniExtra);
            System.Text.StringBuilder messaggio = new System.Text.StringBuilder("");
            if (valore)
            {
                messaggio.Append("Gentile cliente, ecco un riepilogo dell'ordine effettuato tramite il servizio JONGO:")
                .Append($"Nome: {i.nome}\n").Append($"Cognome: {i.cognome}\n").Append($"Telefono/Cellulare: {i.cell}\n")
                .Append($"Presso: {i.via}").Append($",{i.cap}\n").Append($"In data: {i.data}").Append($"alle ore {i.data}\n")
                .Append($"Per il servizio di: {i.servizio}\n").Append($"Descrizione: {i.descrizione}\n").Append($"[info extra: {i.infoExtra}]")
                .Append("Ti ringraziamo per aver utilizzato Jongo. Presto verrai contattato da un nostro operatore per un preventivo accurato.\n" +
                        "Per altre informazioni puoi contattarci a info@jongomontaggi.it o al numero verdi +39 351 7085953.\n\n");
                return messaggio.ToString();
            }
            else
            {
                messaggio.Append("Richesta di lavoro Jongo:")
                .Append($"Nome: {i.nome}\n").Append($"Cognome: {i.cognome}\n").Append($"Telefono/Cellulare: {i.cell}\n")
                .Append($"Presso: {i.via}").Append($",{i.cap}\n").Append($"In data: {i.data}").Append($"alle ore {i.data}\n")
                .Append($"Per il servizio di: {i.servizio}\n").Append($"Descrizione: {i.descrizione}\n").Append($"[info extra: {i.infoExtra}]")
                .Append("\n\nInviare al piu presto il preventivo al cliente.");
                return messaggio.ToString();
            }
        }
    }
}
