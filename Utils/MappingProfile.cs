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
        }
    }
}