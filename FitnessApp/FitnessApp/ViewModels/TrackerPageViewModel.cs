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

    

    public class TrackerPageViewModel : BaseViewModel
    {
        IAuth auth;
        public bool EnabledTracking = false;
        public int Footsteps = 0;
        public Command NavigateToProgressCommand { get; set; }
        public Command BeginTrackerCommand { get; set; }

        public Command SignOutCommand { get; set; }

        public TrackerPageViewModel()
        {
            auth = DependencyService.Get<IAuth>();
            SignOutCommand = new Command(SignOutFireBase);
        }

        public void BeginTracker()
        {
             // If tracking permission has been given, do
            
            Accelerometer.ReadingChanged += Accelerometer_readingChanged;
            Accelerometer.Start(SensorSpeed.UI);
            
                
            Accelerometer.ReadingChanged -= Accelerometer_readingChanged;
            Accelerometer.Stop();
            
        }
        ///On accelerometer measurements update
        private void Accelerometer_readingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            // if the magnitude of acceleration in the X or Y axis is 1
            if (e.Reading.Acceleration.X >= 1 || e.Reading.Acceleration.Y >= 1 || e.Reading.Acceleration.X >= -1 || e.Reading.Acceleration.Y >= -1)
            {

            }
        }
    }
}