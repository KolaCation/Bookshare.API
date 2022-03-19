using AutoMapper;
using Bookshare.API.Requests.Books;
using Bookshare.ApplicationServices.Commands;
using Bookshare.ApplicationServices.Queries;

namespace Bookshare.API.MapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<AddBookRequest, AddBookCommand>();
            CreateMap<RemoveBookByIdRequest, RemoveBookByIdCommand>();
            CreateMap<GetBookByIdRequest, GetBookByIdQuery>();
            CreateMap<GetBooksRequest, GetBooksQuery>();
            CreateMap<UpdateBookByIdRequest, UpdateBookCommand>();
        }
    }
}
