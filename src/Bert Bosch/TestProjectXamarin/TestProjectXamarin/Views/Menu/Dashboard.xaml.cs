using System;
using TestProjectXamarin.Models;
using TestProjectXamarin.Views.DetailViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;

            App.StartCheckIfInternet(lbl_NoInternet, this);
        }

        async void SelectedScreen1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoScreen1());
        }
    }
}