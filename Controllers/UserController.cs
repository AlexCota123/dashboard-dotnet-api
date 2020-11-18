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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IProjectRepo _projectRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IProjectRepo projectRepo, IMapper mapper)
        {
            _repository = repository;
            _projectRepository = projectRepo;
            _mapper = mapper;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _repository.GetUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        /**
         * GET api/users/id
         * param id is the id to search du
         * */
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);

            if(user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            return NotFound();
        }

        //POST api/users
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreate)
        {
            var user = _mapper.Map<User>(userCreate);
            _repository.CreateUser(user);
            _repository.SaveChanges();

            var userRead = _mapper.Map<UserReadDto>(user);

            return CreatedAtRoute(nameof(GetUserById), new { Id= userRead.Id}, userRead) ;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdate)
        {
            var user = _repository.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdate, user);
            _repository.UpdateUser(user);
            _repository.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDocument)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var userPatch = _mapper.Map<UserUpdateDto>(user);
            patchDocument.ApplyTo(userPatch, ModelState);

            if (!TryValidateModel(userPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userPatch, user);
            _repository.UpdateUser(user);
            _repository.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _repository.GetUserById(id);

            if(user == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(user);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/projects")]
        public ActionResult AddProjectToUser(int id, List<int> idList)
        {
            var user = _repository.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            Console.WriteLine("IDs Projects: ");

            var projects = _projectRepository.GetProjectsById(idList);
            foreach(Project project in projects)
            {
                Console.WriteLine(project.Name);
            }

            user.Projects = (List<Project>)projects;
            _repository.UpdateUser(user);
            _repository.SaveChanges();

            //Console.WriteLine("Id usuario: " + id);
            //foreach(int idProject in idList)
            //{
            //    Console.WriteLine(idProject);
            //}
            return NoContent();
        }
    }
}