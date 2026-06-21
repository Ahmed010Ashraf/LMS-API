using Shared.Dtos.CourseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstraction.CourseModule
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();

        Task<CourseDto> GetCourseById(Guid id);

        Task<CourseDto> CreateCourse(CreateOrUpdateCourseDto course);
        Task<CourseDto> UpdateCourse(Guid id,CreateOrUpdateCourseDto course);

        Task<bool> DeleteCourse(Guid id);
    }
}
