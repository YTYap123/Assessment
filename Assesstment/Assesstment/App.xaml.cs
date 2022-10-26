using Assesstment.Models;
using Assesstment.Views;
using Assesstment.Views.StartupViews;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace Assesstment
{
    public partial class App : Application
    {
        #region Variables
        public static bool isButtonPressed { get; set; } = false;

        public static ObservableCollection<CartModel> cartModel = new ObservableCollection<CartModel>();

        #endregion

        public App()
        {
            InitializeComponent();

            MainPage = new SplashScreenView();
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

        #region Functions
        public static void AddToCart(CatalogModel catalogModel, int Quantity)
        {
            CartModel _cartModel = new CartModel()
            {
                id = catalogModel.id,
                catalogModel = catalogModel,
                Quantity = Quantity
            };

            var exisiting_cart = cartModel.FirstOrDefault(x => x.id == _cartModel.id);

            if (exisiting_cart != null)
            {
                exisiting_cart.Quantity = exisiting_cart.Quantity + Quantity;
            }
            else
            {
                cartModel.Add(_cartModel);
            }
            App.Current.MainPage.DisplayAlert("Successful", "Added To Cart", "Ok");
        }
        #endregion

    }
}
