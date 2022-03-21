using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FitnessApp.Navigation;
using FitnessApp.Views;

namespace FitnessApp
{
    public partial class App : Application
    {
        IAuth auth;
        public App()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            if (auth.IsSignIn())
            {
                MainPage = new NavigationPage(new ProfilePage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            NavigationDispatcher.Instance.Initialize(MainPage.Navigation);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
