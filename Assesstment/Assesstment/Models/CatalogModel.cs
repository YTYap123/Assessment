using System;
using System.Collections.Generic;
using System.Text;

namespace Assesstment.Models
{
    public class CatalogModel
    {
    }

    #region Catalog Data Model
    public class CatalogDataModel
    {
        public string name { get; set; }
        public List<Image> images { get; set; }
        public CompositeProductDetails composite_product_details { get; set; }
        public BundleProductDetails bundle_product_details { get; set; }
    }

    public class Image
    {
        public string src { get; set; }
        public string src_small { get; set; }
        public string src_medium { get; set; }
        public string src_large { get; set; }
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

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public Product product { get; set; }
        public List<Image> images { get; set; }
    }
    #endregion

}
