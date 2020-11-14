using System.Collections.Generic;
using AutoMapper;
using Dashboard.Data;
using Dashboard.Dtos;
using Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
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

    }
}