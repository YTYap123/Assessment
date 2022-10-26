using Assesstment.Functions;
using Assesstment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assesstment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogView : ContentPage
    {
        CatalogViewModel catalogViewModel;
        public CatalogView()
        {
            InitializeComponent();
            catalogViewModel = new CatalogViewModel();
            BindingContext = new CatalogViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send<CatalogView, string>(this, "UpdateCatalog", "");
        }
    }
}