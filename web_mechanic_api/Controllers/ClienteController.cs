using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_mechanic_api.Dal;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController: Controller
    {
        public ClienteController()
        {}

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
          try
          {
            Fachada fachada = new Fachada();
            List<EntidadeDominio> clientesEntidade = fachada.Listar();
            List<Cliente> retorno = new List<Cliente>();
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
        
        [HttpGet("filtrar")]
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

        [HttpPost("NovoCliente")]
        public IActionResult NovoCliente(Cliente cliente)
        {
          try
          {
             Fachada fachada = new Fachada();
            EntidadeDominio clienteRetorno = fachada.Cadastrar(cliente);
            if(clienteRetorno.GetType() == typeof(Cliente))
            {
              clienteRetorno = (Cliente)clienteRetorno;
              return Ok(clienteRetorno);
            }
            else
            {
              Retorno retorno = (Retorno)clienteRetorno;
              return BadRequest(retorno);
            }
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpPost("NovoEndereco")]
        public IActionResult NovoEndereco(Cliente cliente)
        {
          try
          {
            // ClienteDal clienteDal = new ClienteDal();
            // EntidadeDominio clienteRetorno = clienteDal.Cadastrar(cliente);
            // if(clienteRetorno.GetType() == typeof(Cliente))
            // {
            //   clienteRetorno = (Cliente)clienteRetorno;
            //   return Ok(clienteRetorno);
            // }
            // else
            // {
            //   Retorno retorno = (Retorno)clienteRetorno;
            //   List<Retorno> listaRetorno = new List<Retorno>();
            //   listaRetorno.Add(retorno);
              return BadRequest();
            //}
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpPost("NovoCartao")]
        public IActionResult NovoCartao(Cliente cliente)
        {
          try
          {
            // ClienteDal clienteDal = new ClienteDal();
            // EntidadeDominio clienteRetorno = clienteDal.Cadastrar(cliente);
            // if(clienteRetorno.GetType() == typeof(Cliente))
            // {
            //   clienteRetorno = (Cliente)clienteRetorno;
            //   return Ok(clienteRetorno);
            // }
            // else
            // {
            //   Retorno retorno = (Retorno)clienteRetorno;
            //   List<Retorno> listaRetorno = new List<Retorno>();
            //   listaRetorno.Add(retorno);
              return BadRequest();
            //}
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpPut("AlterarCliente")]
        public IActionResult AlterarCliente(Cliente cliente)
        {
          try
          {
            ClienteDal clienteDal = new ClienteDal();
            clienteDal.Alterar(cliente);
            return Ok();
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpPut("AlterarEndereco")]
        public IActionResult AlterarEndereco(Cliente cliente)
        {
          try
          {
            ClienteDal clienteDal = new ClienteDal();
            clienteDal.Alterar(cliente);
            return Ok();
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpPut("AlterarCartao")]
        public IActionResult AlteraVartao(Cliente cliente)
        {
          try
          {
            ClienteDal clienteDal = new ClienteDal();
            clienteDal.Alterar(cliente);
            return Ok();
          }
          catch (Exception excessao)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, excessao);
          }
        }

        [HttpDelete("DeletarEndereco")]
        public IActionResult DeletarEndereco(Cliente cliente)
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

        [HttpDelete("DeletarEndereco")]
        public IActionResult DeletarCartao(Cliente cliente)
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