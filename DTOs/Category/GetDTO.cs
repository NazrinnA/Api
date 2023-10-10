using WebApp.Entities;

namespace WebApp.DTOS.Category
{
    public class GetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Entities.Product> Products { get; set; }
    }
}
