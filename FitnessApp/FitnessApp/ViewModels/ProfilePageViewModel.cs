using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessApp.Navigation;
using FitnessApp.Views;

using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        IAuth auth;
        public bool LoggedIn = false;

        private double _height;
        private double _weight;
        private double _bmi;
        private string _weight_unit;
        private string _height_unit;
        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public new double Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    CalculateBmiCommand.ChangeCanExecute();
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    CalculateBmiCommand.ChangeCanExecute();
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }
        public double BMI
        {
            get => _bmi;
            set
            {
                if (_bmi != value)
                {
                    _bmi = value;
                    CalculateBmiCommand.ChangeCanExecute();
                    OnPropertyChanged(nameof(BMI));
                }
            }
        }
        public string WeightUnit
        {
            get => _weight_unit;
            set
            {
                if (_weight_unit != value)
                {
                    _weight_unit = value;
                    CalculateBmiCommand.ChangeCanExecute();
                }
            }
        }

        public string HeightUnit
        {
            get => _height_unit;
            set
            {
                if (_height_unit != value)
                {
                    _height_unit = value;
                    CalculateBmiCommand.ChangeCanExecute();
                }
            }
        }

        readonly Dictionary<string, double> ToUnit = new Dictionary<string, double> // conversions relative to a Kg/M using Google's Unit converter
        {
            { "Kg", 1 }, { "Pound", 2.20462 },
            { "Stone", 0.157473 }, { "M", 1 },
            { "Cm", 100 }, { "Ft", 3.28084 }
        };

        public Command NavigateToTrackerCommand { get; set; }
        public Command CalculateBmiCommand { get; set; }
        public Command SignOutCommand { get; set; }
        public ProfilePageViewModel()
        {
            auth = DependencyService.Get<IAuth>();
            CalculateBmiCommand = new Command(CalculateBmi, () => {
                return Weight != 0 && Height != 0 && WeightUnit != null && HeightUnit != null;
            });
            NavigateToTrackerCommand = new Command(NavigateToTrackerPage);
            SignOutCommand = new Command(SignOutFireBase);




        }

        

        public void CalculateBmi()
        {
            var w_unit = ToUnit[_weight_unit];
            var h_unit = ToUnit[_height_unit];
            // converting to base unit of 1 kg and 1 M by dividing by current Unit value
            var meters = Height / h_unit;
            var kg = Weight / w_unit;
            BMI = Math.Round(((kg) / (meters * meters)),1);
        }

        public void NavigateToTrackerPage() //not unit testable
        {
            var trackerpage = new TrackerPage();
            NavigationDispatcher.Instance.Navigation.PushAsync(trackerpage);
        }
    }
}