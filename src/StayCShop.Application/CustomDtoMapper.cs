using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Address
            //configuration.CreateMap<Address, AddressListDto>();
            //configuration.CreateMap<Address, GetForEditAddressDto>();
            //configuration.CreateMap<CreateOrUpdateAddressDto, Address>();
        }
    }
}
