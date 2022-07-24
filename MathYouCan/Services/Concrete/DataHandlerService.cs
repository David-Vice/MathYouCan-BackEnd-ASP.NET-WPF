using MathYouCan.Models.Exams;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System;
using MathYouCan.Data;

namespace MathYouCan.Services.Concrete
{
    public class DataHandlerService
    {
        
        private string _token;
        private string _uri;

        public DataHandlerService()
        {
            _uri = ApiUri.ActApiUri;
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

        public OfflineExam GetOfflineExam(int examId)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_uri);
                client.DefaultRequestHeaders.Accept.Add(
                   new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
                HttpResponseMessage response = client.GetAsync($"/api/OfflineExams/{examId}").Result;
                response.EnsureSuccessStatusCode();
                string content = response.Content.ReadAsStringAsync().Result;

                OfflineExam offlineExam = JsonConvert.DeserializeObject<OfflineExam>(content);
                return offlineExam;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error message: {ex.Message}\n\nError Stack Trace: {ex.StackTrace}");
                throw;
            }
        }


        /// <summary>
        /// Used in TestSelection.xaml to get all exam names
        /// </summary>
        /// <returns> List of string containing names of the exams </returns>
        public IEnumerable<OfflineExam> GetAllOfflineExams()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_uri);
                client.DefaultRequestHeaders.Accept.Add(
                   new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
                HttpResponseMessage response = client.GetAsync("/api/OfflineExams/ExamDetails").Result;
                response.EnsureSuccessStatusCode();
                string content = response.Content.ReadAsStringAsync().Result;

                IEnumerable<OfflineExam> offlineExams = JsonConvert.DeserializeObject<IEnumerable<OfflineExam>>(content);
                return offlineExams;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error message: {ex.Message}\n\nError Stack Trace: {ex.StackTrace}");
                throw;
            }
        }



        public string GetExamGrade(int sectionId, int correctAnswerNumber)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_uri);
                client.DefaultRequestHeaders.Accept.Add(
                   new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
                HttpResponseMessage response = client.GetAsync($"/api/Results/Grade?sectionId={sectionId}&correctAnswers={correctAnswerNumber}").Result;
                response.EnsureSuccessStatusCode();
                string content = response.Content.ReadAsStringAsync().Result;

                string grade = JsonConvert.DeserializeObject<string>(content);
                return grade;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error message: {ex.Message}\n\nError Stack Trace: {ex.StackTrace}");
                return "-";
            }
        }


    }
}
