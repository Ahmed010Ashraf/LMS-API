using AutoMapper;
using Domain.Contracts;
using Domain.Entities.CourseEntities;
using Domain.Exceptions.NotFoundExceptions;
using ServicesAbstraction.CourseModule;
using Shared.Dtos.CourseModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesAbstraction;

namespace ServicesImplementation.CourseModule
{
    public class CourseService : ICourseService
    {
        private readonly IUniteOfWork _UOW;
        private readonly IMapper _Mapper;
        private readonly IAttachmentService _AttachmentService;

        public CourseService(IUniteOfWork UOW, IMapper mapper , IAttachmentService AttachmentService)
        {
            _UOW = UOW;
            _Mapper = mapper;
            _AttachmentService = AttachmentService;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courses = await _UOW.GetReposatory<Course>().GetQueryable().Where(c => c.IsDeleted != true)
                .Include(c => c.Level)
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    PicUrl = c.PicUrl,
                    LevelId = c.LevelId,
                    LevelName = c.Level.Name,
                    NumberOfLectures = c.Modules.SelectMany(m => m.Lectures).Count()
                })
                .ToListAsync();


          


            return courses;
        }

        public async Task<CourseDto> GetCourseById(Guid id)
        {
            var course = await _UOW.GetReposatory<Course>().GetQueryable().Where(c => c.IsDeleted != true)
                .Include(c => c.Level)
                .Include(c => c.Modules)
                .ThenInclude(m => m.Lectures)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course is null)
            {
                throw new CourseNotFoundException(id);
            }

            var CourseResult = _Mapper.Map<CourseDto>(course);
            return CourseResult;
        }

        public async Task<CourseDto> CreateCourse(CreateOrUpdateCourseDto course)
        {
            var NewCourse = _Mapper.Map<Course>(course);

            NewCourse.CreatedAt = DateTime.Now;
            if (course.PicUrl != null) {
                NewCourse.PicUrl = await _AttachmentService.Upload(course.PicUrl);
            }

            await _UOW.GetReposatory<Course>().AddAsync(NewCourse);

            var res = await _UOW.SaveChangesAsync();

            if (res <= 0)
            {
                throw new Exception("can't create the course");
            }

            return _Mapper.Map<CourseDto>(NewCourse);
        }

        public async Task<CourseDto> UpdateCourse(Guid id, CreateOrUpdateCourseDto course)
        {
            var OldCourse = await _UOW.GetReposatory<Course>().GetByIdAsync(id);
            if (OldCourse is null)
            {
                throw new CourseNotFoundException(id);
            }

            _Mapper.Map(course, OldCourse);

            if(course.PicUrl != null)
            {
                if(OldCourse.PicUrl != null)
                {
                    _AttachmentService.Delete(OldCourse.PicUrl);
                }

                OldCourse.PicUrl = await _AttachmentService.Upload(course.PicUrl);
            }

            OldCourse.UpdatedAt = DateTime.Now;
            var res = await _UOW.SaveChangesAsync();

            if (res <= 0)
            {
                throw new Exception("can't update the course");
            }

            return _Mapper.Map<CourseDto>(OldCourse);
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var course = await _UOW.GetReposatory<Course>().GetByIdAsync(id);
            if (course is null)
            {
                throw new CourseNotFoundException(id);
            }

            course.IsDeleted = true;

            var res = await _UOW.SaveChangesAsync();

            if (res <= 0)
            {
                throw new Exception("can't delete the course");
            }

            return true;
        }
    }
}
