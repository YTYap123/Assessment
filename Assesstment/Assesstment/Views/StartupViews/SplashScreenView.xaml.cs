using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assesstment.Views.StartupViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenView : ContentPage
    {
        public SplashScreenView()
        {
            InitializeComponent();
            ShowAppView();
        }

        public async void ShowAppView()
        {
            await Task.Delay(2000);
            App.Current.MainPage = new LoginView();
        }
    }
}