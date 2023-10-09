using WebApp.Entities;

namespace WebApp.DTOS.Category
{
    public class GetDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Entities.Product> Products { get; set; }
    }
}
