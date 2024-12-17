using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Models;

namespace Demo.PL.Mapper
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<StoreViewModel, Store>().ReverseMap();
        }
    }
}
