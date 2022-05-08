using GCWG06_HFT_2021221.Logic;
using GCWG06_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GCWG06_HFT_2021221.Endpoint2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentLogic logic;

        public DepartmentController(IDepartmentLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Department> ReadAll()
        {
            return this.logic.GetAllDepartments();
        }

        [HttpGet("{id}")]
        public Department GetOne(int id)
        {
            return this.logic.GetDepartmentById(id);
        }

        [HttpPost]
        public void Create([FromBody] Department value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Department value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
