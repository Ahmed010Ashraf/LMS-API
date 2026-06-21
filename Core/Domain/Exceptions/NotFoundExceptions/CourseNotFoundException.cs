using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.NotFoundExceptions
{
    public class CourseNotFoundException(Guid id) : NotFoundException($"course with this id : {id} is not found")
    {
    }
}
