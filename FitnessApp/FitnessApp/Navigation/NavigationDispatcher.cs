using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitnessApp.Navigation
{
    public class NavigationDispatcher // No longer needed due to shell compromise
    {
        private static NavigationDispatcher _instance;

        private INavigation _navigation;

        public static NavigationDispatcher Instance =>
                      _instance ?? (_instance = new NavigationDispatcher());

        public INavigation Navigation =>
                     _navigation ?? throw new Exception("NavigationDispatcher is not initialized");

        public void Initialize(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}