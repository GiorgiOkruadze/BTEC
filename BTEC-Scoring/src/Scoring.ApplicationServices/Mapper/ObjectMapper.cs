using AutoMapper;
using Scoring.ApplicationServices.Commands;
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
                .ForMember(dtoModel => dtoModel.MembersCount, dbModel => dbModel.MapFrom(o => o.Students.Count()))
                .ReverseMap();

            CreateMap<EventDto, EventViewModelForEdit>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Team, UpdateTeamCommand>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<EventPerformer, EventPerformerDto>().ReverseMap();
        }
    }
}
