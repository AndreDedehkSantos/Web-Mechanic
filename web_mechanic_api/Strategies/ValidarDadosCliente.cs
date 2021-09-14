using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarDadosCliente : IStrategy
  {
      public EntidadeDominio Processar(EntidadeDominio entidade)
      {
        Cliente cliente = (Cliente)entidade;

        List<string> erroDadosCliente = new List<string>();

        if(string.IsNullOrEmpty(cliente.nome))
        {
          erroDadosCliente.Add("Nome é um Campo Obrigatório!");
        }
        bool numeros = Regex.IsMatch(cliente.telefone.ddd, (@"[^0-9]"));
        if(string.IsNullOrEmpty(cliente.cpf))
        {
          erroDadosCliente.Add("CPF é um Campo Obrigatório!");
        }
        else
        {
          if(cliente.cpf.Length != 11 || numeros)
          {
            erroDadosCliente.Add("CPF Inválido!");
          }
        }
        if(string.IsNullOrEmpty(cliente.dataNascimento))
        {
          erroDadosCliente.Add("Data de Nascimento é um Campo Obrigatório!");
        }
        if(string.IsNullOrEmpty(cliente.email))
        {
          erroDadosCliente.Add("Email é um Campo Obrigatório!");
        }
        string[] generos = {"Masculino", "Feminino", "Outro"};
        if(Array.IndexOf(generos, cliente.genero) == -1)
        {
          erroDadosCliente.Add("Gênero Selecionado é Inválido!");
        }
        if(erroDadosCliente.Count > 0)
        {
          Console.WriteLine("Cliente tá errado!");
          Retorno retorno = new Retorno(erroDadosCliente);
          return retorno;
        }
        else
        {
          return cliente;
        }
      }
    }
}