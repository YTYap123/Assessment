using Assesstment.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Assesstment.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Variables
        public ICommand SignInCommand { get; }
        #endregion

        public LoginViewModel()
        {
            SignInCommand = new Command(SignInCommandFunction);
        }

        #region Command Function
        public async void SignInCommandFunction()
        {
            if (App.isButtonPressed != true)
            {
                App.isButtonPressed = true;
                App.Current.MainPage = new CatalogView();
            }
            await Task.Delay(100);
            App.isButtonPressed = false;
        }
        #endregion
    }
}
