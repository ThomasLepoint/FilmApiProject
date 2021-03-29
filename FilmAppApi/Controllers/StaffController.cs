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
    public class StaffController : ControllerBase
    {
        private StaffRepository _repo { get; set; }
        public StaffController(StaffRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            if (staff is null || !ModelState.IsValid)
                return BadRequest();

            Guid id = _repo.Insert(staff.ToDal());
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Staff staff)
        {
            if (staff is null || !ModelState.IsValid)
                return BadRequest();

            _repo.Update(staff.ToDal());
            //messageRepository.getAll().where(uint=>uint.userId == id).select(static => static.toApi())

            // Generate Token
            return Ok(new
            {
                //token = TokenManager.GenerateJWT(id, userRegister.Email)
            });
        }
        [HttpDelete]
        public IActionResult Delete(Guid Id, string Reason)
        {
            if (_repo.Get(Id) == null) return BadRequest();

            return Ok(_repo.Delete(Id, Reason));
        }
        [HttpGet]
        public IActionResult Get(Guid Id)
        {
            return Ok(_repo.Get(Id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
    }
}
