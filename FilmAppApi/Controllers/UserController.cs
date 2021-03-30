using FilmApp.DAL.Repositories;
using FilmAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using d = FilmApp.DAL.Entities;
using FilmAppApi.Tools;
using FilmAppApi.TokenJWT;
using Microsoft.AspNetCore.Authorization;

namespace FilmAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private UserRepository _repo { get; }
        private CommentRepository _repoCmt { get; }
        private TokenManager _tokenManager { get; }
        // GET: UserController
        public UserController(UserRepository repo, CommentRepository repocmt, TokenManager tokenManager)
        {
            _repo = repo;
            _repoCmt = repocmt;
            _tokenManager = tokenManager;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(UserRegister userRegister)
        {
            if (userRegister is null || !ModelState.IsValid)
                return BadRequest();

            Guid id = _repo.Insert(userRegister.ToDal());
            // Generate Token
            return Ok(new
            {
                //token = TokenManager.GenerateJWT(id, userRegister.Email)
            });
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLogin userLogin)
        {
            if (userLogin is null || !ModelState.IsValid)
                return BadRequest();

            UserEntity userApp = _repo.Login(userLogin.Login, userLogin.Password).ToApi();

            if (userApp is null)
                return new ForbidResult();

            // Generate Token
            return Ok(_tokenManager.GenerateJWT(userApp));
        }
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult Get(Guid Id)
        {
            return Ok(_repo.Get(Id));
        }
        [HttpGet]
        [Authorize("user")]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
        [HttpPut]
        [Authorize("user")]
        public IActionResult Update(UserEntity user)
        {
            if (user is null || !ModelState.IsValid)
                return BadRequest();

            _repo.Update(user.ToDal());
            //messageRepository.getAll().where(uint=>uint.userId == id).select(static => static.toApi())

            // Generate Token
            return Ok(new
            {
                //token = TokenManager.GenerateJWT(id, userRegister.Email)
            });
        }
        [HttpDelete("{Id}")]
        [Authorize("admin")]
        public IActionResult Delete(DeleteUser user)
        {
            if (_repo.Get(user.Id) == null) return BadRequest();

            return Ok(_repo.Delete(user.ToDal()));
        }

        [HttpPut]
        [Authorize("admin")]
        public IActionResult SwitchRole(UserEntity user)
        {
            return Ok(_repo.Update(user.ToDal()));
        }
    }
}
