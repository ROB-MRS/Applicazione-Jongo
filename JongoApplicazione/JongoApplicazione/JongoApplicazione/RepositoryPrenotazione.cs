using Firebase.Database;
using JongoApplicazione.JongoApplicazione.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongoApplicazione.JongoApplicazione
{
    public class RepositoryPrenotazione
    {
        FirebaseClient firebaseClient =
                new FirebaseClient("https://jongo-data-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<bool> Save(Prenotazione prenotazione)
        {
            var data = await firebaseClient.Child(nameof(Prenotazione)).PostAsync(JsonConvert.SerializeObject(prenotazione));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Prenotazione>> GetAll()
        {

            return (await firebaseClient.Child(nameof(Prenotazione)).OnceAsync<Prenotazione>()).Select(item => new Prenotazione
            {
                name = item.Object.name,
                cognome = item.Object.cognome,
                via = item.Object.via,
                cap = item.Object.cap,
                data = item.Object.data,
                ora = item.Object.ora,
                informazioniExtra = item.Object.informazioniExtra,
                servizio = item.Object.servizio,


            }).ToList();
        }
    }
}
