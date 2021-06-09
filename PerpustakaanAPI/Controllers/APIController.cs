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
    public class APIController : ControllerBase
    {
        private readonly Action connection = new Action(new Core.Context());

        #region Books
        [HttpGet]
        [Route("GetBooks")]
        public List<BooksResponse> GetBook()
        {
            return connection.GetBooks();
        }
        #endregion

        #region Categories

        [HttpGet]
        [Route("GetCategory")]
        public List<MS_Category> GetCategory()
        {
            return connection.GetCategories();
        }

        [HttpPost]
        [Route("InsertCategory")]
        public MS_Category InsertCategory(MS_Category data)
        {
            var connection = new Action(new Context());
            MS_Category Insert = new MS_Category()
            {
                CategoryID_PK = data.CategoryID_PK,
                Category = data.Category
            };
            return connection.Insert_Category(Insert);
            
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public MS_Category UpdateCategory(MS_Category data)
        {
            var connection = new Action(new Context());
            MS_Category Update = new MS_Category()
            {
                CategoryID_PK = data.CategoryID_PK,
                Category = data.Category
            };
            return connection.Update_Category(Update);
            
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public MS_Category DeleteCategory(MS_Category data)
        {
            var connection = new Action(new Context());
            MS_Category Insert = new MS_Category()
            {
                CategoryID_PK = data.CategoryID_PK,
                Category = data.Category
            };
            return connection.Delete_Category(Insert);
            
        }

        #endregion

        #region Status

        [HttpGet]
        [Route("GetStatus")]
        public List<MS_Status> GetStatus()
        {
            return connection.Get_Statuses();
        }

        #endregion

        #region User

        [HttpGet]
        [Route("GetUser")]
        public List<MS_User> GeUser()
        {
            return connection.GetUsers();
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

        #endregion

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

        #region Peminjaman

        [HttpGet]
        [Route("GetPeminjaman")]
        public List<TR_Peminjaman> GetPeminjaman()
        {
            return connection.GetPeminajamans();
        }

        #endregion

    }
}