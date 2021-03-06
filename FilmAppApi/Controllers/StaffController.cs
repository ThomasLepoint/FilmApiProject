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
    public class StaffController : ControllerBase
    {
        private StaffRepository _repo { get; set; }
        public StaffController(StaffRepository repo)
        {
            this._repo = repo;
        }
        ///<summary>Create a new Staff member only for Admin user</summary>
        [HttpPost]
        [Authorize("admin")]
        public IActionResult Create(Staff staff)
        {
            if (staff is null || !ModelState.IsValid)
                return BadRequest();

            Guid id = _repo.Insert(staff.ToDal());
            return Ok();
        }
        ///<summary>Update Staff member only for Admin user</summary>
        [HttpPut]
        [Authorize("admin")]
        public IActionResult Update(Staff staff)
        {
            if (staff is null || !ModelState.IsValid)
                return BadRequest();

            _repo.Update(staff.ToDal());
            return Ok();
        }
        ///<summary>Get Staff member informations</summary>
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult Get(Guid Id)
        {
            return Ok(_repo.Get(Id));
        }
        ///<summary>Get every Staff member informations</summary>
        [HttpGet]
        [Authorize("user")]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
    }
}
