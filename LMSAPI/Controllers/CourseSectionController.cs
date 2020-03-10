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
    public class SectionController : ControllerBase
    {


        private readonly ICourseSectionService sectionService;
        private readonly IMapper _mapper;

        public SectionController(ICourseSectionService _sectionService,
            IMapper mapper
            )
        {
            sectionService = _sectionService;
            _mapper = mapper;

        }

        [HttpGet]
        [EnableQuery]
        
        public async Task<IEnumerable<CourseSections>> Get()
        {
             var result = await sectionService.GetCourseSection();
            return (IEnumerable<CourseSections>)result;
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<CourseSections> GetSingle(int id)
        {
            var result = await sectionService.GetCourseSectionByID(id);
            return result;
        }

        [HttpGet("coursesection/{id}")]
        [EnableQuery]

        public async Task<IEnumerable<CourseSections>> GetCourseSectionByCourseID(int id)
        {
            var result = await sectionService.GetCourseSectionByCourseID(id);
            return (IEnumerable<CourseSections>)result;
        }

        [HttpGet("search/{key}")]
        [EnableQuery]
        public async Task<IEnumerable<CourseSections>> Search(string key)
        {
            var result = await sectionService.SearchCourseSection(key);
            return result;
        }

        [HttpPost("add")]
        public async Task<CourseSections> AddSection(CourseSections section)
        {
            section = await sectionService.AddCourseSection(section);

            return section;
        }

        [HttpPost("edit")]
        public async Task<CourseSections> UpdateSection(CourseSections courseSection)
        {
            courseSection = await sectionService.UpdateCourseSection(courseSection);
            return courseSection;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await sectionService.GetCourseSectionByID(id);
            var flag = await sectionService.DeleteCourseSection(result);
            return flag;
        }
    }
}