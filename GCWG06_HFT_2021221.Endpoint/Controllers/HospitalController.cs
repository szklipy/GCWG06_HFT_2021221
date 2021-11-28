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
    public class HospitalController : ControllerBase
    {
        IHospitalLogic hl;
        public HospitalController(IHospitalLogic hl)
        {
            this.hl = hl;
        }

        [HttpGet]
        public IEnumerable<Hospital> Get()
        {
            return hl.GetAllHospitals();
        }
        [HttpGet("{id}")]
        public Hospital Get(int id)
        {
            return hl.GetHospitalById(id);
        }
        [HttpPost]
        public void Post([FromBody] Hospital value)
        {
            hl.Create(value);
        }
        [HttpPut]
        public void Put([FromBody] Hospital value)
        {
            hl.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            hl.Delete(id);
        }
    }
}
