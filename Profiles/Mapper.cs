using AutoMapper;
using WebApp.DTOS.Category;
using WebApp.DTOS.Product;
using WebApp.Entities;

namespace WebApp.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<PostDTO, Category>();
            CreateMap<Category, GetDTO>();
            CreateMap<UpdateDTO, Category>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductGetDTO>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<ProductPostDTO, Product>();

        }
    }
}
