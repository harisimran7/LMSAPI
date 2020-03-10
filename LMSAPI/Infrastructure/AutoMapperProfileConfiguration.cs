using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;

namespace LMSAPI
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration(): this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName): base(profileName)
        {
            CreateMap<Services.BaseModel, LMSData.Model.EntityBase>().ForMember(dest =>
            dest.Id,
            opt => opt.MapFrom(src => src.ID));
            CreateMap<LMSData.Model.EntityBase, Services.BaseModel>().ForMember(dest =>
            dest.ID,
            opt => opt.MapFrom(src => src.Id));


            #region General

            CreateMap<Services.Model.Annotation, LMSData.Model.Annotation>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Annotation, Services.Model.Annotation>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Attachment, LMSData.Model.Attachment>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Attachment, Services.Model.Attachment>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.City, LMSData.Model.City>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.City, Services.Model.City>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();


            CreateMap<Services.Model.Company, LMSData.Model.Company>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Company, Services.Model.Company>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Country, LMSData.Model.Country>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Country, Services.Model.Country>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Lookup, LMSData.Model.Lookup>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Lookup, Services.Model.Lookup>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.LookupCategory, LMSData.Model.LookupCategory>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.LookupCategory, Services.Model.LookupCategory>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.LookupValue, LMSData.Model.LookupValue>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.LookupValue, Services.Model.LookupValue>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Period, LMSData.Model.Period>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Period, Services.Model.Period>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            #endregion

            #region Courses

            CreateMap<Services.Model.Calender, LMSData.Model.Calender>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Calender, Services.Model.Calender>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Course, LMSData.Model.Course>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Course, Services.Model.Course>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.CourseCategory, LMSData.Model.CourseCategory>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.CourseCategory, Services.Model.CourseCategory>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();


            CreateMap<Services.Model.CourseTopics, LMSData.Model.CourseTopics>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.CourseTopics, Services.Model.CourseTopics>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.CourseSections, LMSData.Model.CourseSections>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.CourseSections, Services.Model.CourseSections>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            #endregion


            #region Users

            CreateMap<Services.Model.Address, LMSData.Model.Address>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Address, Services.Model.Address>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Contact, LMSData.Model.Contact>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Contact, Services.Model.Contact>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.ContactDetail, LMSData.Model.ContactDetail>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.ContactDetail, Services.Model.ContactDetail>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.ContactPoint, LMSData.Model.ContactPoint>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.ContactPoint, Services.Model.ContactPoint>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Designation, LMSData.Model.Designation>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Designation, Services.Model.Designation>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();
            
            CreateMap<Services.Model.HumanName, LMSData.Model.HumanName>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.HumanName, Services.Model.HumanName>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Member, LMSData.Model.Member>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Member, Services.Model.Member>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            CreateMap<Services.Model.Nationality, LMSData.Model.Nationality>().IncludeBase<Services.BaseModel, LMSData.Model.EntityBase>();
            CreateMap<LMSData.Model.Nationality, Services.Model.Nationality>().IncludeBase<LMSData.Model.EntityBase, Services.BaseModel>();

            #endregion         
            /*
            CreateMap<Data.Model.CodeableConcept, Hl7.Fhir.Model.CodeableConcept>()
                .IncludeBase<Data.EntityBase, Hl7.Fhir.Model.Element>()
                .ForMember(dest =>
                    dest.Coding,
                    opt => opt.MapFrom(src => src.CodeMapping.Select(x=>x.Coding)));
            */
        }
    }
}
