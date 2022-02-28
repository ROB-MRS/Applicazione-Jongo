using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JongoApplicazione.JongoApplicazione.PagineLogIn
{
    public class Utente
    {
        
        public  string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Numero { get; set; }

        public string Password { get; set; }

    }
}
