using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Model;

namespace Services
{
    public interface ICourseTopicsService
    {
        Task<List<CourseTopics>> GetCourseTopic();
        Task<CourseTopics> GetCourseTopicByID(int ID);
        Task<List<CourseTopics>> GetCourseTopicByCourseID(int ID);
        Task<List<CourseTopics>> SearchCourseTopic(string key);
        Task<CourseTopics> AddCourseTopic(CourseTopics category);
        Task<CourseTopics> UpdateCourseTopic(CourseTopics product);
        Task<bool> DeleteCourseTopic(CourseTopics product);
    }
}
