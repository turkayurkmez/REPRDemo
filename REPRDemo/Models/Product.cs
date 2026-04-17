namespace REPRDemo.Models
{
    public class Product
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public decimal Price { get;  set; }
        public object CategoryId { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}
