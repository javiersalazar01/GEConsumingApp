using GEConsumingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GEConsumingApp.BussinesObjects
{
    public class StudentClient
    {
        private const string Base_URL = "http://localhost:52635";
        

        public StudentClient()
        {
            
        }
        

        public IEnumerable<StudentModel> GetAll()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Base_URL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync("api/student").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string resp = response.Content.ReadAsStringAsync().Result;

                        return JsonConvert.DeserializeObject<IEnumerable<StudentModel>>(resp);

                    }

                    return new List<StudentModel>();
                }
                
            }
            catch(Exception e)
            {
                return new List<StudentModel>();
            }
        }


        public StudentModel Find(int? id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/student/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string resp = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<StudentModel>(resp);
                }

                    
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Create(StudentModel customer)
        {
            try
            {
                var stringPayload = JsonConvert.SerializeObject(customer);

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Base_URL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsync("api/student", httpContent).Result;
                    return response.IsSuccessStatusCode;
                }
                
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(StudentModel student)
        {
            try
            {
                var stringPayload = JsonConvert.SerializeObject(student);

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Base_URL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PutAsync("api/student/" + student.student_id, httpContent).Result;
                    return response.IsSuccessStatusCode;
                }
                
                
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("api/student/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }*/



    }
}