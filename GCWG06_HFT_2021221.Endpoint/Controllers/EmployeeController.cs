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
    public class EmployeeController : ControllerBase
    {
        IEmployeeLogic logic;
        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            this.logic = employeeLogic;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return logic.GetAllEmployees();
        }
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return logic.GetEmployeeById(id);
        }
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            logic.Create(value);
        }
        [HttpPut("{id}")]
        public void Put([FromBody] Employee value)
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
