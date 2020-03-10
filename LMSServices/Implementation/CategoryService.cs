using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Services.Model;
using LMSData;

namespace Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IMapper _mapper;
        IRepository<LMSData.Model.Attachment> _attachmentRepository;
        IRepository<LMSData.Model.CourseCategory> _categoryRepository;

        public CategoryService(IRepository<LMSData.Model.CourseCategory> categoryRepository,
                IRepository<LMSData.Model.Attachment> attachmentRepository,
                IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        public virtual async Task<List<CourseCategory>> GetCategory() {
            var result = await _categoryRepository.Get();
            
            result = result.Where(x => x.ParentCategory == null).ToList();
            
            //result.Join(_attachmentRepository.Table, c=> c.Image.Id, a=>a.Id, (c, a)=> )
            //foreach (var item in result)
            //{
                
            //}
            return _mapper.Map<List<CourseCategory>>(result);
        }

        public virtual async Task<CourseCategory> GetCategoryByID(int ID) {
            
            var result = await _categoryRepository.Get(ID);
            return _mapper.Map<CourseCategory>(result);
        }

        public virtual async Task<List<CourseCategory>> GetCategoryByParentID(int ID)
        {
            var result = await _categoryRepository.Get();
            result = result.Where(x => x.ParentCategory.Id == ID);
            return _mapper.Map<List<CourseCategory>>(result);
        }

        public virtual async Task<List<CourseCategory>> SearchCategory(string key) {

            var categoryList = _categoryRepository.Table.Where(x => x.Name.Contains(key) || x.NameAR.Contains(key)).ToList();
            var result = _mapper.Map<List<CourseCategory>>(categoryList);

            return result;
        }

        public virtual async Task<CourseCategory> AddCategory(CourseCategory courseCategory) {

            //save images
            LMSData.Model.CourseCategory category = _mapper.Map<LMSData.Model.CourseCategory>(courseCategory);

            if (category.Image != null) 
                await _attachmentRepository.Insert(category.Image);

            await _categoryRepository.Insert(category);
            await _categoryRepository.Save();

            courseCategory = _mapper.Map<Services.Model.CourseCategory>(category);
            return courseCategory;
        }
        public virtual async Task<CourseCategory> UpdateCategory(CourseCategory courseCategory) {

            LMSData.Model.CourseCategory category = _mapper.Map<LMSData.Model.CourseCategory>(courseCategory);
            await _categoryRepository.Update(category);
            await _categoryRepository.Save();

            courseCategory = _mapper.Map<Services.Model.CourseCategory>(category);
            return courseCategory; 
        }
        public virtual async Task<bool> DeleteCategory(CourseCategory courseCategory) {

            await _categoryRepository.Delete(_mapper.Map<LMSData.Model.CourseCategory>(courseCategory));
            await _categoryRepository.Save();

            return true;
        }
    }
}
