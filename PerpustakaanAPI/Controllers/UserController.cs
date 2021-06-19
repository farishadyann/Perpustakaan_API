using System;
using Action = PerpustakaanAPI.Respository.Class.Action;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PerpustakaanAPI.Entity.Tables;
using PerpustakaanAPI.Entity.Response;
using PerpustakaanAPI.Core;

namespace PerpustakaanAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Action connection = new Action(new Core.Context());
        #region User

        [HttpGet]
        [Route("GetUser")]
        public List<UserResponse> GeUser()
        {
            return connection.GetUsers();
        }

        [HttpPost]
        [Route("UserAuthentication")]
        public MS_User UserAuthentication(MS_User Param)
        {
            return connection.UserAuthentications(Param);
        }

        [HttpPost]
        [Route("InsertUser")]
        public MS_User InsertUser(MS_User data)
        {
            var connection = new Action(new Context());
            MS_User Insert = new MS_User()
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
            return connection.Insert_User(Insert);
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