using FilmApp.DAL.Repositories;
using FilmAppApi.Models;
using FilmAppApi.Tools;
using Microsoft.AspNetCore.Authorization;
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
            this._repoCmt = comment;
            this._repoMovie = movie;
            this._repoUser = user;
        }
        ///<summary>Create a new Comment</summary>
        [HttpPost]
        [Authorize("user")]
        public IActionResult Create(InsertComment comment)
        {
            _repoCmt.Insert(comment.ToDal());
            return Ok();
        }
        ///<summary>Update Comment</summary>
        [HttpPut]
        [Authorize("user")]
        public IActionResult Update(UpdateComment comment)
        {
            _repoCmt.Update(comment.ToDal());
            return Ok();
        }
        ///<summary>Diasble comment with date and reason only for Admin user</summary>
        [HttpDelete]
        [Authorize("admin")]
        public IActionResult Delete(DeleteComment comment)
        {
            _repoCmt.Delete(comment.ToDal());
            return Ok();
        }
        ///<summary>Get comment by Id with complete information (movie title, user login, ...)</summary>
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult Get(Guid Id)
        {
            CompleteComment comment = _repoCmt.GetFullComments().Where(x=>x.Id == Id).Select(c=>c.ToApi()).SingleOrDefault();

            return Ok(comment);
        }
        ///<summary>Get comment by Id from Movie(movie title, user login, ...)</summary>
        [HttpGet]
        [Authorize("user")]
        [Route("GetMovieComments/{Id}")]
        public IActionResult GetMovieComments(Guid Id)
        {
            return Ok(_repoCmt.GetMovieComments(Id));
        }
        ///<summary>Get comment by Id from User(movie title, user login, ...)</summary>
        [HttpGet]
        [Authorize("user")]
        [Route("GetUserComments/{Id}")]
        public IActionResult GetUserComments(Guid Id)
        {
            return Ok(_repoCmt.GetUserComments(Id));
        }
        ///<summary>Get comments with complete information (movie title, user login, ...)</summary>
        [HttpGet]
        [Authorize("user")]
        [Route("GetComments")]
        public IActionResult GetFullComments()
        {
            return Ok(_repoCmt.GetFullComments());
        }
        ///<summary>Get every non disabled comments with complete information (movie title, user login, ...)</summary>
        [HttpGet]
        [Authorize("user")]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_repoCmt.GetAll());
        }
        ///<summary>Get every comments with complete information (movie title, user login, ...) only for Admin user</summary>
        [HttpGet]
        [Authorize("admin")]
        [Route("GetAllComments")]
        public IActionResult GetEveryComments()
        {
            return Ok(_repoCmt.GetEveryComments());
        }


    }
}
