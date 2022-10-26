using Assesstment.Functions;
using Assesstment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assesstment.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        #region Variables
        public double TotalCartPrice_double { get; set; }

        string _totalCartPrice_string = "RM 0.00";
        public string TotalCartPrice_string
        {
            get { return _totalCartPrice_string; }
            set { _totalCartPrice_string = value; OnPropertyChanged(); }
        }

        bool _isChecked = true;
        public bool isChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; OnPropertyChanged(); }
        }

        public ICommand BackCommand { get; }
        public ICommand CheckOutCommand { get; }
        public ICommand AddQuantityCommand { get; }
        public ICommand SubtractQuantityCommand { get; }


        public ObservableCollection<CartModel> cartModel { get; set; }
        #endregion

        public CartViewModel()
        {
            BackCommand = new Command(BackCommandFunction);
            CheckOutCommand = new Command(CheckOutCommandFunction);
            AddQuantityCommand = new Command(AddQuantityCommandFunction);
            SubtractQuantityCommand = new Command(SubtractQuantityCommandFunction);

            cartModel = App.cartModel;
            StartUp();
        }

        #region Start Up Function
        public void StartUp()
        {
            TotalCartPrice_string = Get_TotalCartPrice_Double();
        }
        #endregion

        #region Function
        public string Get_TotalCartPrice_Double()
        {
            if(cartModel.Count != 0)
            {
                for (int i = 0; i < cartModel.Count; i++)
                {
                    var cart_price = Convert.ToDouble(cartModel[i].catalogModel.product_price.Remove(0, 3));
                    TotalCartPrice_double = TotalCartPrice_double + (cart_price * cartModel[i].Quantity);
                }

                return GlobalFunction.ReturnRMString(TotalCartPrice_double.ToString());
            }
            else
            {
                TotalCartPrice_double = 0;
                return "RM 0.00";
            }
        }
        #endregion

        #region Command Function
        public async void AddQuantityCommandFunction(object sender)
        {
            if (App.isButtonPressed != true)
            {
                App.isButtonPressed = true;

                var _cartModel = (CartModel)sender;
                var exisiting_cart = cartModel.FirstOrDefault(x => x.id == _cartModel.id);

                if (exisiting_cart != null && exisiting_cart.Quantity != 99)
                {
                    exisiting_cart.Quantity++;
                    var cart_price = Convert.ToDouble(exisiting_cart.catalogModel.product_price.Remove(0, 3));
                    TotalCartPrice_double = Math.Round(Convert.ToDouble(TotalCartPrice_string.Remove(0, 3)) - cart_price, 2);
                    TotalCartPrice_string = GlobalFunction.ReturnRMString(TotalCartPrice_double.ToString());
                }
            }
            await Task.Delay(100);
            App.isButtonPressed = false;
        }

        public async void SubtractQuantityCommandFunction(object sender)
        {
            if (App.isButtonPressed != true)
            {
                App.isButtonPressed = true;

                var _cartModel = (CartModel)sender;
                var exisiting_cart = cartModel.FirstOrDefault(x => x.id == _cartModel.id);

                if (exisiting_cart != null && exisiting_cart.Quantity != 1)
                {
                    exisiting_cart.Quantity--;
                    var cart_price = Convert.ToDouble(exisiting_cart.catalogModel.product_price.Remove(0, 3));
                    TotalCartPrice_double = Math.Round(Convert.ToDouble(TotalCartPrice_string.Remove(0, 3)) - cart_price, 2);
                    TotalCartPrice_string = GlobalFunction.ReturnRMString(TotalCartPrice_double.ToString());
                }
                else
                {
                    if(exisiting_cart != null && exisiting_cart.Quantity == 1)
                    {
                        bool answer = await App.Current.MainPage.DisplayAlert("Confirm to delete?", "Are you sure you want to delete this 1 item(s) from cart?", "Yes", "No");
                        if (answer == true)
                        {
                            var cart_price = Convert.ToDouble(exisiting_cart.catalogModel.product_price.Remove(0, 3));
                            TotalCartPrice_double = Math.Round(Convert.ToDouble(TotalCartPrice_string.Remove(0, 3)) - cart_price, 2);
                            TotalCartPrice_string = GlobalFunction.ReturnRMString(TotalCartPrice_double.ToString());
                            cartModel.Remove(exisiting_cart);

                            if (cartModel.Count == 0)
                            {
                                TotalCartPrice_double = 0;
                                TotalCartPrice_string = "RM 0.00";
                            }
                        }
                    }
                }
            }
            await Task.Delay(100);
            App.isButtonPressed = false;
        }

        public void BackCommandFunction()
        {
            GlobalFunction.NavigatePopModalAsync();
        }

        public async void CheckOutCommandFunction()
        {
            if(cartModel.Count != 0)
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Confirm to check out?", "Are you sure you want to check out all the item(s) in cart?", "Yes", "No");
                if (answer == true)
                {
                    cartModel.Clear();
                    TotalCartPrice_double = 0;
                    TotalCartPrice_string = "RM 0.00";
                    await App.Current.MainPage.DisplayAlert("Successful", "Check Out Successfully!", "Ok");
                }
            }
        }
        #endregion

    }
}
