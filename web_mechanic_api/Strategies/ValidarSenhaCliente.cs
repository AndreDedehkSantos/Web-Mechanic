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
      Console.WriteLine("Passo 1");
      bool existeMaiuscula = false;
      string senhaMinuscula = cliente.senhas[0].ToLower();
      
      if(!(senhaMinuscula == cliente.senhas[0]))
      {
        existeMaiuscula = true;
      }
      Console.WriteLine("Passo 2");
      bool existeMinuscula = false;
      string senhaMaiuscula = cliente.senhas[0].ToUpper();
      if(!(senhaMaiuscula == cliente.senhas[0]))
      {
        existeMinuscula = true;
      }
      Console.WriteLine("Passo 3");
      bool existeNumero = Regex.IsMatch(cliente.senhas[0], (@"[0-9]"));
      Console.WriteLine("Passo 4");
     
      bool existeCaracter = Regex.IsMatch(cliente.senhas[0], (@"[^a-zA-Z0-9]"));
      if(cliente.senhas[0].Length < 8 || !existeMaiuscula || !existeMinuscula || !existeNumero || !existeCaracter)
      {
        erroSenha.Add("Senha muito Fraca!");
      }
      Console.WriteLine("Passo 5");
      if(erroSenha.Count > 0)
      {
        Retorno retorno = new Retorno(erroSenha);
        return retorno;
      }
      else
      {
        Console.WriteLine("Tudo Certo!");
        return cliente;
      }
    }
  }
}