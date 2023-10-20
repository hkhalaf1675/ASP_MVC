namespace Day9_Lab_Identity.Models.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
