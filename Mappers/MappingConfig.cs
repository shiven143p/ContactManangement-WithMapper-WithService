using AutoMapper;
using ContactManangement.Entities;
using ContactManangement.Entities.Dto;

namespace ContactManangement.Mappers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Contact, ContactDto>();
                config.CreateMap<ContactDto, Contact>();
            });

            return mappingconfig;

        }
    }
}
