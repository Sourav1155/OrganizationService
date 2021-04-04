using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrgDAL;

namespace OrgAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : Controller
    {
        OrganizationDbContext dbContext;
        public DepartmentsController(OrganizationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            var Depts = dbContext.Departments.ToList();
            return Depts;
        }

        [HttpGet("{id}")]
        public Department Get(int id)
        {
            var Dept = dbContext.Departments.Where(x => x.Did == id).FirstOrDefault();
            return Dept;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var Dept = dbContext.Departments.Where(x => x.Did == id).FirstOrDefault();
            dbContext.Remove(Dept);
            dbContext.SaveChanges();
            return "Record Deleted Successfully";
        }

        [HttpPost]
        public Department Post(Department D)
        {
            dbContext.Add(D);
            dbContext.SaveChanges();
            return D;
        }

        [HttpPut]
        public string Put(Department D)
        {
            dbContext.Update(D);
            dbContext.SaveChanges();
            return "Updated Successfully";
        }
    }
}
