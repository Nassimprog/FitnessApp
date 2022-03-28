using System;
using FitnessApp.Navigation;
using FitnessApp.Views;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace FitnessApp.ViewModels
{
    //SensorSpeed speed = SensorSpeed.UI;

    

    public class TrackerPageViewModel : ContentPage
    {
        IAuth auth;
        public Command NavigateToProgressCommand { get; set; }
        

    public TrackerPageViewModel()
        {
            auth = DependencyService.Get<IAuth>();
            //NavigateToProgressCommand = new Command(NavigateToProgressPage);
        }


        

        
    }
}