using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUserMongo
    {
        
        public IEnumerable<UserMongo> Get();
        
        public IEnumerable<UserMongo> Get(int id);
        
        public IActionResult PostMethod();
        
        public IActionResult PostMethod([FromForm] UserMongo user);

        
        public IActionResult Put();

        
        public IActionResult Put([FromForm] UserMongo user);

        
        public IActionResult Delete(int id);
    }
}
