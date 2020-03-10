using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Services.Model
{
    public class CourseCategory : BaseModel
    {
        public CourseCategory()
        {
        }

        public CourseCategory(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }


        private Attachment _image;
        public int? ParentID { get; set; }
        public string IDNumber { get; set; }
        public string Name { get; set; }
        public string NameAR { get; set; }
        public string ImageName{ get; set; }
        public string ImagePath { get; set; }
        //public IFormFile ImageFile { get; set; }
        //public virtual Attachment Image { get; set; }

        public Attachment Image
        {
            get => LazyLoader.Load(this, ref _image);
            set => _image = value;
        }
        public string Description { get; set; }
        public string DescriptionAR { get; set; }

        //public virtual CourseCategory ParentCategory { get; set; }
    }
}
