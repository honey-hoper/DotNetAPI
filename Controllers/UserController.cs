using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.DTOs.Request;
using WebAPIApp.DTOs.Response;
using WebAPIApp.Services;

namespace WebAPIApp.Controllers
{
    [Authorize]
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly ISaveFormFileService saveFormFileService;

        public UserController(
            IMapper mapper, 
            IUserRepository userRepository,
            ISaveFormFileService saveFormFileService)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.saveFormFileService = saveFormFileService;
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
            if (user == null)
                return NotFound();
            return mapper.Map<UserResObject>(user);
        }
        
        [HttpPut("{userId}")]
        public async Task<ActionResult<UserResObject>> UpdateUser(UpdateUserReqObject ro)
        {
            var claim = HttpContext.User.FindFirst(AppClaimTypes.Id);
            if (claim == null)
                return Unauthorized();

            if (long.Parse(claim.Value) != ro.Id)
                return Unauthorized();

            var user = await userRepository.GetUser(ro.Id);
            if (user == null)
                return BadRequest();

            var userWithUpdates = mapper.Map(ro, user);
            var updatedUser = await userRepository.UpdateUser(userWithUpdates);
            return mapper.Map<UserResObject>(updatedUser);
        }

        [HttpPatch("profile/{userId}")]
        public async Task<ActionResult<UserResObject>> UpdateUserProfilePicture(long userId, IFormFile profilePicture)
        {
            var claim = HttpContext.User.FindFirst(AppClaimTypes.Id);
            if (claim == null)
                return Unauthorized();

            if (long.Parse(claim.Value) != userId)
                return Unauthorized();

            var user = await userRepository.GetUser(userId);
            if (user == null)
                return BadRequest();

            var fileName = await saveFormFileService.Save(profilePicture);
            user.ProfilePictureUrl = fileName;
            var updatedUser = await userRepository.UpdateUser(user);
            return mapper.Map<UserResObject>(updatedUser);
        }
    }
}