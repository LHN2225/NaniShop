using AutoMapper;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.AutoMapper
{
	public class MappingProfile: Profile
	{
		public MappingProfile()
		{
			CreateMap<CategoryDto, Category>().ReverseMap();
			CreateMap<ProductDto, Product>().ReverseMap();
			CreateMap<RatingDto, Rating>().ReverseMap();
		}
	}
}
