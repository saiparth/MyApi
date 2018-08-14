using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace RestSharpTV.Channels
{
    ///Notifications/api/idlestudent/count

    /*
     * {
     * "DaysScale":"Month","DayCount":1,"Students":[{"UserId":2251043,"FirstName":"Raghavendra1","LastName":"Annaiah1","Email":"raghavendra.ga@excelindia.com","ActivityCount":0,"TotalSubmissions":0},{"UserId":2251045,"FirstName":"Raghavendra3","LastName":"Annaiah3","Email":"raghavendra.ga@excelindia.com","ActivityCount":0,"TotalSubmissions":0}]}
     */

    public class IdleStudents : BaseClass
    {
        public string ChannelCount { get; set; }

        public string DaysScale { get; set; }

        public int DayCount { get; set; }

        public IList<Student> Students { get; set; }

        public class Student
        {
            public long UserId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public int ActivityCount { get; set; }

            public int TotalSubmissions { get; set; }
        }

        /// <summary>
        /// makes api call and deserializes responses according to cllass variables
        /// </summary>
        /// <returns></returns>
        public IdleStudents GetValues()
        {
            var Resource = GetConfigValue("IdleStudentApiPath");

            string header = GetConfigValue("header");

            var token = GetConfigValue("AccessToken"); 

            var holder = GetResponse(Method.GET, Resource, header, token);

            var results = JsonConvert.DeserializeObject<IdleStudents>(holder.Content);

            return results;
        }
    }
}