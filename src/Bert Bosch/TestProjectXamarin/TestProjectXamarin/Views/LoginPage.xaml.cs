using System;
using TestProjectXamarin.Models;
using TestProjectXamarin.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;

            ActivitySpinner.IsVisible = false;

            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            App.StartCheckIfInternet(lbl_NoInternet, this);

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);

            if (user.CheckInformation())
            {
                Token token = await App.RestService.Login(user);

                if (token.access_token != null)
                {
                    App.UserDatabase.SaveUser(user);
                    App.TokenDatabase.SaveToken(token);

                    await DisplayAlert("Login", "Login Success", "Ok");

                    if (Device.OS == TargetPlatform.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new MasterDetail());
                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new MasterDetail()));
                    }
                    else
                    {
                        await Navigation.PushAsync(new MasterDetail()); // might not work for UWP
                    }
                }
            }
            else
            {
                await DisplayAlert("Login", "Login Not Correct, empty username or password.", "Ok");
            }
        }
    }
}