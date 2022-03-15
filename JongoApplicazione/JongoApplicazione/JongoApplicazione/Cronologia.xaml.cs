using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.JongoApplicazione.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JongoApplicazione.JongoApplicazione
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cronologia : ContentPage
    {
        public RepositoryPrenotazione repository = new RepositoryPrenotazione();

        public List<Prenotazione> listaPrenotazioni;

        public ObservableCollection<string> Items { get; set; }

        public Cronologia(Utente utente)
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
            //creaLista();
            //List<Prenotazione> prenotazioni2utenti = new List<Prenotazione>();
            //foreach(Prenotazione p in listaPrenotazioni)
            //{
            //    string descrizioneUtente = p.name + " " + p.cognome;
            //    if (descrizioneUtente.Equals(utente))
            //    {
            //        prenotazioni2utenti.Add(p);
            //    }
            //}
            MyListView.ItemsSource = Items;
        }

        async void creaLista()
        {
            listaPrenotazioni = new List<Prenotazione>(await repository.GetAll()); 
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
