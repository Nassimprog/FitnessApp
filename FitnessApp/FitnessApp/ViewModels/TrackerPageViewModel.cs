using System;
using FitnessApp.Navigation;
using FitnessApp.Views;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class TrackerPageViewModel : ContentPage
    {
        IAuth auth;
        public Command NavigateToProgressCommand { get; set; }
        public Command NavigateToProfileCommand { get; set; }

    public TrackerPageViewModel()
        {
            auth = DependencyService.Get<IAuth>();
            NavigateToProgressCommand = new Command(NavigateToProgressPage);
            NavigateToProfileCommand = new Command(NavigateToProfilePage);
        }


        public void NavigateToProgressPage() //not unit testable
        {
            var progresspage = new ProgressPage();
            NavigationDispatcher.Instance.Navigation.PushAsync(progresspage);
        }

        public void NavigateToProfilePage() //not unit testable
        {
            NavigationDispatcher.Instance.Navigation.PopToRootAsync();
        }
    }
}