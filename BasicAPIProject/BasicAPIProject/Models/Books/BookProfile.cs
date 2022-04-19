using AutoMapper;
using BasicAPIProject.DataAccess.Entities;

namespace BasicAPIProject.Models.Books
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookRequestModel,Book>();
            CreateMap<Book, BookResponseModel>();
        }
    }
}
