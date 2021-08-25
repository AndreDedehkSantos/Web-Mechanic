using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace web_mechanic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController: Controller
    {
        public ClienteController()
        {}

        [HttpGet]
        public IActionResult Get()
        {
          return Ok();
        }
  
        [HttpGet("{filtros}")]
        public IActionResult Get(List<string> filtros)
        {
          return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
          return Ok();
        }

        [HttpPut("{cliente_id}")]
        public IActionResult Put(int cliente_id)
        {
          return Ok();
        }

        [HttpDelete("{cliente_id}")]
        public IActionResult Delete(int cliente_id)
        {
          return Ok();
        }
    }
}