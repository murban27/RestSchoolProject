using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DesktopRestaurant.Client
{
    public abstract class InicializaceClient
    {
        public HttpClient Client { get; private set; }
        private static string Log = "";

        private static string login { set; get; }    //UserName 
        private static string heslo { get; set; }   //Password


        /*---------------------------------------------------------
         * This class is used for authorization client
         * Auth method for Restaurant
         *---------------------------------------------------------*/

        public InicializaceClient()
        {

            Client = new HttpClient();
            SetProperties();

        }

        public static string UserName
        {
            get { return login; }
            set { login = value; }

        }
        public static string Heslo { get { return heslo; } set { heslo = value; } }
        /// <summary>
        /// SetBasicAuthorazionValues
        /// </summary>
        public void SetProperties()
        {

          
            var AuthValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("murban27" +":"+"Tesco123")));
            this.Client = new HttpClient() { DefaultRequestHeaders = { Authorization = AuthValue }, BaseAddress = new Uri("http://localhost:49861") };
            Client.DefaultRequestHeaders.Accept.Add(
     new MediaTypeWithQualityHeaderValue("application/json"));
        }









    }
}
