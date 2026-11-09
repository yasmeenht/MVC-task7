namespace mvc_task7.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}
