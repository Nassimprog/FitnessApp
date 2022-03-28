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
            MainPage = new LoginPage();
            
            if (auth.IsSignIn())
            {
                //NavigationDispatcher.Instance.Navigation.PushAsync(new ProfilePage());
            }
           
            
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
