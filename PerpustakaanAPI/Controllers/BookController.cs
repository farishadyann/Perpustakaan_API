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
    public class BookController : ControllerBase
    {
        private readonly Action connection = new Action(new Core.Context());
        #region Books
        [HttpPost]
        [Route("GetBooks")]
        public JsonResult GetBook(MS_Books Param)
        {
            //MS_Books Param = new MS_Books();
            List<BooksResponse> res = connection.GetBooks(Param);

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
    }
}