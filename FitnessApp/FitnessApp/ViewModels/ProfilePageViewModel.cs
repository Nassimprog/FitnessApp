﻿using System;
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
        public bool LoggedIn = false;

        private double _height;
        private double _weight;
        private double _bmi;

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

        public Command NavigateToTrackerCommand { get; set; }
        public Command CalculateBmiCommand { get; set; }
        public ProfilePageViewModel()
        {
            CalculateBmiCommand = new Command(CalculateBmi, () => {
                return Weight != 0 && Height != 0;
            });
            NavigateToTrackerCommand = new Command(NavigateToTrackerPage);
            
        }

        public void CalculateBmi()
        {
            var meters = Height / 100;
            BMI = Weight / (meters * meters);
        }

        public void NavigateToTrackerPage() //not unit testable
        {
            var trackerpage = new TrackerPage();
            NavigationDispatcher.Instance.Navigation.PushAsync(trackerpage);
        }
    }
}