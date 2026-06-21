using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.CourseModule;
using Shared.Dtos.CourseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Persentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseContoller(ICourseService _courseService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CourseDto>> GetById(Guid id)
        {
            var course = await _courseService.GetCourseById(id);
            return Ok(course);
        }


        [HttpPost] 
        public async Task<ActionResult<CourseDto>> Create(CreateOrUpdateCourseDto newCourse)
        {
            var course = await _courseService.CreateCourse(newCourse);
            return Ok(course);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CourseDto>> Update(Guid id,CreateOrUpdateCourseDto updatedCourse)
        {
            var course = await _courseService.UpdateCourse(id,updatedCourse);
            return Ok(course);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete (Guid id)
        {
            var res = await _courseService.DeleteCourse(id);
            return Ok(res);
        }
    }
}
