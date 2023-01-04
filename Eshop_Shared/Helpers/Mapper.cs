using AutoMapper;
using Eshop_Domain.DTO;
using Eshop_Domain.Entities;

namespace Eshop_Shared.Helpers
{
    public static class Mapper
    {
        //From Domain to DTO
        public static UserDto ToDto(this User domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<UserDto>(domainModel);
        }

        //From DTO to Domain
        public static User ToDomain(this UserDto domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, User>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<User>(domainModel);
        }

        //From Domain to DTO
        public static ProductDto ProductToDto(this Product domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<ProductDto>(domainModel);
        }

        //From DTO to Domain
        public static Product ProductToDomain(this ProductDto domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, Product>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<Product>(domainModel);
        }
    }
}
