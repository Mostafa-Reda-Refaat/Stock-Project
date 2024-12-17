using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Models;

namespace Demo.PL.Mapper
{
    public class ItemStockProfile : Profile
    {
        public ItemStockProfile() 
        {
            CreateMap<ItemStockViewModel, ItemStock>().ReverseMap();
        }
    }
}
