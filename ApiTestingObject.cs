using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Helpers;

namespace ComprehensiveAssesmentApiTesting_RestSharp_.CommonObjecMethodsFile
{
    public class ApiTestingObject
    {

        public string BaseUrl = "http://www.dummy.restapiexample.com/api";
        public RestResponse response;
        public dynamic id;

        public void GetAllEmployeeData()
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest("/v1/employees", Method.Get);
            response = client.Execute(request);

        }

        public void VerifyGetrequest()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            dynamic value = deserializeAPI.data[0].employee_name;
            Assert.AreEqual("Tiger Nixon", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void GetASingleEmployeeData()
        {
            RestClient client = new RestClient(BaseUrl);
            RestRequest request = new RestRequest("/v1/employee/1", Method.Get);
            response = client.Execute(request);

        }
        public void VerifySinglerequest()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            dynamic value = deserializeAPI.data[0].id;
            Assert.AreEqual("1", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void Post()
        {

            RestClient client = new RestClient(BaseUrl);
            ReadTextFile();
            RestRequest request = new RestRequest("/v1/create"+id, Method.Post);
            request.AddBody("{\"name\":\"RaghavRaj\",\"salary\":\"100000\",\"age\":\"23\"}");
            response = client.Execute(request);
            CreateTextFile();
        }


        public void VerifyPost()
        {

            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            dynamic value = deserializeAPI.data[0].name;
            Assert.AreEqual("RaghavRaj", value.Value);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            id = deserializeAPI.id.Value;
            CreateTextFile();

        }

        public void PUT()
        {   
            RestClient client = new RestClient(BaseUrl);
            ReadTextFile();
            RestRequest request = new RestRequest("/v1/update/21"+id, Method.Put);
           
            request.AddBody("{\"name\":\"RaghavRj\",\"salary\":\"10000\",\"age\":\"22\"}");
            response = client.Execute(request);
            CreateTextFile();
        }


        public void VerifyPut()
        {
            dynamic deserializeAPI = JsonConvert.DeserializeObject(response.Content);
            dynamic value = deserializeAPI.data[0].name;
          
            Assert.AreEqual("RaghavRj", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void DELETE()
        {

            RestClient client = new RestClient(BaseUrl);
            ReadTextFile();
            RestRequest request = new RestRequest("/v1/delete/2"+id, Method.Delete);
            response = client.Execute(request);
        }

        public void VerifyDelete()
        {
         
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }


        public void CreateTextFile()
        {
            string filepath = @"C:\Users\mindtreefeb69\source\repos\ComprehensiveAssesmentApiTesting(RestSharp)\ComprehensiveAssesmentApiTesting(RestSharp)\ComprehensiveAssesmentApiTesting(RestSharp).csproj\Id.txt";
            try
            {
                //Checking if file already exist ,then delete it.
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);

                }
                //create new file 
                using (FileStream fs = File.Create(filepath))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes("Next Text file");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Automation");
                    fs.Write(author, 0, author.Length);
                }
                using (StreamWriter sq = File.CreateText(filepath))
                {
                    sq.WriteLine(id);
                }
            }
            catch
            {
                //
            }

        }

        public void ReadTextFile()
        {
            string filepath = @"C:\Users\mindtreefeb69\source\repos\ComprehensiveAssesmentApiTesting(RestSharp)\ComprehensiveAssesmentApiTesting(RestSharp)\ComprehensiveAssesmentApiTesting(RestSharp).csproj\Id.txt";
            using (StreamReader sr = File.OpenText(filepath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                    id = s;
                }
            }
        }

    }
}
