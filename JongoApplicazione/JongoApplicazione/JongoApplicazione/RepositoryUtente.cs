using Firebase.Database;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JongoApplicazione.JongoApplicazione
{
    public class RepositoryUtente
    {
        FirebaseClient firebaseClient =
                new FirebaseClient("https://jongo-data-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<bool> Save(Utente utente)
        {
            var data = await firebaseClient.Child(nameof(Utente)).PostAsync(JsonConvert.SerializeObject(utente));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
    }
}
