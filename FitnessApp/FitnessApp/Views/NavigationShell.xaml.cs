using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationShell : Shell
    {
        public NavigationShell()
        {

           
            
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));

        }
    }
}