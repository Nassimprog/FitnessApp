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
            var pages = NavigationDispatcher.Instance.Navigation.NavigationStack.Count;
            for (var i = 1; i < pages; i++)
            {
                var pageToRemove = NavigationDispatcher.Instance.Navigation.NavigationStack.ElementAt(i);
                NavigationDispatcher.Instance.Navigation.RemovePage(pageToRemove);
            }
            NavigationDispatcher.Instance.Navigation.PushAsync(viewToNavigateTo);
            
            
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
                //Application.Current.MainPage = new LoginPage();
                //NavigationDispatcher.Instance.Navigation.PopToRootAsync();
                //NavigationDispatcher.Instance.Initialize(Application.Current.MainPage.Navigation);

                Shell.Current.Navigation.PushModalAsync(new LoginPage());

            }
        }

        


        public BaseViewModel()
        {
            auth = DependencyService.Get<IAuth>();
            

        }
    }
}