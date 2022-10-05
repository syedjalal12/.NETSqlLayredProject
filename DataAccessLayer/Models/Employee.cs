using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;
public class Employee
{
    [Key]
    public string Id { get; set; }
    //[Required]
    //public string image { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Designation { get; set; }
    [Required]
    public string Department { get; set; }
    [Required]
    public string Position { get; set; }
    [Required]
    public bool Active { get; set; }

}
