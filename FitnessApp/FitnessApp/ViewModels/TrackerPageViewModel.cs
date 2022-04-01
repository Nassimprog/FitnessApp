using System;
using FitnessApp.Navigation;
using FitnessApp.Views;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Threading;

namespace FitnessApp.ViewModels
{
    //SensorSpeed speed = SensorSpeed.UI;

    

    public class TrackerPageViewModel : BaseViewModel
    {
        IAuth auth;
        
        public bool EnabledTracking = false;
        private int _Footsteps;
        private int _CaloriesBurned;
        

        public int Footsteps
        {
            get => _Footsteps;
            set
            {
                if (_Footsteps != value)
                {
                    _Footsteps = value;
                    OnPropertyChanged(nameof(Footsteps));
                }
            }
        }
        public int CaloriesBurned
        {
            get => _CaloriesBurned;
            set
            {
                if (_CaloriesBurned != value)
                {
                    _CaloriesBurned = value;
                    OnPropertyChanged(nameof(CaloriesBurned));
                }
            }
        }
        
        public Command BeginTrackerCommand { get; set; }
        public Command StopTrackerCommand { get; set; }

        public Command SignOutCommand { get; set; }

        public TrackerPageViewModel()
        {
            auth = DependencyService.Get<IAuth>();
            SignOutCommand = new Command(SignOutFireBase);
            BeginTrackerCommand = new Command(() =>
            {
                new Thread(() =>
                {
                    
                    BeginTracker();
                }).Start();
            });
            StopTrackerCommand = new Command(StopTracker);
        }

        public void BeginTracker()
        {
            
             // If tracking permission has been given, do
            Accelerometer.ReadingChanged += Accelerometer_readingChanged;
            Accelerometer.Start(SensorSpeed.UI);

            
        }
        

            public void StopTracker()
        {
            Accelerometer.ReadingChanged -= Accelerometer_readingChanged;
            Accelerometer.Stop();
        }
        ///On accelerometer measurements update
        private void Accelerometer_readingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            // if the magnitude of acceleration in the X or Y axis is 1

            if (e.Reading.Acceleration.X >= 0.01 || e.Reading.Acceleration.Y >= 0.01 || e.Reading.Acceleration.X >= -0.01 || e.Reading.Acceleration.Y >= -0.01)
            {
                Footsteps += 1;
                //wait half a second for foot step counter to increase again
                Thread.Sleep(1000000);

                if (Footsteps % 25 == 0)
                    CaloriesBurned += 1;

            }

        }
    }
}