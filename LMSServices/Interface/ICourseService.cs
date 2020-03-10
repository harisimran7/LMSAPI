using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Model;

namespace Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourse();
        Task<Course> GetCourseByID(int ID);
        Task<List<Course>> GetCourseByCategoryID(int ID);
        Task<List<Course>> SearchCourse(string key);
        Task<Course> AddCourse(Course category);
        Task<Course> UpdateCourse(Course product);
        Task<bool> DeleteCourse(Course product);
    }
}
