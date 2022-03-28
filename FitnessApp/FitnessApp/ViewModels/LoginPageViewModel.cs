using System;
using FitnessApp.Navigation;
using FitnessApp.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        IAuth auth;

        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
        public string SignUpEmail { get; set; }
        public string SignUpPassword { get; set; }


        public Command NavigateToProfileCommand { get; set; }
        public Command LoginCommand { get; set; }
        public Command SignUpCommand { get; set; }
        public Command SignOutCommand { get; set; }


        public LoginPageViewModel()
        {
            NavigateToProfileCommand = new Command(NavigateToProfile);
            auth = DependencyService.Get<IAuth>(); // initialise auth service
            LoginCommand = new Command(async () => await LoginFireBase());
            SignUpCommand = new Command(async () => await SignUpFireBase());
            

        }


        private async Task LoginFireBase()
        {
            if(LoginEmail != null && LoginPassword != null) //makes sure its not empty
            {
                string token = await auth.LoginWithEmailAndPassword(LoginEmail, LoginPassword);
                if (token != string.Empty)
                {
                    //await App.Current.MainPage.DisplayAlert("Uid", token, "Ok");
                    Application.Current.MainPage = new NavigationShell();
                    await Shell.Current.GoToAsync("//ProfilePage");
                    //NavigationDispatcher.Instance.Initialize(Application.Current.MainPage.Navigation);
                    

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Authentication Failed", "Email or Password are incorrect", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Authentication Failed", "please fill out all fields", "OK");
            }
            
        }

        private async Task SignUpFireBase()
        {
            if (SignUpEmail != null && SignUpPassword != null)
            {
                string token = await auth.SignUpWithEmailAndPassword(SignUpEmail, SignUpPassword);
                if (token != string.Empty)
                {
                    //await App.Current.MainPage.DisplayAlert("Uid", token, "Ok");
                    Application.Current.MainPage = new ProfilePage();
                    NavigationDispatcher.Instance.Initialize(Application.Current.MainPage.Navigation);

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("New Account Created, Login to continue.", token, "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Authentication Failed", "please fill out all fields", "OK");
            }

        }



        



        public void NavigateToProfile() //not unit testable
        {
            var profilepage = new ProfilePage();
            NavigationDispatcher.Instance.Navigation.PushAsync(profilepage);
        }

    }
}


