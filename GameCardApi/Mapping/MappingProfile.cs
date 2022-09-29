using AutoMapper;
using Entities.Models;
using SharedHelpers.DataTransferObjects;

namespace CardGameApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CardHistory, CardHistoryDto>();

        CreateMap<HandForCreationDto,CardHistory>();

        CreateMap<CardHistoryDto, CardHistory>();
        CreateMap<Card,CardDto>();
    }
}
