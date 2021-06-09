using PerpustakaanAPI.Core;
using PerpustakaanAPI.Entity.Tables;
using PerpustakaanAPI.Entity.Response;
using System.Collections.Generic;
using System.Linq;
using System;
using PerpustakaanAPI.Helper;

namespace PerpustakaanAPI.Respository.Class
{
    public class Action
    {
        private readonly Context _context;
        Cryptography _cryptography = new Cryptography();
        public Action(Context context)
        {
            this._context = context;
        }
        #region Books
        public List<BooksResponse> GetBooks()
        {
            List<BooksResponse> Result = new List<BooksResponse>();

            var ListBook = from a in _context.Books
                           join b in _context.Categories on a.BookCategoryID_FK equals b.CategoryID_PK
                           where (a.IsActive == true && a.IsDelete == false)
                           select new
                           {
                               oBookID = a.BookID_PK,
                               oBookName = a.BookName,
                               oBookCategoryID = a.BookCategoryID_FK,
                               oBookCategori = b.Category,
                               oDescription = a.Description,
                               oStok = a.Stok,
                               oPenerbit = a.Penerbit,
                               oPenulis = a.Penulis,
                               oIsActive = a.IsActive,
                               oIsDelete = a.IsDelete,
                               oCreatedDate = a.CreatedDate,
                               oCreatedBy = a.CreatedBy,
                               oModifiedDate = a.ModifiedDate,
                               oModifiedBy = a.ModifiedBy
                           };

            foreach(var data in ListBook)
            {
                BooksResponse Book = new BooksResponse()
                {
                    BookID_PK = data.oBookID,
                    BookName = data.oBookName,
                    BookCategoryID_FK = data.oBookCategoryID,
                    Category = data.oBookCategori,
                    Description = data.oDescription,
                    Penerbit = data.oPenerbit,
                    Penulis = data.oPenulis,
                    IsActive = data.oIsActive,
                    IsDelete = data.oIsDelete,
                    Stok = data.oStok,
                    CreatedDate = data.oCreatedDate,
                    CreatedBy = data.oCreatedBy,
                    ModifiedBy = data.oModifiedBy,
                    ModifiedDate = data.oModifiedDate
                };
                Result.Add(Book);
            }

            return Result;
        }
        #endregion

        #region Status
        public List<MS_Status> Get_Statuses()
        {
            return _context.Statuses.ToList();
        }
        #endregion

        #region User
        public List<MS_User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public MS_User Insert_User(MS_User Data)
        {
            MS_User RetVal = new MS_User();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //Encrypt Password
                    Data.Password = _cryptography.Encrypt(Data.Password);

                    var Response = _context.Users.Add(Data);
                    _context.SaveChanges();
                    Transaction.Commit();
                    
                    RetVal = Response.Entity;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    RetVal.Password = _cryptography.Decrypt(RetVal.Password);
                }
            }
            return RetVal;
        }

        public MS_User Put_User(MS_User Data)
        {
            MS_User RetVal = new MS_User();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Response = _context.Users.Update(Data);
                    _context.SaveChanges();
                    Transaction.Commit();
                    RetVal = Response.Entity;
                }
                catch (Exception ex)
                {

                }
            }
            return RetVal;
        }
        #endregion

        #region UserRole
        public List<MS_UserRole> GetUserRoles()
        {
            return _context.UserRoles.ToList();
        }

        public MS_UserRole Insert_UserRole(MS_UserRole Data)
        {
            MS_UserRole RetVal = new MS_UserRole();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Response = _context.UserRoles.Add(Data);
                    _context.SaveChanges();
                    Transaction.Commit();
                    RetVal = Response.Entity;
                }
                catch (Exception ex)
                {

                }
            }
            return RetVal;
        }
        #endregion

        #region Peminjaman
        public List<TR_Peminjaman> GetPeminajamans()
        {
            return _context.Peminjamans.ToList();
        }
        #endregion

        #region Category

        public List<MS_Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public MS_Category Insert_Category(MS_Category Data)
        {
            MS_Category RetVal = new MS_Category();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Response = _context.Categories.Add(Data);
                    _context.SaveChanges();
                    Transaction.Commit();
                    RetVal = Response.Entity;
                }
                catch(Exception ex)
                {

                }
            }
            return RetVal;
        }

        public MS_Category Update_Category(MS_Category Data)
        {
            MS_Category RetVal = new MS_Category();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Response = _context.Categories.Update(Data);
                    _context.SaveChanges();
                    Transaction.Commit();
                    RetVal = Response.Entity;
                }
                catch (Exception ex)
                {

                }
            }
            return RetVal;
        }

        public MS_Category Delete_Category(MS_Category Data)
        {
            MS_Category RetVal = new MS_Category();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Response = _context.Categories.Remove(Data);
                    _context.SaveChanges();
                    Transaction.Commit();
                    RetVal = Response.Entity;
                }
                catch (Exception ex)
                {

                }
            }
            return RetVal;
        }

        #endregion
    }
}
