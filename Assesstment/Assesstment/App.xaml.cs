using Assesstment.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assesstment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CatalogView();
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
