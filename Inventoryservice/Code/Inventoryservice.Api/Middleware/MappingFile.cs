using Inventoryservice.BusinessEntities.Entities;
using Inventoryservice.Contracts.DTO;
using AutoMapper;

public class MappingFile : Profile
{
    public MappingFile()
    {
        // Mapping variables
		CreateMap<Order , OrderDto>(); 
		CreateMap<Product , ProductDto>(); 
    }
}
