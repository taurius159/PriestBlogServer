using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace PriestBlogServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<AuthorForUpdateDto, Author>();
        }
    }
}
