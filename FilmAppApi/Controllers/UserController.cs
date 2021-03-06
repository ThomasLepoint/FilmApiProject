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
using System.Net.Mail;
using System.Net;

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
        public UserController(UserRepository repo, CommentRepository repocmt, TokenManager tokenManager)
        {
            _repo = repo;
            _repoCmt = repocmt;
            _tokenManager = tokenManager;
        }
        ///<summary>Register or Create a new user</summary>
        ///<param name="userRegister">Required : Login, Email, Password, ConfirmPassword</param>
        [HttpPost]
        public IActionResult Create(UserRegister userRegister)
        {
            if (userRegister is null || !ModelState.IsValid)
                return BadRequest();

            Guid id = _repo.Insert(userRegister.ToDal());
            return Ok();
        }
        ///<summary>Login method</summary>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLogin userLogin)
        {
            if (userLogin is null || !ModelState.IsValid)
                return BadRequest();

            d.UserEntity userApp = _repo.Login(userLogin.Login, userLogin.Password);

            if (userApp is null)
                return new ForbidResult();
            if (userApp.Disable_Until > DateTime.Now)
                return new ForbidResult($"Utilisateur bani jusqu'au {userApp.Disable_Until} : {userApp.Reason}");
            // Generate Token
            UserLoggedIn usrLogin = userApp.ToApiLogin();

            usrLogin.Usertoken = _tokenManager.GenerateJWT(userApp);

            return Ok(usrLogin);
        }
        ///<summary>Get user by Id with all of his comments</summary>
        [HttpGet("{Id}")]
        [Authorize("user")]
        public IActionResult Get(Guid Id)
        {
            UserWithComment user = _repo.Get(Id).ToApiUserComment();
            user.Comments = _repoCmt.GetUserComments(Id).Select(x => x.ToUserComment());
            return Ok(user);
        }
        ///<summary>Get all non banned users</summary>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<UserEntity> users = _repo.GetAll().Select(x => x.ToApi()).ToList();
            return Ok(_repo.GetAll());
        }
        ///<summary>Get all users only for Admin user</summary>
        [HttpGet]
        [Authorize("admin")]
        [Route("GetAllUsers")]
        public IActionResult GetEveryUser()
        {
            return Ok(_repo.GetEveryUser());
        }
        ///<summary>Update User</summary>
        [HttpPut]
        [Authorize("user")]
        public IActionResult Update(UserEntity user)
        {
            if (user is null || !ModelState.IsValid)
                return BadRequest();
            _repo.Update(user.ToDal());
            return Ok();
        }
        ///<summary>Sending mail test but not functional</summary>
        [HttpGet]
        [Route("SendMail")]
        public IActionResult sendMail()
        {
            //need to replace somme data on the fields
            var fromAddress = new MailAddress("insertmailhere", "name");
            var toAddress = new MailAddress("insertmailhere", "name");
            const string fromPassword = "********";
            const string subject = "test";
            const string body = "Hey now!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return Ok();
        }
        ///<summary>Ban User only for Admin user</summary>
        [HttpDelete("{Id}")]
        [Authorize("admin")]
        public IActionResult Delete(DeleteUser user)
        {
            if (_repo.Get(user.Id) == null) return BadRequest();
            return Ok(_repo.Delete(user.ToDal()));
        }
        ///<summary>Switch role of User only for Admin user</summary>
        [HttpPut]
        [Authorize("admin")]
        [Route("SwitchRole")]
        public IActionResult SwitchRole(UserEntity user)
        {
            return Ok(_repo.SwitchRole(user.Id));
        }
    }
}
