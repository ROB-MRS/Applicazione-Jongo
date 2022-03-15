using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.JongoApplicazione.View;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace JongoApplicazione.ViewModel
{
    public class PrenotazioniVM :  INotifyPropertyChanged
    {
        public int pagina { get; set; }

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
            Prenota1 = new View.Prenota1(prenotazione);
            Prenota2 = new View.Prenota2(prenotazione);
            Prenota3 = new View.Prenota3(prenotazione);
            Prenota4 = new View.Prenota4();
            Prenota5 = new View.Prenota5();
            Prenota6 = new View.Prenota6(prenotazione,utente);


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
    }
}
