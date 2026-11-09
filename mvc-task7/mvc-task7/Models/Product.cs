namespace mvc_task7.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Category Category { get; set; }
        public int CategoryID { get; set; }


        public Supplier Supplier { get; set; }
        public int SupplierID { get; set; }

    }
}
