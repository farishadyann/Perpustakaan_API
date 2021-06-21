using System;
using Action = PerpustakaanAPI.Respository.Class.Action;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PerpustakaanAPI.Entity.Tables;
using PerpustakaanAPI.Entity.Response;
using PerpustakaanAPI.Core;
using PerpustakaanAPI.Helper;
using Microsoft.AspNetCore.Http;

namespace PerpustakaanAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Action connection = new Action(new Core.Context());
        Cryptography _cryptography = new Cryptography();
        JwtService _jwtService = new JwtService();
        #region User

        [HttpGet]
        [Route("Users")]
        public IActionResult Users()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                MS_User username = new MS_User
                {
                    UserName = token.Issuer,
                    IsDelete = false
                };
                var user = connection.UserAuthentications(username);

                return Ok(user);
            }
            catch(Exception ex)
            {
                return Unauthorized();
            }
            
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(MS_User Param)
        {
            MS_User user = connection.UserAuthentications(Param);

            if (user == null) return BadRequest(new { message = "Wrong Username" });
            if (!Convert.ToBoolean(user.IsActive)) return BadRequest("User is not active");
            if (user.Password != _cryptography.Encrypt(Param.Password)) return BadRequest("Wrong Password");

            var jwt = _jwtService.Generate(Param.UserName);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
                Secure=true,
                SameSite = SameSiteMode.None
            }) ;

            return Ok(new { message="Success"});
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(MS_User data)
        {
            var connection = new Action(new Context());
            MS_User Insert = new MS_User()
            {
                UserID_PK = data.UserID_PK,
                UserName = data.UserName,
                Password = _cryptography.Encrypt(data.Password),
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,
                UserRoleID_FK = data.UserRoleID_FK,
                CreatedBy = "SYSTEM",
                CreatedDate = DateTime.Now,
                ModifiedBy = data.ModifiedBy,
                ModifiedDate = data.ModifiedDate
            };
            return Created("Success", connection.Create(Insert));
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("jwt",new CookieOptions
            {
                Secure = true,
                SameSite = SameSiteMode.None
            });
            return Ok(new { messages = "Success" });
            
        }

        [HttpPut]
        [Route("UpdateUser")]
        public MS_User UpdateUser(MS_User data)
        {
            var connection = new Action(new Context());
            MS_User Update = new MS_User()
            {
                UserID_PK = data.UserID_PK,
                UserName = data.UserName,
                Password = data.Password,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,
                UserRoleID_FK = data.UserRoleID_FK,
                CreatedBy = data.CreatedBy,
                CreatedDate = data.CreatedDate,
                ModifiedBy = data.ModifiedBy,
                ModifiedDate = data.ModifiedDate
            };
            return connection.Put_User(Update);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public MS_User DeleteUser(MS_User data)
        {
            var connection = new Action(new Context());
            MS_User Update = new MS_User()
            {
                UserID_PK = data.UserID_PK,
                UserName = data.UserName,
                Password = data.Password,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,
                UserRoleID_FK = data.UserRoleID_FK,
                CreatedBy = data.CreatedBy,
                CreatedDate = data.CreatedDate,
                ModifiedBy = data.ModifiedBy,
                ModifiedDate = data.ModifiedDate
            };
            return connection.Put_User(Update);
        }

        #endregion
    }
}