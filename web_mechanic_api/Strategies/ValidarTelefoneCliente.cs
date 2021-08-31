
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarTelefoneCliente : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      List<string> erroTelefone = new List<string>();

      string[] tiposTelefone = {"Residencial", "Celular", "Comercial"};
      if(Array.IndexOf(tiposTelefone, cliente.telefone.tipo) == -1)
      {
        erroTelefone.Add("Tipo do Telefone Inválido!");
      }
      bool numeros = Regex.IsMatch(cliente.telefone.ddd, (@"[^0-9]"));
      if(String.IsNullOrEmpty(cliente.telefone.ddd))
      {
       erroTelefone.Add("DDD do Telefone é um Campo Obrigatório!");
      }
      else
      {
        if(cliente.telefone.ddd.Length != 2 || numeros)
        {
          erroTelefone.Add("DDD do Telefone Inválido!");
        }
      }
      if(String.IsNullOrEmpty(cliente.telefone.numero))
      {
        erroTelefone.Add("Número do Telefone é um Campo Obrigatório!");
      }
      else
      {
        if(cliente.telefone.numero.Length < 8 || cliente.telefone.numero.Length > 9 || numeros)
        {
          erroTelefone.Add("Número do Telefone Inválido!");
        }
      }
      if(erroTelefone.Count > 0)
      {
        Retorno retorno = new Retorno(erroTelefone);
        return retorno;
      }
      else
      {
        return cliente;
      }
    }
  }
}