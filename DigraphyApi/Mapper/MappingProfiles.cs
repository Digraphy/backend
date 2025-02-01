using AutoMapper;
using DigraphyApi.Dto;
using DigraphyApi.Models;

namespace DigraphyApi.Mapper;

// can't rememeber if we need this or not
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Todo mapping
        CreateMap<Todo, TodoDto>();
        CreateMap<TodoDto, Todo>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Todo, CreateTodoDto>();
        CreateMap<CreateTodoDto, Todo>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
