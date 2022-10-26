using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Assesstment.Controls
{
    public class LoadingBoxView : BoxView
    {
        public LoadingBoxView()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
            {
                this.FadeTo(0.5, 750, Easing.CubicInOut).ContinueWith((x) =>
                {
                    this.FadeTo(1, 750, Easing.CubicInOut);
                });

                return true;
            });
        }
    }
}
