using AutoMapper;
using OlxCore.Entities;
using OlxCore.Entities.DTOModels;
using OlxWebApplication.Models.User;
using OlxWebApplication.Models.ViewModels;

namespace OlxWebApplication.Helpers
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<SignUpUserModel, UserDTO>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
