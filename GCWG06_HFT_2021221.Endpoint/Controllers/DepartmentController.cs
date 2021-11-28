using GCWG06_HFT_2021221.Logic;
using GCWG06_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentLogic deplogic;
        public DepartmentController(IDepartmentLogic deplogic)
        {
            this.deplogic = deplogic;
        }
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return deplogic.GetAllDepartments();
        }
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return deplogic.GetDepartmentById(id);
        }
        [HttpPost]
        public void Post([FromBody] Department value)
        {
            deplogic.Create(value);
        }
        [HttpPut]
        public void Put([FromBody] Department value)
        {
            deplogic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            deplogic.Delete(id);
        }
    }
}
