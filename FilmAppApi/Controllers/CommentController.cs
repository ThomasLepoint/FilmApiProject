using FilmApp.DAL.Repositories;
using FilmAppApi.Models;
using FilmAppApi.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private UserRepository _repoUser { get; }
        private CommentRepository _repoCmt { get; }
        private MovieRepository _repoMovie { get; }
        public CommentController(UserRepository user, CommentRepository comment, MovieRepository movie)
        {
            _repoCmt = comment;
            _repoMovie = movie;
            _repoUser = user;
        }
        [HttpPost]
        public IActionResult Create(InsertComment comment)
        {
            _repoCmt.Insert(comment.ToDal());
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(UpdateComment comment)
        {
            _repoCmt.Update(comment.ToDal());
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(DeleteComment comment)
        {
            _repoCmt.Delete(comment.ToDal());
            return Ok();
        }
        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            CompleteComment comment = _repoCmt.GetFullComments().Where(x=>x.Id == Id).Select(c=>c.ToApi()).SingleOrDefault();

            return Ok(comment);
        }
        [HttpGet]
        public IActionResult GetFullComments()
        {
            return Ok(_repoCmt.GetFullComments());
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repoCmt.GetAll());
        }


    }
}
