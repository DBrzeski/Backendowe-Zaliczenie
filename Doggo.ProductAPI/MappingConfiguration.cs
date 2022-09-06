using AutoMapper;
using Doggo.ProductAPI.Models;
using Doggo.ProductAPI.Models.Dto;
using Doggo.ProductAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.ProductAPI
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ItemDto, Item>();
                config.CreateMap<Item, ItemDto>();
            });

            return mappingConfig;
        }
    }
}
