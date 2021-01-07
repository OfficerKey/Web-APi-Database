using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSqlsController : Controller, IUserSql
    {
        private readonly IConfiguration _configuration;

        public UserSqlsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"Delete from dbo.UserName where id=" + id + "";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CommandsConnection");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Delete success");
        }
        [HttpGet("Display")]
        public JsonResult Get()
        {
            string query = @"select * from dbo.UserName";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CommandsConnection");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);





                    myReader.Close();
                    myCon.Close();
                }
            }

            if (table == null)
            {
                return new JsonResult("Not Found");
            }
            else
            {
                return new JsonResult(table);

            }
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select * from dbo.UserName where id=" + id + "";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CommandsConnection");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpGet]
        public IActionResult PostMethod()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostMethod([FromForm] UserSql user)
        {
            if (ModelState.IsValid && user != null && !(string.IsNullOrEmpty(user.UserName)))
            {


                string query = @"insert into dbo.UserName values(" + user.Id + ",'" + user.UserName + @"')";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("CommandsConnection");
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }


                return View();

            }
            else
            {
                return View("Bed");
            }
        }
        [HttpGet("put")]
        public IActionResult PutMethod()
        {
            return View();
        }
        [HttpPost("put")]
        public IActionResult PutMethod([FromForm] UserSql user)
        {
            if (ModelState.IsValid && user != null && !(string.IsNullOrEmpty(user.UserName)))
            {
                string query = @"update dbo.UserName set UserName='" + user.UserName + @"' where Id=" + user.Id + @"";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("CommandsConnection");
                SqlDataReader myReader;

                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                        myCon.Close();
                    }
                }
                return View();
            }
            else
            {
                return View("Bad");
            }
        }
    }
}
