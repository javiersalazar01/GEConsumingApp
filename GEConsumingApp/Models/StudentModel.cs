using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEConsumingApp.Models
{
    public class StudentModel
    {
        public int student_id { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> create_on { get; set; }
        public Nullable<System.DateTime> update_on { get; set; }
    }
}