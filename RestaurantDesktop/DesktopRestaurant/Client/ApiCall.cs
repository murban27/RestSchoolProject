using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopRestaurant.Client
{
    class ApiCall : InicializaceClient
    {
        private JsonSerializerSettings JsonSett;
        private StringContent stringContent;
        public Object objec;
        private Values values;
        public ApiCall()
        {
            JsonSett = JsonSettings();



        }

        public async Task<Object> GetMethodAsync(Object obj, string query)
        {
            if(obj.Equals(values))
            {
                obj = new Values();
            }

            HttpResponseMessage httpResponseMessage = await Client.GetAsync(query);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var value = JsonConvert.DeserializeObject<Values>(httpResponseMessage.Content.ToString());
            }
            this.obj=
            return value;
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
