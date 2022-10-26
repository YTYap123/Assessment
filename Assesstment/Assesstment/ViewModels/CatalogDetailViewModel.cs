using Assesstment.Functions;
using Assesstment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assesstment.ViewModels
{
    public class CatalogDetailViewModel : BaseViewModel
    {
        #region Variables
        int _quantity = 1;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); }
        }

        public ICommand BackCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand AddQuantityCommand { get; }
        public ICommand SubtractQuantityCommand { get; }

        public CatalogModel CatalogModel { get; set; }

        #endregion

        public CatalogDetailViewModel(CatalogModel dt)
        {
            BackCommand = new Command(BackCommandFunction);
            AddToCartCommand = new Command(AddToCartCommandFunction);
            AddQuantityCommand = new Command(AddQuantityCommandFunction);
            SubtractQuantityCommand = new Command(SubtractQuantityCommandFunction);

            CatalogModel = dt;
        }

        #region Command Function
        public async void AddToCartCommandFunction()
        {
            if (App.isButtonPressed != true)
            {
                App.isButtonPressed = true;
                App.AddToCart(CatalogModel, Quantity);
            }
            await Task.Delay(100);
            App.isButtonPressed = false;
        }

        public async void AddQuantityCommandFunction()
        {
            if (App.isButtonPressed != true)
            {
                App.isButtonPressed = true;
                if (Quantity != 99)
                {
                    Quantity++;
                }
            }
            await Task.Delay(100);
            App.isButtonPressed = false;
        }

        public async void SubtractQuantityCommandFunction()
        {
            if (App.isButtonPressed != true)
            {
                App.isButtonPressed = true;
                if (Quantity != 1)
                {
                Quantity--;
                }
            }
            await Task.Delay(100);
            App.isButtonPressed = false;
        }
        public void BackCommandFunction()
        {
            GlobalFunction.NavigatePopModalAsync();
        }
        #endregion
    }
}
