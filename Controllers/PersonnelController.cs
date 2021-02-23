using System;
using Microsoft.AspNetCore.Mvc;
using jobs.Models;
using jobs.Services;

namespace jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        private readonly PersonnelService _service;

        public PersonnelController(PersonnelService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Personnel> Post([FromBody] Personnel newPers)
        {
            try
            {
                return Ok(_service.Create(newPers));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}