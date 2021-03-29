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

namespace FilmAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _repo { get; }
        private CommentRepository _repoCmt { get; }
        // GET: UserController
        public UserController(UserRepository repo, CommentRepository repocmt)
        {
            _repo = repo;
            _repoCmt = repocmt;
        }
        [HttpPost]
        public IActionResult Create(UserRegister userRegister)
        {
            if (userRegister is null || !ModelState.IsValid)
                return BadRequest();

            Guid id = _repo.Insert(userRegister.ToDal());
            //messageRepository.getAll().where(uint=>uint.userId == id).select(static => static.toApi())

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
            return Ok();
        }
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            return Ok(_repo.Get(Id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
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
        public IActionResult Delete(Guid Id, string Reason)
        {
            if (_repo.Get(Id) == null) return BadRequest();

            return Ok(_repo.Delete(Id, Reason));
        }

        [HttpPut]
        public IActionResult SwitchRole(d.UserEntity user)
        {
            return Ok(_repo.Update(user));
        }
    }
}
