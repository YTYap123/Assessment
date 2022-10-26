using Assesstment.Models;
using Assesstment.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assesstment.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartView : ContentPage
	{
		public CartView ()
		{
			InitializeComponent ();
			this.BindingContext = new CartViewModel();
		}

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
			CartViewModel cartViewModel = new CartViewModel();
			cartViewModel.TotalCartPrice_string = "asd";
        }
    }
}