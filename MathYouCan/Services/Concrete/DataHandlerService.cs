using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MathYouCan.Services.Concrete
{
    public class DataHandlerService
    {
        
        private string _token;
        public void GetLoginResult(string mail, string password)
        {
            using (var client = new HttpClient())
            {

                var values = new Dictionary<string, string>
                {
                    { "email", mail },
                    { "password", password }
                };

                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                var result = client.PostAsync("http://api.mathyoucan.com/User/api/Auth/login", content).Result;

                dynamic data = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
                
                if (result.IsSuccessStatusCode)
                {

                    string stream = data.ToString();

                }
                else
                {
                    MessageBox.Show(data.errors[0].message.ToString());
                }
               
            }
        }
    }
}

//{
// TODO - Send HTTP requests              
//client.BaseAddress = new Uri("http://api.mathyoucan.com/User/api/");
//client.DefaultRequestHeaders.Accept.Clear();
//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//// HTTP POST                
//var body = new Dictionary<string, string>
//{
//    { "email", mail },
//    { "password", password }
//};

//var content = new FormUrlEncodedContent(body);
//    HttpResponseMessage response =  client.PostAsync("Auth/login", content).Result;
//   // if (response.IsSuccessStatusCode)
// //   {
//        string responseStream = response.Content.ReadAsStringAsync().Result;
//        System.Windows.Forms.MessageBox.Show(responseStream);
//  //  }
//}