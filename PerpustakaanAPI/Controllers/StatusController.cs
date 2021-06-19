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
    public class StatusController : ControllerBase
    {
        private readonly Action connection = new Action(new Core.Context());
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
    }
}