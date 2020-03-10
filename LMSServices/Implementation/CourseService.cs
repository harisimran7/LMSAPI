using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Services.Model;
using LMSData;

namespace Services
{
    public class CourseService: ICourseService
    {
        private readonly IMapper _mapper;
        IRepository<LMSData.Model.Attachment> _attachmentRepository;
        IRepository<LMSData.Model.Course> _courseRepository;

        public CourseService(IRepository<LMSData.Model.Course> courseRepository,
                IRepository<LMSData.Model.Attachment> attachmentRepository,
                IMapper mapper
            )
        {
            _courseRepository = courseRepository;
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        public virtual async Task<List<Course>> GetCourse() {
            var result = await _courseRepository.Get();
            
            result = result.Where(x => x.Category == null).ToList();
            
            //result.Join(_attachmentRepository.Table, c=> c.Image.Id, a=>a.Id, (c, a)=> )
            //foreach (var item in result)
            //{
                
            //}
            return _mapper.Map<List<Course>>(result);
        }

        public virtual async Task<Course> GetCourseByID(int ID) {
            
            var result = await _courseRepository.Get(ID);
            return _mapper.Map<Course>(result);
        }

        public virtual async Task<List<Course>> GetCourseByCategoryID(int ID)
        {
            var result = await _courseRepository.Get();
            result = result.Where(x => x.Category.Id == ID);
            return _mapper.Map<List<Course>>(result);
        }

        public virtual async Task<List<Course>> SearchCourse(string key) {

            var courseList = _courseRepository.Table.Where(x => x.Name.Contains(key) || x.NameAR.Contains(key)).ToList();
            var result = _mapper.Map<List<Course>>(courseList);

            return result;
        }

        public virtual async Task<Course> AddCourse(Course courseCourse) {

            //save images
            LMSData.Model.Course course = _mapper.Map<LMSData.Model.Course>(courseCourse);

            if(course.Image != null)
                await _attachmentRepository.Insert(course.Image);

            await _courseRepository.Insert(course);
            await _courseRepository.Save();

            courseCourse = _mapper.Map<Services.Model.Course>(course);
            return courseCourse;
        }
        public virtual async Task<Course> UpdateCourse(Course courseCourse) {

            LMSData.Model.Course course = _mapper.Map<LMSData.Model.Course>(courseCourse);
            await _courseRepository.Update(course);
            await _courseRepository.Save();

            courseCourse = _mapper.Map<Services.Model.Course>(course);
            return courseCourse; 
        }
        public virtual async Task<bool> DeleteCourse(Course courseCourse) {

            await _courseRepository.Delete(_mapper.Map<LMSData.Model.Course>(courseCourse));
            await _courseRepository.Save();

            return true;
        }
    }
}
