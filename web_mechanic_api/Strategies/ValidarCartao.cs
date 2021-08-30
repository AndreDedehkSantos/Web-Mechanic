using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarCartao : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cartao cartao = (Cartao)entidade;
      List<string> erroCartao = new List<string>();
      string[] tiposCartao = {"Crédito, Débito"};
      if(Array.IndexOf(tiposCartao, cartao.tipo) == -1)
      {
        erroCartao.Add("Tipo do Cartão Inválido");
      }
      string[] bandeirasCartao = {"Mastercard", "Visa", "Elo", "Hipercard", "Maestro", "AmericanEX"};
      if(Array.IndexOf(bandeirasCartao, cartao.bandeira) == -1)
      {
        erroCartao.Add("Bandeira do Cartão Inválida!");
      }
      if(string.IsNullOrEmpty(cartao.numero))
      {
        erroCartao.Add("Número do Cartão é um Campo Obrigatório!");
      }
      if(string.IsNullOrEmpty(cartao.dataValidade))
      {
        erroCartao.Add("Data de Validade é um Campo Obrigatório!");
      }
      char[] dataValArr = cartao.dataValidade.ToCharArray();
      if(dataValArr.Length > 5)
      {
        erroCartao.Add("Data de Validade Inválida!");
      }
      else
      {
        if(char.IsDigit(dataValArr[0]) && char.IsDigit(dataValArr[1]) &&
           dataValArr[2] == '/' && char.IsDigit(dataValArr[3]) && char.IsDigit(dataValArr[4]))
        {
          int mes = (int)Char.GetNumericValue(dataValArr[0]) + (int)Char.GetNumericValue(dataValArr[1]);
          if(mes < 1 || mes > 12)
          {
            erroCartao.Add("Data de Validade Inválida!");
          }
        }
      }
      if(string.IsNullOrEmpty(cartao.nomeImpresso))
      {
        erroCartao.Add("Nome Impresso é um Campo Obrigatório!");
      }
      if(Regex.IsMatch(cartao.codigoVerificacao, "@[^0-9]") || cartao.codigoVerificacao.Length != 3)
      {
        erroCartao.Add("Código de Verificação Inválido!");
      }
      if(erroCartao.Count > 0)
      {
        Retorno retorno = new Retorno(erroCartao);
        return retorno;
      }
      else
      {
        return cartao;
      }
    }
  }
}