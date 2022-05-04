using Firebase.Auth;
using Firebase.Database;
using JongoApplicazione.JongoApplicazione.PagineLogIn;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongoApplicazione.JongoApplicazione
{
    public class RepositoryUtente
    {
        FirebaseClient firebaseClient =
                new FirebaseClient("https://jongo-data-default-rtdb.europe-west1.firebasedatabase.app/");
        
        FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCJ1J9HJUzcQnBaP3i5d8xhke9gXy7rcfA"));


        public async Task<bool> Save(Utente utente)
        {
            var data = await firebaseClient.Child(nameof(Utente)).PostAsync(JsonConvert.SerializeObject(utente));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Utente>> GetAll()
        {
            
            return (await firebaseClient.Child(nameof(Utente)).OnceAsync<Utente>()).Select(item=> new Utente
                {
                    prenotazioni = item.Object.prenotazioni,
                    Email = item.Object.Email,
                    Name = item.Object.Name,
                    Surname = item.Object.Surname,
                    Numero = item.Object.Numero,
                    Password = item.Object.Password,
                    Id = item.Key
                }).ToList();
        }

        public async void Delete(Utente utente)
        {
            await firebaseClient.Child(nameof(Utente) + "/" + utente.Id).DeleteAsync();
            List<Utente> list = await GetAll();
            list.Remove(utente);
        }

        public async void Update(Utente utente)
        {
            await firebaseClient.Child(nameof(Utente)+"/"+utente.Id).PutAsync(JsonConvert.SerializeObject(utente)); 
        }

        public async Task<string> SignUp(string email,string password)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email,password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }

        public async Task<bool> ResetPassword(string email)
        {
            await authProvider.SendPasswordResetEmailAsync(email);
            return true;
        }

        public async Task<string> SignIn(string email,string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }

        


    }
}
