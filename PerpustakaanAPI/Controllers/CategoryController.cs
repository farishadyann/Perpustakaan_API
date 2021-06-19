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
    public class CategoryController : ControllerBase
    {
        private readonly Action connection = new Action(new Core.Context());
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
    }
}