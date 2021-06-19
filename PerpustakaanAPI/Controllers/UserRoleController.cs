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
    public class UserRoleController : ControllerBase
    {
        private readonly Action connection = new Action(new Core.Context());

        #region UserRole

        [HttpGet]
        [Route("GetUserRole")]
        public List<MS_UserRole> GetUserRole()
        {
            return connection.GetUserRoles();
        }

        [HttpPost]
        [Route("InsertUserRole")]
        public MS_UserRole InsertUser(MS_UserRole data)
        {
            var connection = new Action(new Context());
            MS_UserRole Insert = new MS_UserRole()
            {
                UserRoleID_PK = data.UserRoleID_PK,
                UserRoleName = data.UserRoleName
            };
            return connection.Insert_UserRole(Insert);
        }
        #endregion
    }
}