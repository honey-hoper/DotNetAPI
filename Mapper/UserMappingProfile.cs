using AutoMapper;
using WebAPIApp.DTOs.Request;
using WebAPIApp.DTOs.Response;
using WebAPIApp.Models;

namespace WebAPIApp.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AddUserReqObject, User>();
            CreateMap<UpdateUserReqObject, User>();
            CreateMap<User, UserResObject>();
        }
    }
}