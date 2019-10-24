using AutoMapper;
using ContosoSite.Dtos;
using ContosoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoSite.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Course, CourseDto>();

            // Dto to Domain, Id needs to be ignored for the put operation            
            Mapper.CreateMap<CourseDto, Course>().ForMember(c => c.CourseID, opt => opt.Ignore());

        }
    }
}