using AutoMapper;
using Domain.Entities.CourseEntities;
using Shared.Dtos.CourseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementation.MappingProfiles
{
    internal class CourseProfile : Profile
    {
        public CourseProfile()
        {
            // Map for GetCourseById - calculates NumberOfLectures from loaded data
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Level.Name))
                .ForMember(dest => dest.NumberOfLectures, opt =>
                    opt.MapFrom(src => src.Modules.SelectMany(m => m.Lectures).Count()));

            CreateMap<CreateOrUpdateCourseDto, Course>();
        }
    }
}
