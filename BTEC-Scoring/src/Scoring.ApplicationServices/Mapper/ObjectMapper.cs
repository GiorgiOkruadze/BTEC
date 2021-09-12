using AutoMapper;
using Scoring.ApplicationShared.DTOs;
using Scoring.DatabaseModels.Models;
using System.Linq;

namespace Scoring.ApplicationServices.Mappers
{
    public class ObjectMapper: Profile
    {
        public ObjectMapper()
        {
            CreateMap<Team, TeamDto>()
                .ForMember(dtoModel => dtoModel.CompletedEventsCount, dbModel => dbModel.MapFrom(o => o.CompletedEvents.Count()))
                .ReverseMap();

            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
