using Assesstment.Models;
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
	public partial class CatalogDetailView : ContentPage
	{
		public CatalogDetailView (CatalogModel dt)
		{
			InitializeComponent();
			this.BindingContext = new CatalogDetailViewModel(dt);
		}
	}
}