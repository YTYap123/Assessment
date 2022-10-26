using Assesstment.Functions;
using Assesstment.Models;
using Assesstment.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Assesstment.ViewModels
{
    public class CatalogViewModel : BaseViewModel
    {
        #region Variables
        LayoutState _currentState = LayoutState.Loading;
        public LayoutState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; OnPropertyChanged(); }
        }

        int _itemThreshold = 4;
        public int ItemThreshold
        {
            get { return _itemThreshold;}
            set { _itemThreshold = value; OnPropertyChanged(); }
        }

        bool _isLoadingMore;
        public bool IsLoadingMore
        {
            get { return _isLoadingMore;}
            set { _isLoadingMore = value; OnPropertyChanged(); }
        }

        int _total_Cart = 0;
        public int Total_Cart
        {
            get { return _total_Cart; }
            set { _total_Cart = value; OnPropertyChanged(); }
        }

        public int Total_CatalogProduct { get; set; } = 0;
        public int Total_CatalogPage { get; set; } = 0;
        public int Initial_CatalogPage { get; set; } = 1;

        public ICommand LoadMoreCommand { get; }
        public ICommand ProductTappedCommand { get; }
        public ICommand CartCommand { get; }

        public ObservableCollection<CatalogModel> catalogModel { get; set; } = new ObservableCollection<CatalogModel>();
        #endregion

        public CatalogViewModel()
        {
            LoadMoreCommand = new Command(LoadMoreCommandFunction);
            ProductTappedCommand = new Command(ProductTappedCommandFunction);
            CartCommand = new Command(CartCommandFunction);

            #region Messaging Center
            MessagingCenter.Unsubscribe<CatalogView, string>(this, "UpdateCatalog");
            MessagingCenter.Subscribe<CatalogView, string>(this, "UpdateCatalog",
            (sender, arg) =>
            {
                Total_Cart = App.cartModel.Count;
            });
            #endregion

            Task.Run(() => StartUp());
        }

        #region Start Up Function
        public async Task StartUp()
        {
            var CatalogFirstLoad = Task.Run(() => GetCatalog(1));

            await CatalogFirstLoad.ContinueWith(antecedent =>
            {
                CurrentState = LayoutState.None;
                Total_CatalogProduct = GlobalWebServiceFunction.Total_CatalogProduct;
                Total_CatalogPage = GlobalWebServiceFunction.Total_CatalogPage;
            });

            var cartModelCount = App.cartModel.Count;
        }
        #endregion


        #region Web Services Function

        #region GetCatalog
        public async Task GetCatalog(int pageNum)
        {
            var dt = await GlobalWebServiceFunction.GetCatalog(pageNum);

            if (dt != null)
            {
                //catalogModel.Clear();

                for (int i = 0; i <dt.Count; i++)
                {
                    if (dt[i].catalog_visibility != "hidden")
                    {
                        dt[i].product_price = Get_product_price(dt[i]);
                        dt[i].product_tag = Get_product_tag(dt[i]);
                        dt[i].product_unit = Get_product_unit(dt[i]);

                        if (dt[i].product_tag != "Promotions")
                        {
                            dt[i].isPromotion = Get_isPromotion(dt[i]);
                        }
                        else
                        {
                            dt[i].isPromotion = true;
                        }

                        catalogModel.Add(dt[i]);
                    }
                    
                }
            }
            else
            {
                //catalogModel.Clear();
            }
        }
        #endregion

        #endregion


        #region Catalog Model Function

        #region Get product_price

        public string Get_product_price(CatalogModel dt)
        {
            if (dt.variations.Count != 0)
            {
                return GlobalFunction.ReturnRMString(dt.variations[0].regular_price);
            }
            else
            {
                //Composite Product
                if (dt.composite_product_details != null)
                {
                    //IsDiscount
                    if(dt.composite_components.Count != 0 && !String.IsNullOrEmpty(dt.composite_components[0].discount))
                    {
                        var discount = dt.composite_components[0].discount;
                        return GlobalFunction.ReturnRMString(discount);
                    }
                    else
                    {
                        if(dt.composite_product_details.components.Count != 0)
                        {
                            var components = dt.composite_product_details.components[0];

                            if(components.products.Count != 0)
                            {
                                var products = components.products[0];
                                var variations = products.variations[0];
                                var regular_price = variations.regular_price;

                                return GlobalFunction.ReturnRMString(regular_price);
                            }
                            else
                            {
                                return "RM 0";
                            }
                        }
                        else
                        {
                            return "RM 0";
                        }
                    }
                }
                //Bundle Product
                else if (dt.bundle_product_details != null)
                {
                    var products = dt.bundle_product_details.products[0].product;
                    var variations = products.variations[0];
                    var regular_price = variations.regular_price;

                    return GlobalFunction.ReturnRMString(regular_price);
                }
                else
                {
                    return "RM 0";
                }
            }
        }

        #endregion

        #region Get product_tag
        public string Get_product_tag(CatalogModel dt)
        {
            if(dt.composite_product_details == null)
            {
                if (dt.categories.Count != 0)
                {
                    var category = dt.categories[0];
                    var categoryName = category.name;

                    if (categoryName.Contains("Consumer"))
                    {
                        return categoryName.Remove(0, 17);
                    }
                    else
                    {
                        return categoryName;
                    }
                }
                else
                {
                    return "Consumer Goods";
                }
            }
            else
            {
                return dt.name;
            }
        }
        #endregion

        #region Get product_tagColor
        public bool Get_isPromotion(CatalogModel dt)
        {
            if (dt.composite_product_details == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Get product_unit
        public string Get_product_unit(CatalogModel dt)
        {
            if (dt.attributes.Count != 0)
            {
                var attribute = dt.attributes[0];
                var unit = attribute.options[0];
                return unit;

            }
            else
            {
                return "Product";
            }
        }
        #endregion


        #endregion


        #region Command Function
        public async void LoadMoreCommandFunction()
        {
            if (Initial_CatalogPage != Total_CatalogPage)
            {
                if (IsLoadingMore)
                return;

                IsLoadingMore = true;
                Initial_CatalogPage++;
                await Task.Run(() => GetCatalog(Initial_CatalogPage));
                IsLoadingMore = false;

            }
        }

        public void ProductTappedCommandFunction(object sender)
        {
            var catalogModel = (CatalogModel)sender;
            GlobalFunction.NavigatePushModalAsync(new CatalogDetailView(catalogModel));
        }

        public void CartCommandFunction()
        {
            GlobalFunction.NavigatePushModalAsync(new CartView());
        }
        #endregion
    }
}
