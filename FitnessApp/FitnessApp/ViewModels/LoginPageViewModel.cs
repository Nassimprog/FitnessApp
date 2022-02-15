using FitnessApp.Navigation;
using FitnessApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        List<object> LoginPageData = new List<object>();
        

        public Command NavigateToProfileCommand { get; set; }
        public LoginPageViewModel()
        {
            NavigateToProfileCommand = new Command(NavigateToProfile);
        }
        public void NavigateToProfile() //not unit testable since it uses xamarin forms
        {
            var profilepage = new ProfilePage();
            Navigate(profilepage, LoginPageData);
        }
        
    }
}