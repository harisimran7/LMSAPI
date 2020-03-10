using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using Services.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;

namespace LMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CategoryController : ControllerBase
    {


        private readonly ICategoryService categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService _categoryService,
            IMapper mapper
            )
        {
            categoryService = _categoryService;
            _mapper = mapper;

        }

        [HttpGet]
        [EnableQuery]
        
        public async Task<IEnumerable<CourseCategory>> Get()
        {
             var result = await categoryService.GetCategory();
            return (IEnumerable<CourseCategory>)result;
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<CourseCategory> GetSingle(int id)
        {
            var result = await categoryService.GetCategoryByID(id);
            return result;
        }

        [HttpGet("search/{key}")]
        [EnableQuery]
        public async Task<IEnumerable<CourseCategory>> Search(string key)
        {
            var result = await categoryService.SearchCategory(key);
            return result;
        }

        [HttpPost("add")]
        public async Task<CourseCategory> AddCategory(CourseCategory category)
        {
            //var result = _mapper.Map<LMSData.Model.CourseCategory>(courseCategory);

            category.Image = new Attachment();
            category.Image.Title = category.ImageName;
            category.Image.Data = await System.IO.File.ReadAllBytesAsync(category.ImagePath);
            category.Image.Size = category.Image.Data.Length;

            category = await categoryService.AddCategory(category);

            return category;
        }

        [HttpPost("edit")]
        public async Task<CourseCategory> UpdateCategory(CourseCategory courseCategory)
        {
            courseCategory = await categoryService.UpdateCategory(courseCategory);
            return courseCategory;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await categoryService.GetCategoryByID(id);
            var flag = await categoryService.DeleteCategory(result);
            return flag;
        }
    }
}