using AutoMapper;
using EntityModels.Models;
using Main.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Mappers
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<ItemInfo, ItemInfoDTO>().ReverseMap();
        }
    }
}
