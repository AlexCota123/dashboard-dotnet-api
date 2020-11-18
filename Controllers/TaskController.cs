using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dashboard.Data;
using Dashboard.Dtos;
using Dashboard.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepo _repository;
        private readonly IProjectRepo _projectRepository;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepo repository, IProjectRepo projectRepo, IMapper mapper)
        {
            _repository = repository;
            _projectRepository = projectRepo;
            _mapper = mapper;
        }

        // GET api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskReadDtoWOP>> GetAllTasks()
        {
            var tasks = _repository.GetTasks();

            return Ok(_mapper.Map<IEnumerable<TaskReadDtoWOP>>(tasks));
        }

        /**
         * GET api/tasks/id
         * param id is the id to search du
         * */
        [HttpGet("{id}", Name = "GetTaskById")]
        public ActionResult<TaskReadDto> GetTaskById(int id)
        {
            var task = _repository.GetTaskById(id);

            if(task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        //POST api/tasks
        [HttpPost]
        public ActionResult<TaskReadDtoWOP> CreateTask(TaskCreateDto taskCreate)
        {
            var task = _mapper.Map<Task>(taskCreate);
            _repository.CreateTask(task);
            _repository.SaveChanges();

            var taskRead = _mapper.Map<TaskReadDtoWOP>(task);

            return CreatedAtRoute(nameof(GetTaskById), new { Id= taskRead.Id}, taskRead) ;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, TaskUpdateDto taskUpdate)
        {
            var task = _repository.GetTaskById(id);
            if(task == null)
            {
                return NotFound();
            }
            _mapper.Map(taskUpdate, task);
            _repository.UpdateTask(task);
            _repository.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult PartialTaskUpdate(int id, JsonPatchDocument<TaskUpdateDto> patchDocument)
        {
            var task = _repository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            var taskPatch = _mapper.Map<TaskUpdateDto>(task);
            patchDocument.ApplyTo(taskPatch, ModelState);

            if (!TryValidateModel(taskPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(taskPatch, task);
            _repository.UpdateTask(task);
            _repository.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var task = _repository.GetTaskById(id);

            if(task == null)
            {
                return NotFound();
            }

            _repository.DeleteTask(task);
            _repository.SaveChanges();

            return NoContent();
        }

        //[HttpPut("{id}/projects")]
        //public ActionResult AddProjectToTask(int id, List<int> idList)
        //{
        //    var task = _repository.GetTaskById(id);
        //    if(task == null)
        //    {
        //        return NotFound();
        //    }
        //    Console.WriteLine("IDs Projects: ");

        //    var projects = _projectRepository.GetProjectsById(idList);
        //    foreach(Project project in projects)
        //    {
        //        Console.WriteLine(project.Name);
        //    }

        //    task.Projects = (List<Project>)projects;
        //    _repository.UpdateTask(task);
        //    _repository.SaveChanges();

        //    //Console.WriteLine("Id usuario: " + id);
        //    //foreach(int idProject in idList)
        //    //{
        //    //    Console.WriteLine(idProject);
        //    //}
        //    return NoContent();
        //}
    }
}