using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_1_MVC.Models.EmployeeEntities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Absence> List { get; set; }
        public Employee() 
        { 
            List = new List<Absence>();
        }
    }
}
