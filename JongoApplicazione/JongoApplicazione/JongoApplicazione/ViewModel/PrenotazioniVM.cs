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

        public ICommand ComandoAvanti { private set; get; }
        public ICommand ComandoIndietro { private set; get; }

        public PrenotazioniVM()
        {
            pagina = 1;

            content = new ContentView();
            Prenota1 = new View.Prenota1();
            Prenota2 = new View.Prenota2();

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
            if(pagina<4)
                pagina++;
            CambiaPagina();
            OnPropertyChanged("content");       
        }

        public void Indietro()
        {
            if(pagina>1)
                pagina--;
            CambiaPagina();
            OnPropertyChanged("content");
        }

        void CambiaPagina()
        {
            switch (pagina)
            {
                case 1:
                    content = Prenota1;
                    return;
                case 2:
                    content = Prenota2;
                    return;
                case 3:
                    content = Prenota3;
                    return;
                case 4:
                    content = Prenota4;
                    return;
                default:
                    throw new NullReferenceException();
            }
        }
    }
}
