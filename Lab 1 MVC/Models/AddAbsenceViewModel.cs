namespace Lab_1_MVC.Models
{
    public class AddAbsenceViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string Reason { get; set; }
        public string Comment { get; set; }
    }
}
