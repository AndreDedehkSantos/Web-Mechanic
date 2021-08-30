
using System;
using System.Collections.Generic;
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
        erroTelefone.Add("Tipo de Telefone Inválido!");
      }
      if(String.IsNullOrEmpty(cliente.telefone.ddd))
      {
       erroTelefone.Add("Tipo de Telefone Inválido!");
      }
      if(String.IsNullOrEmpty(cliente.telefone.numero))
      {
        erroTelefone.Add("Tipo de Telefone Inválido!");
      }
      if(cliente.telefone.numero.Length < 8 || cliente.telefone.numero.Length > 9)
      {
        erroTelefone.Add("Tipo de Telefone Inválido!");
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