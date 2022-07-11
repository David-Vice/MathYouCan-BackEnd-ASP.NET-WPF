using MathYouCan.Models.Exams;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MathYouCan.Services.Concrete
{
    public class DataHandlerService
    {
        
        private string _token;
        private string _url;

        public DataHandlerService()
        {
            _url = "https://bsite.net/Kanan02/api";
        }

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

        public async Task<OfflineExam> GetOfflineExam(int examId)
        {


            return null;
        }


        /// <summary>
        /// Used in TestSelection.xaml to get all exam names
        /// </summary>
        /// <returns> List of string containing names of the exams </returns>
        public void GetAllOfflineExamNames()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(_url);
            client.DefaultRequestHeaders.Accept.Add(
               new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
            var response = client.GetStringAsync("/OfflineExams/ExamDetails").Result;
            IEnumerable<OfflineExam> offlineExam = JsonConvert.DeserializeObject<IEnumerable<OfflineExam>>(response);
      
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