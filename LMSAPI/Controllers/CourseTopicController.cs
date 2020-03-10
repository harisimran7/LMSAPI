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
    public class TopicController : ControllerBase
    {


        private readonly ICourseTopicsService topicService;
        private readonly IMapper _mapper;

        public TopicController(ICourseTopicsService _topicService,
            IMapper mapper
            )
        {
            topicService = _topicService;
            _mapper = mapper;

        }

        [HttpGet]
        [EnableQuery]
        
        public async Task<IEnumerable<CourseTopics>> Get()
        {
             var result = await topicService.GetCourseTopic();
            return (IEnumerable<CourseTopics>)result;
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<CourseTopics> GetSingle(int id)
        {
            var result = await topicService.GetCourseTopicByID(id);
            return result;
        }

        [HttpGet("coursetopic/{id}")]
        [EnableQuery]

        public async Task<IEnumerable<CourseTopics>> GetCourseTopicByCourseID(int id)
        {
            var result = await topicService.GetCourseTopicByCourseID(id);
            return (IEnumerable<CourseTopics>)result;
        }

        [HttpGet("search/{key}")]
        [EnableQuery]
        public async Task<IEnumerable<CourseTopics>> Search(string key)
        {
            var result = await topicService.SearchCourseTopic(key);
            return result;
        }

        [HttpPost("add")]
        public async Task<CourseTopics> AddTopic(CourseTopics topic)
        {
            topic = await topicService.AddCourseTopic(topic);

            return topic;
        }

        [HttpPost("edit")]
        public async Task<CourseTopics> UpdateTopic(CourseTopics courseTopic)
        {
            courseTopic = await topicService.UpdateCourseTopic(courseTopic);
            return courseTopic;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await topicService.GetCourseTopicByID(id);
            var flag = await topicService.DeleteCourseTopic(result);
            return flag;
        }
    }
}