using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpTV.Channels;
using System;

namespace RestSharpTV
{
    [TestClass]
    public class UnitTest1 : BaseClass
    {
        //[TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient("https://mylabs.px.ppe.pearsoncmg.com");

            var req = new RestRequest(Method.GET);

            req.Resource = "/Notifications/api/idlestudent/detail";


            req.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMjUxMDQyIiwicm9sZSI6IjMiLCJGaXJzdE5hbWUiOiJSYWdoYXZlbmRyYSIsIkxhc3ROYW1lIjoiQW5uYWlhaCIsIlVzZXJJRCI6IjIyNTEwNDIiLCJDb3Vyc2VJRCI6IjY0NjM1OSIsIlRpbWVab25lSUQiOiIxMyIsIkFjbElEIjoiMzAwMDAwMDAwMDE1NjQyOCIsIkRlbGl2ZXJ5VHlwZSI6IjEiLCJTZXNzaW9uSUQiOiJ1NTF4Z2dhdXN4dTFyYmZoY2dkaDN6emIiLCJDdXN0b21Mb2NhbGVJbmZvIjoie1wiRGVjaW1hbEZvcm1hdFN0cmluZ1wiOlwiXCIsXCJJbnRlZ2VyRm9ybWF0U3RyaW5nXCI6XCJcIixcIkxvbmdEYXRlRm9ybWF0SURcIjowLFwiTG9uZ0RhdGVQYXR0ZXJuXCI6XCJcIixcIk51bWJlckRlY2ltYWxTZXBhcmF0b3JcIjpcIlwiLFwiTnVtYmVyRm9ybWF0SURcIjowLFwiTnVtYmVyR3JvdXBTZXBhcmF0b3JcIjpcIlwiLFwiU2hvcnREYXRlRm9ybWF0SURcIjowLFwiU2hvcnREYXRlUGF0dGVyblwiOlwiXCIsXCJTaG9ydFRpbWVTdHJpbmdcIjpcIlwiLFwiVGltZUZvcm1hdElEXCI6MH0iLCJuYmYiOjE1MzQxNjcxMDcsImV4cCI6MTUzNDE3ODIwNywiaWF0IjoxNTM0MTY3MTA3LCJpc3MiOiJQZWdhc3VzIiwiYXVkIjoiUGVnYXN1c05vdGlmaWNhdGlvbnMifQ.q5ySMcH0actsJwOI5rNXoDL0PBbsrzOj2oKkZ3bhZDg");

            var res = client.Execute(req);

            var re = res.Content;

            var status = res.ResponseStatus;

            var statusCode = res.StatusCode;

            IRestResponse<IdleStudents> response2 = client.Execute<IdleStudents>(req);

            var results = JsonConvert.DeserializeObject<IdleStudents>(re);

            string ChannelCount = results.ChannelCount;

            int DayCount = results.DayCount;

            var students = results.Students;

            var sdf = new IdleStudents().GetType().GetProperties();

            foreach (var item in sdf)
            {

            }

            foreach (var k in students)
            {
                Console.WriteLine("Email " + k.Email);
                Console.WriteLine("ActivityCount " + k.ActivityCount.ToString());
                Console.WriteLine(k.FirstName);
                Console.WriteLine(k.LastName);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            IdleStudents idle = new IdleStudents();

            var channel = idle.GetValues().Students;

            foreach (var item in channel)
            {
                Console.WriteLine(item.ActivityCount);
                Console.WriteLine(item.Email);
                Console.WriteLine(item.FirstName);
                Console.WriteLine(item.LastName);
                Console.WriteLine(item.TotalSubmissions);
                Console.WriteLine(item.UserId);
            }
        }
    }
}
