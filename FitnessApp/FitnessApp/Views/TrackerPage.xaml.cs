using FitnessApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackerPage : ContentPage
    {
        public TrackerPage()
        {
            InitializeComponent();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                (BindingContext as TrackerPageViewModel)?.BeginTrackerCommand.Execute(e); // safe cast

            }
            else
            {
                (BindingContext as TrackerPageViewModel)?.StopTrackerCommand.Execute(e);
            }
        }

        
    }
}