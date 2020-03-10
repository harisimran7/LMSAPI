using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Services.Model;
using LMSData;

namespace Services
{
    public class CourseTopicsService : ICourseTopicsService
    {
        private readonly IMapper _mapper;
        IRepository<LMSData.Model.Attachment> _attachmentRepository;
        IRepository<LMSData.Model.CourseTopics> _courseSectionRepository;

        public CourseTopicsService(IRepository<LMSData.Model.CourseTopics> courseSectionRepository,
                IRepository<LMSData.Model.Attachment> attachmentRepository,
                IMapper mapper
            )
        {
            _courseSectionRepository = courseSectionRepository;
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        public virtual async Task<List<CourseTopics>> GetCourseTopic() {
            var result = await _courseSectionRepository.Get();
            
            result = result.ToList();
            
            return _mapper.Map<List<CourseTopics>>(result);
        }

        public virtual async Task<CourseTopics> GetCourseTopicByID(int ID) {
            
            var result = await _courseSectionRepository.Get(ID);
            return _mapper.Map<CourseTopics>(result);
        }

        public virtual async Task<List<CourseTopics>> GetCourseTopicByCourseID(int ID)
        {
            var result = await _courseSectionRepository.Get();
            result = result.Where(x => x.SectionID == ID);
            return _mapper.Map<List<CourseTopics>>(result);
        }

        public virtual async Task<List<CourseTopics>> SearchCourseTopic(string key) {

            var courseSectionList = _courseSectionRepository.Table.Where(x => x.Title.Contains(key) || x.TitleAR.Contains(key)).ToList();
            var result = _mapper.Map<List<CourseTopics>>(courseSectionList);

            return result;
        }

        public virtual async Task<CourseTopics> AddCourseTopic(CourseTopics courseSectionCourseTopics) {

            //save images
            LMSData.Model.CourseTopics courseSection = _mapper.Map<LMSData.Model.CourseTopics>(courseSectionCourseTopics);

            await _courseSectionRepository.Insert(courseSection);
            await _courseSectionRepository.Save();

            courseSectionCourseTopics = _mapper.Map<Services.Model.CourseTopics>(courseSection);
            return courseSectionCourseTopics;
        }
        public virtual async Task<CourseTopics> UpdateCourseTopic(CourseTopics courseSectionCourseTopics) {

            LMSData.Model.CourseTopics courseSection = _mapper.Map<LMSData.Model.CourseTopics>(courseSectionCourseTopics);
            await _courseSectionRepository.Update(courseSection);
            await _courseSectionRepository.Save();

            courseSectionCourseTopics = _mapper.Map<Services.Model.CourseTopics>(courseSection);
            return courseSectionCourseTopics; 
        }
        public virtual async Task<bool> DeleteCourseTopic(CourseTopics courseSectionCourseTopics) {

            await _courseSectionRepository.Delete(_mapper.Map<LMSData.Model.CourseTopics>(courseSectionCourseTopics));
            await _courseSectionRepository.Save();

            return true;
        }
    }
}
