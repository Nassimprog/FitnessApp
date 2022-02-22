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
       

        public Command NavigateToTrackerCommand { get; set; }
        public Command NavigateToProfileCommand { get; set; }
       
        public ProgressPageViewModel()
        {

            

            NavigateToTrackerCommand = new Command(NavigateToTrackerPage);
            NavigateToProfileCommand = new Command(NavigateToProfilePage);

            
        }

        

        public void NavigateToTrackerPage() //not unit testable
        {
            NavigationDispatcher.Instance.Navigation.PopAsync();
        }
        public void NavigateToProfilePage() //not unit testable
        {
            NavigationDispatcher.Instance.Navigation.PopToRootAsync();
        }

    }
}