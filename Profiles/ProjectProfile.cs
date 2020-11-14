using System;
using AutoMapper;
using Dashboard.Dtos;
using Dashboard.Models;

namespace Dashboard.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectReadDto>();
            CreateMap<ProjectCreateDto, Project>();
        }
    }
}
