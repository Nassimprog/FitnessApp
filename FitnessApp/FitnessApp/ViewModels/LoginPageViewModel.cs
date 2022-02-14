﻿using FitnessApp.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public Command NavigateToProfileCommand { get; set; }
        public LoginPageViewModel()
        {
            NavigateToProfileCommand = new Command(NavigateToProfile);
        }
        public void NavigateToProfile() //not unit testable since it uses xamarin forms
        {
            var nextPage = new NextPage();
            NavigationDispatcher.Instance.Navigation.PushAsync(nextPage);
        }
        
    }
}