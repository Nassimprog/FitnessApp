using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessApp.Navigation;
using FitnessApp.Views;

using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class ProfilePageViewModel : ContentPage
    {
        public Command NavigateToTrackerCommand { get; set; }

        public ProfilePageViewModel()
        {
            NavigateToTrackerCommand = new Command(NavigateToTrackerPage);
            
        }
        

        public void NavigateToTrackerPage() //not unit testable
        {
            var trackerpage = new TrackerPage();
            NavigationDispatcher.Instance.Navigation.PushAsync(trackerpage);
        }
    }
}