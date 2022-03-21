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
    public class BaseViewModel : INotifyPropertyChanged
    {
        IAuth auth;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) // gives the same properties and binding behaviour as seen in Xamarin Forms
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Navigate(Page viewToNavigateTo, List<Object> args) //data that gets carried across pages.
        {
            NavigationDispatcher.Instance.Navigation.PushAsync(viewToNavigateTo);
            // Given the page that is being navigated to
            //switch (nameof(Page))
            //{
            //    case nameof(ProfilePage): // name of view navigated to 
            //        var nameToNavigate = args[0] as insertnamehere; // assign variables of previous page into the new page
            //        NavigationDispatcher.Instance.Navigation.PushAsync(viewToNavigateTo);
            //        break; //says unreachable
            //}
        }

        protected void CheckLoggedIn(bool loggedIn)
        {
            if(!loggedIn)
            {
                //check if logged in if not create on appearing login page
            }
        }

        public void SignOutFireBase()
        {
            var signOut = auth.SignOut();

            if (signOut)
            {
                Application.Current.MainPage = new LoginPage();
            }
        }

        public BaseViewModel()
        {
            auth = DependencyService.Get<IAuth>();
        }
    }
}