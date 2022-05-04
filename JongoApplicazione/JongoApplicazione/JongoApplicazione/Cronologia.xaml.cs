using JongoApplicazione.JongoApplicazione.PagineLogIn;
using JongoApplicazione.JongoApplicazione.View;
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

            if (utente.prenotazioni.Count == 0)
            {
                Vuota.IsVisible = true;
            }
            else
            {
                StackLayout stackLayout = new StackLayout();
                foreach (Prenotazione p in utente.prenotazioni)
                {
                    Frame frame = new Frame
                    {
                        WidthRequest = 300,
                        HeightRequest = 220,
                        BackgroundColor = Color.Goldenrod,
                        BorderColor = Color.Black,
                        Margin = new Thickness(10),
                        CornerRadius = 20,
                    };

                    StackLayout stackLayout1 = new StackLayout
                    {
                        FlowDirection = FlowDirection.LeftToRight,
                    };

                    Label label = new Label
                    {
                        Text = p.name + " " + p.cognome,
                        Margin = new Thickness(0.8),
                        FontSize = 50,
                        TextColor = Color.Black,
                    };

                    Label label1 = new Label
                    {
                        Text = "Servizio prenotato: " + p.servizio,
                        Margin = new Thickness(0.4),
                        FontSize = 20,
                        TextColor = Color.Black,
                    };

                    Label label2 = new Label
                    {
                        Text = "Descrizione del servizio: " + p.descrizione,
                        Margin = new Thickness(0.4),
                        FontSize = 20,
                        TextColor = Color.Black,
                    };

                    Label label3 = new Label
                    {
                        Text = "Giorno: " + p.data,
                        Margin = new Thickness(0.4),
                        FontSize = 20,
                        TextColor = Color.Black,
                    };

                    Label label4 = new Label
                    {
                        Text = "Ora: " + p.ora,
                        Margin = new Thickness(0.4),
                        FontSize = 20,
                        TextColor = Color.Black,
                    };

                    Label label5 = new Label
                    {
                        Text = "Indirizzo: " + p.via + ", " + p.cap,
                        Margin = new Thickness(0.4),
                        FontSize = 20,
                        TextColor = Color.Black,
                    };



                    stackLayout1.Children.Add(label);
                    stackLayout1.Children.Add(label1);
                    stackLayout1.Children.Add(label2);
                    stackLayout1.Children.Add(label3);
                    stackLayout1.Children.Add(label4);
                    stackLayout1.Children.Add(label5);
                    frame.Content = stackLayout1;
                    stackLayout.Children.Add(frame);

                }
                pagina.Content = stackLayout;

            }
        }
    }
}