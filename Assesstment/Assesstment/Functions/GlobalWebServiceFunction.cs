using Assesstment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Assesstment.Functions
{
    public class GlobalWebServiceFunction
    {
        static int Total_Product { get; set; } = 0;
        static int Total_Page { get; set; } = 0;


        #region Catalog Web Service
        public static async Task<ObservableCollection<CatalogDataModel>> retrieveCatalogData()
        {
            try
            {
                var authData = string.Format("{0}:{1}", "ck_2682b35c4d9a8b6b6effac126ac552e0bfb315a0", "cs_cab8c9a729dfb49c50ce801a9ea41b577c00ad71");
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));   

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                Uri URIPath = new Uri("https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products?Page=1");

                HttpResponseMessage response = await client.GetAsync(URIPath);

                if (response.IsSuccessStatusCode)
                {
                    var contents = await response.Content.ReadAsStringAsync();

                    IEnumerable<string> headerValues;

                    //Get Total Number Of Products
                    if(response.Headers.TryGetValues("X-WP-Total", out headerValues))
                    {
                        Total_Product = Convert.ToInt32(headerValues.FirstOrDefault());
                    }

                    //Get Total Number Of Pages
                    if (response.Headers.TryGetValues("X-WP-TotalPages", out headerValues))
                    {
                        Total_Page = Convert.ToInt32(headerValues.FirstOrDefault());
                    }

                    var dt = JsonConvert.DeserializeObject<ObservableCollection<CatalogDataModel>>(contents);

                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }
        #endregion
    }
}
