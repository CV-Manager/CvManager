using AutoMapper;
using CvManager.ViewModels;
using CvManager.Models;

namespace CvManager.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserVM, User>();
            CreateMap<User, UserVM>().ReverseMap();

            CreateMap<EducationVM, Education>();
            CreateMap<Education, EducationVM>().ReverseMap();

            CreateMap<ExtraCourseVM, ExtraCourse>();
            CreateMap<ExtraCourse, ExtraCourseVM>().ReverseMap();

            CreateMap<SkillVM, Skill>();
            CreateMap<Skill, SkillVM>().ReverseMap();

            CreateMap<WorkHistoryVM, WorkHistory>();
            CreateMap<WorkHistory, WorkHistoryVM>().ReverseMap();
        }
    }
}