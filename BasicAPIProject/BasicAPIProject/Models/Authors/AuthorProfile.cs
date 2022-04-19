using AutoMapper;
using BasicAPIProject.DataAccess.Entities;

namespace BasicAPIProject.Models.Authors
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorRequestModel, Author>();
            CreateMap<Author, AuthorResponseModel>();
        }
    }
}
