using AutoMapper;
using DB_Layer.Models;
using Microsoft.Extensions.Logging;
using Services_Layer.DTOS.Branches;
using Services_Layer.DTOS.Distributor;
using Services_Layer.DTOS.Orders;
using Services_Layer.DTOS.Pharmacies;
using Services_Layer.DTOS.Products;
using Services_Layer.DTOS.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pharmacy, GetPharmciesWithCountry>();
            CreateMap<GetPharmciesWithCountry, Pharmacy>();

            CreateMap<CustomUser, UserDTO>();
            CreateMap<UserDTO, CustomUser>();

            CreateMap<Order, GetOrderDTO>();

            CreateMap<CountryDTO, Country>();
            CreateMap<DistributorDTO, Distributor>();
            CreateMap<RoleDTO, Role>();
           // CreateMap<BranchDTO, Branch>();
            CreateMap<BranchDTO, Branch>().ForMember(dest => dest.ConId, opt => opt.MapFrom(src => src.Country_id)).ForMember(dest => dest.DisId, opt => opt.MapFrom(src => src.Distributor_id));
           // CreateMap<UpdateBranchDTO, Branch>();
            CreateMap<UpdateBranchDTO, Branch>().ForMember(dest => dest.ConId, opt => opt.MapFrom(src => src.Country_id)).ForMember(dest => dest.DisId, opt => opt.MapFrom(src => src.Distributor_id));



            CreateMap<UpdateCountryDTO, Country>();
            CreateMap<UpdateRoleDTO, Role>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<UpdateDistributorDTO, Distributor>();


            CreateMap<AddOrderDTO, Order>();

            CreateMap<OrderProductsDTO, Order_Products>();
            CreateMap<Order_Products,OrderProductsDTO>();

            CreateMap<UpdateOrderDTO, Order>();

            


            CreateMap<Branch, BranchWithDistributorAndCountry>();

            

            CreateMap<AddPharmacyDTO, Pharmacy>().ForMember(dest => dest.ConId, opt => opt.MapFrom(src => src.Country_id)); 
            CreateMap<UpdatePharmacyDTO, Pharmacy>().ForMember(dest => dest.ConId, opt => opt.MapFrom(src => src.Country_id)); 


            //CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }




    }
}
