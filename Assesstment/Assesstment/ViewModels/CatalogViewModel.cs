using Assesstment.Functions;
using Assesstment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Assesstment.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        #region Variables
        public ObservableCollection<CatalogDataModel> catalogData { get; set; } = new ObservableCollection<CatalogDataModel>();

        public string testing { get; set; } = "asd";
        #endregion

        public CatalogViewModel()
        {
            Task.Run(() => retrieveCatalogData());
        }

        #region Web Services

        #region Retrieve Catalog Data
        public async Task retrieveCatalogData()
        {
            var dt = await GlobalWebServiceFunction.retrieveCatalogData();

            if (dt != null)
            {
                catalogData.Clear();

                for (int i = 0; i <dt.Count; i++)
                {
                    catalogData.Add(dt[i]);
                }
            }
            else
            {
                catalogData.Clear();
            }
        }
        #endregion

        #endregion
    }
}
