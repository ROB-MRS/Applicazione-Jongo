using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JongoApplicazione
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LogInPage());
            MainPage = new PagineLogIn.PageSelezioneLogIn();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
