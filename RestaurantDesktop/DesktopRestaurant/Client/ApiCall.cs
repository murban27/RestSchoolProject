using DesktopRestaurant.OBJECTS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DesktopRestaurant.Client
{
    class ApiCall : InicializaceClient
    {
        private JsonSerializerSettings JsonSett;
        private StringContent stringContent;
        public Object objec;
        private DenZakObj values;
        private Tables table;
        public ApiCall()
        {
            JsonSett = JsonSettings();
            /*   values = new DenZakObj();
               table = new Tables();*/
            values = new DenZakObj();
            table = new Tables();

        }

        public async Task<Object> GetMethodAsync(Object Obj, string query)
        {

            

            if (Obj.Equals(values))
            {
                Obj = new DenZakObj();
            }
            if(Obj.GetType().ToString()==table.GetType().ToString())
            {
                Obj = new Tables();
            }

            HttpResponseMessage httpResponseMessage =  Client.GetAsync(query).Result;


            if (httpResponseMessage.IsSuccessStatusCode)
            {


              List<Tables> table=  JsonConvert.DeserializeObject<List<Tables>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
                return table;
            }
            return null;
        
        }



        private JsonSerializerSettings JsonSettings()
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonSerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            return jsonSerializerSettings;


        }
        public async Task<string> ContentToString(HttpContent httpContent)
        {

            var readAsStringAsync = await httpContent.ReadAsStringAsync();
          
            return readAsStringAsync;
        }

    }
}
