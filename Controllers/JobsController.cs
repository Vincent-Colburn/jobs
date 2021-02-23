using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobs.Models;
using jobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _js;

        public JobsController(JobsService js)
        {
            _js = js;
        }

        // GET api/bricks
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(_js.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/Jobs/5
        [HttpGet("{id}")]
        public ActionResult<Job> Get(int id)
        {
            try
            {
                return Ok(_js.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/Jobs
        [HttpPost]
        public ActionResult<Job> Post([FromBody] Job newJob)
        {
            try
            {
                return Ok(_js.Create(newJob));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/Jobs
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_js.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}