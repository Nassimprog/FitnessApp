using System;
using FitnessApp.Navigation;
using FitnessApp.Views;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class ProgressPageViewModel : ContentPage
    {
        IAuth auth;

        public Command NavigateToTrackerCommand { get; set; }
        public Command NavigateToProfileCommand { get; set; }
       
        public ProgressPageViewModel()
        {
            auth = DependencyService.Get<IAuth>();
            NavigateToTrackerCommand = new Command(NavigateToTrackerPage);
            NavigateToProfileCommand = new Command(NavigateToProfilePage);
        }

        

        public void NavigateToTrackerPage() //not unit testable
        {
            NavigationDispatcher.Instance.Navigation.PopAsync();
        }
        public void NavigateToProfilePage() //not unit testable
        {
            //NavigationDispatcher.Instance.Navigation.RemovePage(NavigationDispatcher.Instance.Navigation.NavigationStack[0]);
            NavigationDispatcher.Instance.Navigation.PopAsync();
            NavigationDispatcher.Instance.Navigation.PopAsync();
        }

    }
}