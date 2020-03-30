using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace theapi.Controllers
{
   
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ValuesController(IConfiguration config)
        {
            configuration = config;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<Student> Get()
        {

          var  connectionString = configuration.GetConnectionString("DefaultConnection");

            DataTable resultTable = new DataTable();

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("No connection string in config.json");

          

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM [SalesLT].[Customer]", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                         
                            sda.Fill(resultTable);                             
                        
                    }
                }
            }


            return new Student() { Id = 1, Name = resultTable.Rows[0][3].ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
