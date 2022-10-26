using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assesstment.Functions
{
    public class GlobalFunction
    {
        #region Page Navigation

        #region Pop Async
        public static async void NavigatePopModalAsync()
        {
            if (App.isButtonPressed != true)
            {
                App.isButtonPressed = true;
                await App.Current.MainPage.Navigation.PopModalAsync();
            }
            await Task.Delay(500);
            App.isButtonPressed = false;
        }
        #endregion

        #region Navigate To Page (Push Modal Async)
        public static async void NavigatePushModalAsync(Page navigationPage)
        {
            if (App.isButtonPressed != true)
            {
                App.isButtonPressed = true;
                await App.Current.MainPage.Navigation.PushModalAsync(navigationPage);
            }
            await Task.Delay(500);
            App.isButtonPressed = false;
        }
        #endregion

        #endregion

        #region Return RM String
        public static string ReturnRMString(string price)
        {
            var RMprice = "RM " + price;
            return RMprice;
        }
        #endregion
    }
}
