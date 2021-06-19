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
        public List<BooksResponse> GetBooks(MS_Books Param)
        {
            List<BooksResponse> Result = new List<BooksResponse>();

            var ListBook = from a in _context.Books
                           join b in _context.Categories on a.BookCategoryID_FK equals b.CategoryID_PK
                           where
                           (Param.BookID_PK== null || a.BookID_PK.Equals(Param.BookID_PK)) &&
                           (Param.BookName== null || a.BookName.Contains(Param.BookName)) &&
                           (Param.BookCategoryID_FK == null || a.BookCategoryID_FK.Equals(Param.BookCategoryID_FK)) &&
                           (Param.IsActive == null || a.IsActive.Equals(Param.IsActive)) &&
                           (a.IsDelete == false)
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

        public MS_Books GetBookByID(MS_Books Param)
        {
            return _context.Books.Where(x => x.BookID_PK == Param.BookID_PK).FirstOrDefault(); 
        }

        public MS_Books Insert_Book(MS_Books Data)
        {
            MS_Books RetVal = new MS_Books();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Response = _context.Books.Add(Data);
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

        public MS_Books Update_Book(MS_Books Data)
        {
            MS_Books RetVal = new MS_Books();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var Response = _context.Books.Update(Data);
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
                catch (Exception ex)
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

        #region Status
        public List<MS_Status> Get_Statuses()
        {
            return _context.Statuses.ToList();
        }

        public MS_Status Insert_Status(MS_Status Data)
        {
            MS_Status RetVal = new MS_Status();
                using (var Transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var Response = _context.Statuses.Add(Data);
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

        #region User
        public List<UserResponse> GetUsers()
        {
            List<UserResponse> RetVal = new List<UserResponse>();
            var ListUser = from a in _context.Users
                           join b in _context.UserRoles on a.UserRoleID_FK equals b.UserRoleID_PK
                           where (a.IsDelete == false)
                           select new 
                           {
                               oUserID_PK = a.UserID_PK,
                               oUserName = a.UserName,
                               oPassword = a.Password,
                               oUserRoleID_FK = a.UserRoleID_FK,
                               oUserRoleName = b.UserRoleName,
                               oIsActive = a.IsActive,
                               oIsDelete = a.IsDelete,
                               oCreatedDate = a.CreatedDate,
                               oCreatedBy = a.CreatedBy,
                               oModifiedDate = a.ModifiedDate,
                               oModifiedBy = a.ModifiedBy
                           };
            foreach(var data in ListUser)
            {
                UserResponse User = new UserResponse()
                {
                    UserID_PK = data.oUserID_PK,
                    UserName = data.oUserName,
                    Password = data.oPassword,
                    UserRoleID_FK = data.oUserRoleID_FK,
                    UserRoleName = data.oUserRoleName,
                    IsActive = data.oIsActive,
                    IsDelete = data.oIsDelete,
                    CreatedDate = data.oCreatedDate,
                    CreatedBy = data.oCreatedBy,
                    ModifiedBy = data.oModifiedBy,
                    ModifiedDate = data.oModifiedDate
                };
                RetVal.Add(User);
            }


            return RetVal;
        }

        public MS_User UserAuthentications(MS_User Param)
        {
            Param.Password = _cryptography.Encrypt(Param.Password);
            return _context.Users.Where(x => x.UserName == Param.UserName && x.Password==Param.Password && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
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
                    //Decrypt Password
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
        public List<PeminjamanResponse> GetPeminajamans()
        {
            List<PeminjamanResponse> RetVal = new List<PeminjamanResponse>();

            var ListPeminjaman = from a in _context.Peminjamans
                                 join b in _context.Books on a.BookID_FK equals b.BookID_PK
                                 join c in _context.Categories on b.BookCategoryID_FK equals c.CategoryID_PK
                                 join d in _context.Users on a.UserName equals d.UserName
                                 join e in _context.UserRoles on d.UserRoleID_FK equals e.UserRoleID_PK
                                 join f in _context.Statuses on a.StatusID_FK equals f.StatusID_PK
                                 select new
                                 {
                                     PeminjamanID_PK = a.PeminjamanID_PK,
                                     BookID_FK = a.BookID_FK,
                                     BookName = b.BookName,
                                     BookCategoryID_FK = b.BookCategoryID_FK,
                                     Category = c.Category,
                                     Description = b.Description,
                                     Stok = b.Stok,
                                     Penerbit = b.Penerbit,
                                     Penulis = b.Penulis,
                                     UserName = a.UserName,
                                     UserRoleID_FK = d.UserRoleID_FK,
                                     UserRoleName= e.UserRoleName,
                                     StatusID_FK = a.StatusID_FK,
                                     StatusName = f.StatusName,
                                     AlamatPengiriman = a.AlamatPengiriman,
                                     StartDate = a.StartDate,
                                     EndDate = a.EndDate,
                                     IsActive = a.IsActive,
                                     IsDelete = a.IsDelete,
                                     CreatedDate = a.CreatedDate,
                                     CreatedBy = a.CreatedBy,
                                     ModifiedDate = a.ModifiedDate,
                                     ModifiedBy = a.ModifiedBy
                                 };
            foreach(var data in ListPeminjaman)
            {
                PeminjamanResponse Peminjaman = new PeminjamanResponse()
                {
                    PeminjamanID_PK = data.PeminjamanID_PK,
                    BookID_FK = data.BookID_FK,
                    BookName = data.BookName,
                    BookCategoryID_FK = data.BookCategoryID_FK,
                    Category = data.Category,
                    Description = data.Description,
                    Stok = data.Stok,
                    Penerbit = data.Penerbit,
                    Penulis = data.Penulis,
                    UserName = data.UserName,
                    UserRoleID_FK = data.UserRoleID_FK,
                    UserRoleName = data.UserRoleName,
                    StatusID_FK = data.StatusID_FK,
                    StatusName = data.StatusName,
                    AlamatPengiriman = data.AlamatPengiriman,
                    StartDate = data.StartDate,
                    EndDate = data.EndDate,
                    IsActive = data.IsActive,
                    IsDelete = data.IsDelete,
                    CreatedDate = data.CreatedDate,
                    CreatedBy = data.CreatedBy,
                    ModifiedDate = data.ModifiedDate,
                    ModifiedBy = data.ModifiedBy
                };
                RetVal.Add(Peminjaman);
            }

            return RetVal;
        }

        public TR_Peminjaman GetPeminjamanByID(TR_Peminjaman Param)
        {
            return _context.Peminjamans.Where(x => x.PeminjamanID_PK == Param.PeminjamanID_PK).FirstOrDefault();
        }

        public TR_Peminjaman Post_Peminjaman(TR_Peminjaman Param)
        {
            TR_Peminjaman RetVal = new TR_Peminjaman();

            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //Peminjaman Operation
                    var ResponsePeminjamans = _context.Peminjamans.Add(Param);
                    _context.SaveChanges();
                    RetVal = ResponsePeminjamans.Entity;
                    Transaction.Commit();

                }
                catch (Exception ex)
                {

                }
            }
            return RetVal;
        }

        public TR_Peminjaman Put_Peminjaman(TR_Peminjaman Param)
        {
            TR_Peminjaman RetVal = new TR_Peminjaman();
            using (var Transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //Peminjaman Operation
                    TR_Peminjaman OldDataPeminjaman = GetPeminjamanByID(new TR_Peminjaman { PeminjamanID_PK = Param.PeminjamanID_PK });
                    var ResponsePeminjamans = _context.Peminjamans.Update(Param);
                    _context.SaveChanges();
                    RetVal = ResponsePeminjamans.Entity;

                    //Books Operation

                    MS_Books BooksByID = GetBookByID(new MS_Books() { BookID_PK = RetVal.BookID_FK });
                    if (RetVal.StatusID_FK == 2)
                    {
                        BooksByID.Stok = Convert.ToInt32(BooksByID.Stok) - 1;
                        var ResponseBooks = _context.Books.Update(BooksByID);
                        _context.SaveChanges();
                    }
                    else if (RetVal.StatusID_FK == 4)
                    {
                        BooksByID.Stok = Convert.ToInt32(BooksByID.Stok) + 1;
                        var ResponseBooks = _context.Books.Update(BooksByID);
                        _context.SaveChanges();
                    }

                    Transaction.Commit();

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
