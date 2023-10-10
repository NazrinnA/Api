namespace WebApp.DTOS.Product
{
    public class ProductGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
      //  public Entities.Category Category { get; set; }
    }
}
