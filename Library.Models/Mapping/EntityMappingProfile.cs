using System.Collections.Generic;
using AutoMapper;
using Library.Models.Dtos;
using LibraryData.Models;

namespace Library.Models.Mapping
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<CheckoutHistoryDto, CheckoutHistory>().ReverseMap();
            CreateMap<List<CheckoutHistoryDto>, List<CheckoutHistory>>().ReverseMap();
        }
    }
}