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

      

        

        public void SignOutFireBase()
        {
            var signOut = auth.SignOut();

            if (signOut)
            {
                
                Shell.Current.Navigation.PushModalAsync(new LoginPage());

            }
        }

        


        public BaseViewModel()
        {
            auth = DependencyService.Get<IAuth>();
            

        }
    }
}