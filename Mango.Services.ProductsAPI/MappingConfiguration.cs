﻿using AutoMapper;
using Mango.Services.ProductsAPI.Models;
using Mango.Services.ProductsAPI.Models.Dto;

namespace Mango.Services.ProductsAPI
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config
                .CreateMap<ProductDto, Product>()
                .ReverseMap();
            });
            return mappingConfig;   
        }   
    }
}
