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


        public Command LoginCommand { get; set; }
        public Command SignUpCommand { get; set; }
        


        public LoginPageViewModel()
        {
           
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
                    
                    Application.Current.MainPage = new NavigationShell();
                    await Shell.Current.GoToAsync("//ProfilePage");
                   
                    

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

                    Application.Current.MainPage = new NavigationShell();
                    await Shell.Current.GoToAsync("//ProfilePage");

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

    }
}


