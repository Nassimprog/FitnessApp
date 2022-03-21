using System;
using FitnessApp.Navigation;
using FitnessApp.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FitnessApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        IAuth auth;
        List<object> LoginPageData = new List<object>();


        public Command NavigateToProfileCommand { get; set; }

        public LoginPageViewModel()
        {
            NavigateToProfileCommand = new Command(NavigateToProfile);
            auth = DependencyService.Get<IAuth>(); // initialise auth service
        }


        //async Task LoginClicked(object sender, EventArgs e)
        //{
        //    string token = await auth.LoginWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);
        //    if (token != string.Empty)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Uid", token, "Ok");
        //        Application.Current.MainPage = new ProfilePage();
        //    }
        //    else
        //    {
        //        await App.Current.MainPage.DisplayAlert("Authentication Failed", "Email or Password are incorrect", "OK");
        //    }
        //}

        // Task SignUpClicked(object sender, EventArgs e)
        //{
        //    var signOut = auth.SignOut();
        //
        //    if (signOut)
        //    {
        //      Application.Current.MainPage = new LoginPage();
        //    }
        //}



        public void NavigateToProfile() //not unit testable
        {
            var profilepage = new ProfilePage();
            NavigationDispatcher.Instance.Navigation.PushAsync(profilepage);
        }

    }
}


