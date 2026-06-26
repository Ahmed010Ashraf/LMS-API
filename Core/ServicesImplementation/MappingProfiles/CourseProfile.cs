using AutoMapper;
using Domain.Entities.CourseEntities;
using Microsoft.Extensions.Configuration;
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
                    opt.MapFrom(src => src.Modules.SelectMany(m => m.Lectures).Count()))
                .ForMember(dest => dest.PicUrl, opt => opt.MapFrom<CoursePictureResolver>());

            CreateMap<CreateOrUpdateCourseDto, Course>();
        }

        public class CoursePictureResolver(IConfiguration _config) : IValueResolver<Course, CourseDto, string>
        {
            public string Resolve(Course source, CourseDto destination, string destMember, ResolutionContext context)
            {
                if(source.PicUrl is not null)
                {
                    return $"{_config.GetSection("URLS")["BaseUrl"]}{source.PicUrl}";
                }
                return string.Empty ;
            }
        }
    }
}
