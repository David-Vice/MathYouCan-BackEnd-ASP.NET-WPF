using MathYouCan.Services.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MathYouCan.Services.Concrete
{
    public class AuthValidatorService:IAuthValidatorService
    {
        private static readonly HttpClient client = new HttpClient();

        public string AreValidCredentials(string mail, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "email", mail },
                { "password", password }
            };

            var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
            var result = client.PostAsync("http://api.mathyoucan.com/User/api/Auth/login", content).Result;
            return result.Content.ReadAsStringAsync().Result;

        }
    }
}
