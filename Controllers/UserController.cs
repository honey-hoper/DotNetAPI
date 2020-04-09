using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.DTOs.Request;
using WebAPIApp.DTOs.Response;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    [Authorize]
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResObject>>> GetUsers()
        {
            var users = await userRepository.GetUsers();
            return users.Select(it => mapper.Map<UserResObject>(it))
                .ToList();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserResObject>> GetUser(long userId)
        {
            var user = await userRepository.GetUser(userId);
            return mapper.Map<UserResObject>(user);
        }
        
        [HttpPut("{userId}")]
        public async Task<ActionResult<UserResObject>> UpdateUser(UpdateUserReqObject ro)
        {
            var user = await userRepository.UpdateUser(mapper.Map<User>(ro));
            return mapper.Map<UserResObject>(user);
        }
    }
}