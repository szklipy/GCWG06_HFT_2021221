using GCWG06_HFT_2021221.Logic;
using GCWG06_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GCWG06_HFT_2021221.Endpoint2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeLogic logic;
        //IHubContext<SignalRHub> hub;

        public EmployeeController(IEmployeeLogic logic/*, IHubContext<SignalRHub> hub*/)
        {
            this.logic = logic;
            //this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Employee> ReadAll()
        {
            return this.logic.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public Employee GetOne(int id)
        {
            return this.logic.GetEmployeeById(id);
        }

        [HttpPost]
        public void Create([FromBody] Employee value)
        {
            this.logic.Create(value);
            //this.hub.Clients.All.SendAsync("EmployeeCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Employee value)
        {
            this.logic.Update(value);
            //this.hub.Clients.All.SendAsync("EmployeeUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeeToDelete = this.logic.GetEmployeeById(id);
            this.logic.Delete(id);
            //this.hub.Clients.All.SendAsync("ActorDeleted", employeeToDelete);
        }
    }
}
