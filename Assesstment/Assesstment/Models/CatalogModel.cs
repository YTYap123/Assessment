using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Assesstment.Models
{
    #region Catalog Model
    public class CatalogModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string catalog_visibility { get; set; }
        public CompositeProductDetails composite_product_details { get; set; }
        public BundleProductDetails bundle_product_details { get; set; }
        public List<Attribute> attributes { get; set; }
        public List<Image> images { get; set; }
        public List<Variation> variations { get; set; }
        public List<Category> categories { get; set; }
        public List<CompositeComponent> composite_components { get; set; }


        public string product_price { get; set; }
        public string product_tag { get; set; }
        public string product_unit { get; set; }
        public bool isPromotion { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public Product product { get; set; }

        public List<Attribute> attributes { get; set; }
        public List<Image> images { get; set; }
        public List<Variation> variations { get; set; }

    }

    public class Attribute
    {
        public string name { get; set; }
        public int position { get; set; }
        public bool visible { get; set; }
        public bool variation { get; set; }
        public List<string> options { get; set; }
    }

    public class Image
    {
        //string _src { get; set; }
        //public string src
        //{
        //    get { return _src; }
        //    set { _src = value; OnPropertyChanged(); }
        //}

        public string src { get; set; }
        public string src_small { get; set; }
        public string src_medium { get; set; }
        public string src_large { get; set; }


        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
    public class CompositeProductDetails
    {
        public string per_item_pricing { get; set; }
        public List<Component> components { get; set; }
    }

    public class BundleProductDetails
    {
        public bool per_item_pricing { get; set; }
        public List<Product> products { get; set; }
    }

    public class Component
    {
        public string name { get; set; }
        public List<Product> products { get; set; }
    }

    public class CompositeComponent
    {
        public string discount { get; set; }
        public string options_style { get; set; }
    }

    public class Variation
    {
        public string regular_price { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public string slug { get; set; }
    }
   
    #endregion

}
