
using AutoMapper;
using BooksManagement.DTOs;
using BooksManagement.Models;


public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        
        CreateMap<Review, ReviewDto>().ReverseMap();
    }
}