using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.DTOs.Request;
using WebAPIApp.DTOs.Response;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IHashService hashService;
        private readonly IMapper mapper;

        public AuthController(
            IUserRepository userRepository, 
            ITokenGenerator tokenGenerator,
            IHashService hashService,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.tokenGenerator = tokenGenerator;
            this.hashService = hashService;
            this.mapper = mapper;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<LoginResObject>> LoginUser(LoginUserReqObject ro)
        {
            var user = await userRepository.GetUserByEmail(ro.Email);
            if (user == null)
                return Unauthorized();
            
            if (!hashService.Match(ro.Password, user.Password))
                return Unauthorized();

            var token = tokenGenerator.GenerateToken(user);
            return new LoginResObject { Token = token, User = mapper.Map<UserResObject>(user) };
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<UserResObject>> AddUser(AddUserReqObject ro)
        {
            var existingUser = await userRepository.GetUserByEmail(ro.Email);
            if (existingUser != null)
                return BadRequest();

            var passwordHash = hashService.Generate(ro.Password);
            ro.Password = passwordHash;
            
            var user = await userRepository.AddUser(mapper.Map<User>(ro));
            return mapper.Map<UserResObject>(user);
        }
    }
}