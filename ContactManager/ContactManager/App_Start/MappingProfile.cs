using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactManager.Models;
using ContactManager.DTOs;

namespace ContactManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<PersonContactInfo, ContactDto>();
            Mapper.CreateMap<ContactDto, PersonContactInfo>();
        }
    }
}