using AutoMapper;
using OlxCore.Entities.DTOModels;
using OlxWebApplication.Models.User;

namespace OlxWebApplication.Helpers
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<SignUpUserModel, UserDTO>();
        }
    }
}
