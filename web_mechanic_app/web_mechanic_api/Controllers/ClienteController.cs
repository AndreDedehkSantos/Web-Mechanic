using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_mechanic_api.Dal;
using web_mechanic_api.Models;
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
          try
          {
            List<string> bandeiras = new List<string>();
            ClienteDal clienteDal = new ClienteDal();
            List<EntidadeDominio> clientesEntidade = clienteDal.Listar();
            var retorno = new List<Cliente>();
            foreach(EntidadeDominio cliente in clientesEntidade)
            {
              retorno.Add((Cliente)cliente);
            }
            return Ok(retorno);
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }
        
        [HttpGet("{filtros}")]
        public IActionResult Pesquisar(string[] filtros)
        {
          try
          {
            return Ok();
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpPost]
        public IActionResult Post(EntidadeDominio entidade)
        {
          try
          {
            ClienteDal clienteDal = new ClienteDal();
            clienteDal.Cadastrar(entidade);
            return Created($"/api/Cliente/", "Sucess");
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpPut("edit/{Entidade}")]
        public IActionResult Put(EntidadeDominio entidade)
        {
          try
          {
            ClienteDal clienteDal = new ClienteDal();
            clienteDal.Alterar(entidade);
            return Ok();
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpDelete("{cliente_id}")]
        public IActionResult Delete(int cliente_id)
        {
          try
          {
            return Ok();
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }
    }
}