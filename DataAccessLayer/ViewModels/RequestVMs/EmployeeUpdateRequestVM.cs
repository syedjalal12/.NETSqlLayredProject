using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.RequestVMs
{
    public class EmployeeUpdateRequestVM
    {
        //public string image { get; set; }
        public string name { get; set; }
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string email { get; set; }
        public string designation { get; set; }
        public string department { get; set; }
        public string position { get; set; }
    }
}
