using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.RequestVMs
{
    public class EmployeeAddRequestVM
    {
        //[Required]
        //public string image { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string email { get; set; }
        [Required]
        public string designation { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public string position { get; set; }
    }
}
