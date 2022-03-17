using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JongoApplicazione.PagineLogIn
{
    public partial class PageSelezioneLogIn : ContentPage
    {
        public PageSelezioneLogIn()
        {
            InitializeComponent();
        }

        void Bottone_Log_In_User_Clicked(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new LogInPage());
        }

        void Bottone_Log_In_Admin_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AdminMainPage());
        }

        void Bottone_Iscrizione_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageIscrizione());
        }
    }
}
