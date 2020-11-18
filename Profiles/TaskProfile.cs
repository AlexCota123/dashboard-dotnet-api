using System;
using AutoMapper;
using Dashboard.Dtos;
using Dashboard.Models;

namespace Dashboard.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {

            CreateMap<Task, TaskReadDto>();
            CreateMap<Task, TaskReadDtoWOP>();
            CreateMap<TaskCreateDto, Task>();
            CreateMap<TaskUpdateDto, Task>();

        }

    }
}
