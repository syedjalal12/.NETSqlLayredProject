using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.ResponseVMs
{
    public class EmployeeGetResponseVM
    {
        public string id { get; set; }
        //public string image { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string designation { get; set; }
        public string department { get; set; }
        public string position { get; set; }
    }
}
