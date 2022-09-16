using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace CardGameApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CardHistory, CardHistoryDto>();

        CreateMap<HandForCreationDto,CardHistory>();

        CreateMap<CardHistoryDto, CardHistory>();
    }
}
