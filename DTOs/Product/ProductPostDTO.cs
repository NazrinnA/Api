namespace WebApp.DTOS.Product
{
    public class ProductPostDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
