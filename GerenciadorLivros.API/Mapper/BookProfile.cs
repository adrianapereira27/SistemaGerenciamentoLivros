using AutoMapper;
using GerenciadorLivros.API.Entities;
using GerenciadorLivros.API.Models;

namespace GerenciadorLivros.API.Mapper
{
    public class BookProfile : Profile
    {
        CreateMap<Book, BookViewModel>();    // usado no GET        

        CreateMap<BookInputModel, Book>();   // usado no POST, PUT        
    }
}
