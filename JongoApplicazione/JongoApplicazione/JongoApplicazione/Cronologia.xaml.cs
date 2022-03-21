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
            StackLayout stackLayout = new StackLayout();
            foreach(Prenotazione p in utente.prenotazioni)
            {
                Frame frame = new Frame
                {
                    WidthRequest = 300,
                    HeightRequest = 300,
                    BackgroundColor = Color.LightGoldenrodYellow,
                    BorderColor = Color.Black,
                    Margin = new Thickness(10),
                    CornerRadius = 20,
                };

                StackLayout stackLayout1= new StackLayout
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
                    Text = "&#x2022; " + p.data + " " + p.ora,
                    Margin = new Thickness(0.4),
                    FontSize = 20,
                    TextColor = Color.Black,
                };



                Button button = new Button
                {
                    Text = "Infomazioni Aggiuntive",
                    CornerRadius = 10,
                    FontSize = 50,
                    BackgroundColor = Color.Violet,
                    TextColor = Color.Black,

                };
                stackLayout1.Children.Add(label);
                stackLayout1.Children.Add(label1);
                stackLayout1.Children.Add(label2);
                stackLayout1.Children.Add(label3);
                stackLayout1.Children.Add(button);
                frame.Content = stackLayout1;
                //Label label = new Label
                //{
                //    Text = p.name+" "+p.cognome,
                //    TextColor = Color.Black,
                //    BackgroundColor = Color.Purple,
                //    FontSize = 24,
                //    VerticalOptions = LayoutOptions.Center
                //};
                //stackLayout.Children.Add(label);
                //stackLayout.Margin = new Thickness(20,20);

                //StackLayout stackLayout = new StackLayout
                //{
                //    Margin = new Thickness(20,20), 
                //    HeightRequest = 50,
                //    HorizontalOptions = LayoutOptions.Start,
                //    VerticalOptions= LayoutOptions.Start,
                //    Orientation = StackOrientation.Horizontal,
                //    Children = { label }
                //};
                stackLayout.Children.Add(frame);

            }
            pagina.Content = stackLayout;
            
        }
    }
}