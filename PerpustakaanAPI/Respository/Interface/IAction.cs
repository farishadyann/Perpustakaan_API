using PerpustakaanAPI.Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerpustakaanAPI.Respository.Interface
{
    interface IAction
    {
        List<MS_Books> GetBooks();
        List<MS_Category> GetCategories();
    }
}
