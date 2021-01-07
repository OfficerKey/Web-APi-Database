using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    interface IUserSql
    {
        public JsonResult Get();
        public JsonResult Get(int id);
        public IActionResult PostMethod();
        public IActionResult PostMethod([FromForm] UserSql user);
        public IActionResult PutMethod();
        public IActionResult PutMethod([FromForm] UserSql user);
        public JsonResult Delete(int id);
    }
}
