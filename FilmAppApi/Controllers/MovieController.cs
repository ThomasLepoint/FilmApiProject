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
    public class MovieController : ControllerBase
    {
        private MovieRepository _repo { get; }
        private CommentRepository _cmtRepo { get; }
        private StaffRepository _staffRepo { get; }
        private CastingRepository _castRepo { get; }
        public MovieController(MovieRepository repo, StaffRepository staffRepo, CastingRepository castRepo, CommentRepository cmtRepo)
        {
            this._repo = repo;
            this._staffRepo = staffRepo;
            this._castRepo = castRepo;
            this._cmtRepo = _cmtRepo;
        }
        ///<summary>Create a new movie only for Admin user</summary>
        [HttpPost]
        [Authorize("admin")]
        public IActionResult Create(InsertCompleteMovie _movie)
        {
            if (_movie is null || !ModelState.IsValid)
                return BadRequest();

            Movie movie = _movie.ToMovie();
            Guid id = _repo.Insert(movie.ToDal());
            if (!(_movie.Casting is null))
            {
                foreach (InsertCasting cast in _movie.Casting)
                {
                    cast.MovieId = id;
                    _castRepo.Insert(cast.ToDal());
                }
            }
            return Ok();
        }
        ///<summary>Update a movie only for Admin user</summary>
        [HttpPut]
        [Authorize("admin")]
        public IActionResult Update(Movie movie)
        {
            if (movie is null || !ModelState.IsValid)
                return BadRequest();

            _repo.Update(movie.ToDal());

            // Generate Token
            return Ok();
        }
        ///<summary>Get a movie by Id with complete Casting, Director, Scriptwriter and every comment link with the movie</summary>
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult Get(Guid Id)
        {
            CompleteMovie movie = _repo.Get(Id).ToAPi();
            movie.ScriptWriter = _staffRepo.GetAll().Where(sId => sId.Id == movie.ScriptWriterId).Select(x=>x.ToApi()).SingleOrDefault();
            movie.Director = _staffRepo.GetAll().Where(sId => sId.Id == movie.DirectorId).Select(x=>x.ToApi()).SingleOrDefault();
            movie.Casting = _castRepo.GetCasting(Id).Select(x => x.ToApi());
            movie.Comments = _cmtRepo.GetMovieComments(Id).Select(x=>x.ToMovieComment());
            return Ok(movie);
        }
        ///<summary>Get every Movies</summary>
        [HttpGet]
        [Authorize("user")]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
    }
}
