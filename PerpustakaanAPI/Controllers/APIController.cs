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
        [HttpPost]
        [Route("GetBooks")]
        public JsonResult GetBook(MS_Books Param)
        {
            //MS_Books Param = new MS_Books();
            List<BooksResponse> res= connection.GetBooks(Param);

            JsonResult Result = new JsonResult(res);
            return Result;
        }

        [HttpPost]
        [Route("InsertBook")]
        public MS_Books InsertBook(MS_Books data)
        {
            var connection = new Action(new Context());
            MS_Books Insert = new MS_Books()
            {
                BookID_PK= data.BookID_PK,
                BookName = data.BookName,
                BookCategoryID_FK = data.BookCategoryID_FK,
                Description = data.Description,
                Penerbit = data.Penerbit,
                Penulis = data.Penulis,
                Stok = data.Stok,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,
                CreatedBy = data.CreatedBy,
                CreatedDate= data.CreatedDate,
                ModifiedBy=data.ModifiedBy,
                ModifiedDate=data.ModifiedDate
            };
            return connection.Insert_Book(Insert);

        }

        [HttpPut]
        [Route("UpdateBook")]
        public MS_Books UpdateBook(MS_Books data)
        {
            var connection = new Action(new Context());
            MS_Books Insert = new MS_Books()
            {
                BookID_PK = data.BookID_PK,
                BookName = data.BookName,
                BookCategoryID_FK = data.BookCategoryID_FK,
                Description = data.Description,
                Penerbit = data.Penerbit,
                Penulis = data.Penulis,
                Stok = data.Stok,
                IsActive = data.IsActive,
                IsDelete = data.IsDelete,
                CreatedBy = data.CreatedBy,
                CreatedDate = data.CreatedDate,
                ModifiedBy = data.ModifiedBy,
                ModifiedDate = data.ModifiedDate
            };
            return connection.Update_Book(Insert);

        }

        [HttpPut]
        [Route("DeleteBook")]
        public MS_Books DeleteBook(MS_Books data)
        {
            var connection = new Action(new Context());
            MS_Books Insert = new MS_Books()
            {
                BookID_PK = data.BookID_PK,
                BookName = data.BookName,
                BookCategoryID_FK = data.BookCategoryID_FK,
                Description = data.Description,
                Penerbit = data.Penerbit,
                Penulis = data.Penulis,
                Stok = data.Stok,
                IsActive = data.IsActive,
                IsDelete = true,
                CreatedBy = data.CreatedBy,
                CreatedDate = data.CreatedDate,
                ModifiedBy = data.ModifiedBy,
                ModifiedDate = data.ModifiedDate
            };
            return connection.Update_Book(Insert);

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

        [HttpPost]
        [Route("InsertStatus")]
        public MS_Status InsertStatus(MS_Status data)
        {
            var connection = new Action(new Context());
            MS_Status Insert = new MS_Status()
            {
                StatusID_PK = data.StatusID_PK,
                StatusName = data.StatusName
            };
            return connection.Insert_Status(Insert);

        }
        #endregion

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
        public List<PeminjamanResponse> GetPeminjaman()
        {
            return connection.GetPeminajamans();
        }

        [HttpPost]
        [Route("PostPeminjaman")]
        public TR_Peminjaman PostPeminjaman(TR_Peminjaman Params)
        {
            TR_Peminjaman PostValue = new TR_Peminjaman()
            {
                BookID_FK = Params.BookID_FK,
                UserName = Params.UserName,
                AlamatPengiriman = Params.AlamatPengiriman,
                StartDate = Params.StartDate,
                EndDate = Params.EndDate,
                StatusID_FK = 1,
                IsActive = true,
                IsDelete = false,
                CreatedBy = Params.CreatedBy,
                CreatedDate = Params.CreatedDate,
                ModifiedBy = Params.ModifiedBy,
                ModifiedDate = Params.ModifiedDate
            };
            return connection.Post_Peminjaman(PostValue);
        }

        [HttpPost]
        [Route("PutPeminjaman")]
        public TR_Peminjaman PutPeminjaman(TR_Peminjaman Params)
        {
            TR_Peminjaman PostValue = new TR_Peminjaman()
            {
                PeminjamanID_PK =Params.PeminjamanID_PK,
                BookID_FK = Params.BookID_FK,
                UserName = Params.UserName,
                AlamatPengiriman = Params.AlamatPengiriman,
                StartDate = Params.StartDate,
                EndDate = Params.EndDate,
                StatusID_FK = Params.StatusID_FK,
                IsActive = Params.IsActive,
                IsDelete = Params.IsDelete,
                CreatedBy = Params.CreatedBy,
                CreatedDate = Params.CreatedDate,
                ModifiedBy = Params.ModifiedBy,
                ModifiedDate = Params.ModifiedDate
            };
            return connection.Put_Peminjaman(PostValue);
        }

        #endregion

    }
}