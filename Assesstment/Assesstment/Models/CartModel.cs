using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assesstment.Models
{
    public class CartModel : BaseModel
    {
        public string id { get; set; }
        public CatalogModel catalogModel { get; set; }

        int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); }
        }

        bool _isChecked;
        public bool isChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; OnPropertyChanged(); }
        }
    }
}
