using JongoApplicazione.JongoApplicazione.PagineLogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JongoApplicazione.JongoApplicazione
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cronologia : ContentPage
    {
        public Cronologia(Utente utente)
        {
            InitializeComponent();
            
        }
    }
}