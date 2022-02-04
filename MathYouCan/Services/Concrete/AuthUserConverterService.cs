using MathYouCan.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MathYouCan.Services.Concrete
{
    public static class AuthUserConverterService
    {
        public static object GetData(string jsonContent)
        {
            dynamic data = JsonConvert.DeserializeObject(jsonContent);
            if (data.errors==null)
            {
                //  data = JsonConvert.DeserializeObject<User>(jsonContent);
                //...
                return null;
            }
            else
            {
                
                MessageBox.Show(data.errors[0].message.ToString(),"Error");
                return null;
            }
            
        }
    }
}
