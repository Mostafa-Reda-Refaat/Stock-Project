using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Models;

namespace Demo.PL.Mapper
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemViewModel, Item>().ReverseMap();
        }
    }
}
