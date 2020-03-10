using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Services.Model;
using LMSData;

namespace Services
{
    public class CourseSectionService : ICourseSectionService
    {
        private readonly IMapper _mapper;
        IRepository<LMSData.Model.Attachment> _attachmentRepository;
        IRepository<LMSData.Model.CourseSections> _courseSectionRepository;

        public CourseSectionService(IRepository<LMSData.Model.CourseSections> courseSectionRepository,
                IRepository<LMSData.Model.Attachment> attachmentRepository,
                IMapper mapper
            )
        {
            _courseSectionRepository = courseSectionRepository;
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        public virtual async Task<List<CourseSections>> GetCourseSection() {
            var result = await _courseSectionRepository.Get();
            
            result = result.ToList();
            
            return _mapper.Map<List<CourseSections>>(result);
        }

        public virtual async Task<CourseSections> GetCourseSectionByID(int ID) {
            
            var result = await _courseSectionRepository.Get(ID);
            return _mapper.Map<CourseSections>(result);
        }

        public virtual async Task<List<CourseSections>> GetCourseSectionByCourseID(int ID)
        {
            var result = await _courseSectionRepository.Get();
            result = result.Where(x => x.Course.Id == ID);
            return _mapper.Map<List<CourseSections>>(result);
        }

        public virtual async Task<List<CourseSections>> SearchCourseSection(string key) {

            var courseSectionList = _courseSectionRepository.Table.Where(x => x.Title.Contains(key) || x.TitleAR.Contains(key)).ToList();
            var result = _mapper.Map<List<CourseSections>>(courseSectionList);

            return result;
        }

        public virtual async Task<CourseSections> AddCourseSection(CourseSections courseSectionCourseSection) {

            //save images
            LMSData.Model.CourseSections courseSection = _mapper.Map<LMSData.Model.CourseSections>(courseSectionCourseSection);

            await _courseSectionRepository.Insert(courseSection);
            await _courseSectionRepository.Save();

            courseSectionCourseSection = _mapper.Map<Services.Model.CourseSections>(courseSection);
            return courseSectionCourseSection;
        }
        public virtual async Task<CourseSections> UpdateCourseSection(CourseSections courseSectionCourseSection) {

            LMSData.Model.CourseSections courseSection = _mapper.Map<LMSData.Model.CourseSections>(courseSectionCourseSection);
            await _courseSectionRepository.Update(courseSection);
            await _courseSectionRepository.Save();

            courseSectionCourseSection = _mapper.Map<Services.Model.CourseSections>(courseSection);
            return courseSectionCourseSection; 
        }
        public virtual async Task<bool> DeleteCourseSection(CourseSections courseSectionCourseSection) {

            await _courseSectionRepository.Delete(_mapper.Map<LMSData.Model.CourseSections>(courseSectionCourseSection));
            await _courseSectionRepository.Save();

            return true;
        }
    }
}
