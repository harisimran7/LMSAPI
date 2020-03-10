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
    public class CourseController : ControllerBase
    {


        private readonly ICourseService courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService _courseService,
            IMapper mapper
            )
        {
            courseService = _courseService;
            _mapper = mapper;

        }

        [HttpGet]
        [EnableQuery]
        
        public async Task<IEnumerable<Course>> Get()
        {
             var result = await courseService.GetCourse();
            return (IEnumerable<Course>)result;
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<Course> GetSingle(int id)
        {
            var result = await courseService.GetCourseByID(id);
            return result;
        }

        [HttpGet("search/{key}")]
        [EnableQuery]
        public async Task<IEnumerable<Course>> Search(string key)
        {
            var result = await courseService.SearchCourse(key);
            return result;
        }

        [HttpPost("add")]
        public async Task<Course> AddCourse(Course course)
        {
            //var result = _mapper.Map<LMSData.Model.Course>(courseCourse);

            //course.Image = new Attachment();
            //course.Image.Title = course.Image.Title;
            //course.Image.Data = await System.IO.File.ReadAllBytesAsync(course.Image.Url);
            //course.Image.Size = course.Image.Data.Length;

            course = await courseService.AddCourse(course);

            return course;
        }

        [HttpPost("edit")]
        public async Task<Course> UpdateCourse(Course courseCourse)
        {
            courseCourse = await courseService.UpdateCourse(courseCourse);
            return courseCourse;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await courseService.GetCourseByID(id);
            var flag = await courseService.DeleteCourse(result);
            return flag;
        }
    }
}