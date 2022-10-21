﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assesstment.Controls
{
    public class EmbeddedImage : IMarkupExtension
    {
        public string ResourceID { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(ResourceID))
                return null;
            return ImageSource.FromResource(ResourceID);
        }
    }
}
