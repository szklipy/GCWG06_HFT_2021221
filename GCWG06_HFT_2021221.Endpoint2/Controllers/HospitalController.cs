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
    public class HospitalController : ControllerBase
    {
        IHospitalLogic logic;

        public HospitalController(IHospitalLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Hospital> ReadAll()
        {
            return this.logic.GetAllHospitals();
        }

        [HttpGet("{id}")]
        public Hospital GetOne(int id)
        {
            return this.logic.GetHospitalById(id);
        }

        [HttpPost]
        public void Create([FromBody] Hospital value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Hospital value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
