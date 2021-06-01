using AutoMapper;
using basket.Entities;
using basket.Models;

namespace basket.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Basket, BasketDTO>()
                   .ForMember(dto => dto.Total, opt => opt.Ignore());

            CreateMap<BasketDTO, Basket>();

            CreateMap<Item, ItemDTO>()
                .ForMember(dto => dto.ProductId, itm => itm.MapFrom(ps => ps.Product.Id))
                .ForMember(dto => dto.Description, itm => itm.MapFrom(ps => ps.Product.Description))
                .ForMember(dto => dto.Price, itm => itm.MapFrom(ps=>ps.Product.Price))
                .ForMember(dto => dto.Quantity, itm => itm.MapFrom(ps=>ps.Quantity));

            CreateMap<ItemDTO, Item>()
                .ForMember(itm => itm.Product, opt=>opt.Ignore());
        }

        
    }
}
