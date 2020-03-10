using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Model;

namespace Services
{
    public interface ICourseSectionService
    {
        Task<List<CourseSections>> GetCourseSection();
        Task<CourseSections> GetCourseSectionByID(int ID);
        Task<List<CourseSections>> GetCourseSectionByCourseID(int ID);
        Task<List<CourseSections>> SearchCourseSection(string key);
        Task<CourseSections> AddCourseSection(CourseSections category);
        Task<CourseSections> UpdateCourseSection(CourseSections product);
        Task<bool> DeleteCourseSection(CourseSections product);
    }
}
