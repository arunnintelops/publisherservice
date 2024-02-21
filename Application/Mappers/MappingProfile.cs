using AutoMapper;

using Application.Commands.PublisherService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Publisher, PublisherResponse>().ReverseMap();
            CreateMap<Publisher, CreatePublisherCommand>().ReverseMap();
            CreateMap<Publisher, UpdatePublisherCommand>().ReverseMap();
          
        }
    }
}
