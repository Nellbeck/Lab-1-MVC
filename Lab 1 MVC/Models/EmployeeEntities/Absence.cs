using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_1_MVC.Models.EmployeeEntities
{
    public class Absence
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart {  get; set; }
        public DateTime DateEnd { get; set; }
        public double TotalDays { get; set; }
        public DateTime Date {  get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }

    }
}
