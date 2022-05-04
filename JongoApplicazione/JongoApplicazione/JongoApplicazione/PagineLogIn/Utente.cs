using Firebase.Database;
using JongoApplicazione.JongoApplicazione.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JongoApplicazione.JongoApplicazione.PagineLogIn
{
    public class Utente
    {
        public List<Prenotazione> prenotazioni = new List<Prenotazione>();

        public  string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Numero { get; set; }

        public int Password { get; set; }

    }
}
