using System;
using System.Collections.Generic;
using AutoMapper;
using Dashboard.Data;
using Dashboard.Dtos;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepo _repository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectReadDto>> GetAllProjects()
        {
            var projects = _repository.GetProjects();

            return Ok(_mapper.Map<IEnumerable<ProjectReadDto>>(projects));
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectReadDto> GetProjectById(int id)
        {
            var project = _repository.GetProjectById(id);

            if (project != null)
            {
                return Ok(_mapper.Map<ProjectReadDto>(project));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ProjectReadDto> CreateProject(ProjectCreateDto projectCreate)
        {

            var project = _mapper.Map<Project>(projectCreate);
            _repository.CreateProject(project);
            _repository.SaveChanges();

            return Ok(projectCreate);
        }

    }
}
