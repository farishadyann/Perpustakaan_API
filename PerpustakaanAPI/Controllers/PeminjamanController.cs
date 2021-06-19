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
    public class PeminjamanController : ControllerBase
    {
        private readonly Action connection = new Action(new Core.Context());
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
                PeminjamanID_PK = Params.PeminjamanID_PK,
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