using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Model;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<CourseCategory>> GetCategory();
        Task<CourseCategory> GetCategoryByID(int ID);
        Task<List<CourseCategory>> GetCategoryByParentID(int ID);
        Task<List<CourseCategory>> SearchCategory(string key);
        Task<CourseCategory> AddCategory(CourseCategory category);
        Task<CourseCategory> UpdateCategory(CourseCategory product);
        Task<bool> DeleteCategory(CourseCategory product);
    }
}
