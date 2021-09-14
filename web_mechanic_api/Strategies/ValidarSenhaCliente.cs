using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarSenhaCliente : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      List<string> erroSenha = new List<string>();
      if(!cliente.senhas[0].Equals(cliente.senhas[1]))
      {
        erroSenha.Add("Senhas Diferentes!");
      }
      bool existeMaiuscula = false;
      string senhaMinuscula = cliente.senhas[0].ToLower();
      
      if(!(senhaMinuscula == cliente.senhas[0]))
      {
        existeMaiuscula = true;
      }
      bool existeMinuscula = false;
      string senhaMaiuscula = cliente.senhas[0].ToUpper();
      if(!(senhaMaiuscula == cliente.senhas[0]))
      {
        existeMinuscula = true;
      }
      bool existeNumero = Regex.IsMatch(cliente.senhas[0], (@"[0-9]"));
     
      bool existeCaracter = Regex.IsMatch(cliente.senhas[0], (@"[^a-zA-Z0-9]"));
      if(cliente.senhas[0].Length < 8 || !existeMaiuscula || !existeMinuscula || !existeNumero || !existeCaracter)
      {
        erroSenha.Add("Senha muito Fraca!");
      }
      if(erroSenha.Count > 0)
      {
        Retorno retorno = new Retorno(erroSenha);
        return retorno;
      }
      else
      {
        return cliente;
      }
    }
  }
}