using System;
using System.Collections.Generic;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
    public class ValidarEndereco : IStrategy
    {
      public EntidadeDominio Processar(EntidadeDominio entidade)
      {
        Endereco endereco = (Endereco)entidade;
        List<string> erroEndereco = new List<string>();

        string[] tiposEndereco = {"Casa", "Apartamento", "Comércio"};
        if(Array.IndexOf(tiposEndereco, endereco.tipo) == -1)
        {
          erroEndereco.Add("Tipo de Endereço Inválido!");
        }
        if(String.IsNullOrEmpty(endereco.descricao))
        {
        erroEndereco.Add("Descrição do Endereço é um Campo Obrigatório!");
        }
        string[] tiposLogradouro = {"Rua", "Avenida", "Travessa", "Estrada", "Alameda", "Rodovia", "Viela"};
        if(Array.IndexOf(tiposLogradouro, endereco.tipoLogradouro) == -1)
        {
          erroEndereco.Add("Tipo de Logradouro Inválido!");
        }
        if(String.IsNullOrEmpty(endereco.logradouro))
        {
          erroEndereco.Add("Logradouro é um Campo Obrigatório!");
        }
        if(String.IsNullOrEmpty(endereco.numero))
        {
          erroEndereco.Add("Número do Endereço é um Campo Obrigatório!");
        }
         if(String.IsNullOrEmpty(endereco.bairro))
        {
          erroEndereco.Add("Bairro é um Campo Obrigatório!");
        }
        if(String.IsNullOrEmpty(endereco.cep))
        {
          erroEndereco.Add("CEP é um Campo Obrigatório!");
        }
         if(endereco.cep.Length != 8)
        {
          erroEndereco.Add("CEP Inválido!");
        }
         if(String.IsNullOrEmpty(endereco.cidade.descricao))
        {
          erroEndereco.Add("Cidade é um Campo Obrigatório!");
        }
        string[] ufs = {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ",
                        "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"};   
        if(Array.IndexOf(ufs, endereco.estado.uf) == -1)
        {
          erroEndereco.Add("Estado Inválido!");
        }
        if(erroEndereco.Count > 0)
        {
          Retorno retorno = new Retorno(erroEndereco);
          return retorno;
        }
        else
        {
          return endereco;
        }
      }
    }
}