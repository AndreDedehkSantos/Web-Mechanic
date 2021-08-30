using System.Collections.Generic;
using web_mechanic_api.Dal;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarEnderecoCobEnt : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      List<string> erroCobrancaEntrega = new List<string>();
      bool validaCobranca = false;
      bool validaEntrega = false;
      foreach(Endereco enderecoCliente in cliente.enderecos)
      {
        if(enderecoCliente.cobranca)
        {
          validaCobranca = true;
        }
        if(enderecoCliente.entrega)
        {
          validaEntrega = true;
        }
      }
      if(!validaCobranca)
      {
        erroCobrancaEntrega.Add("É Necessário no Mínimo um Endereço de Combranca!");
      }
       if(!validaEntrega)
      {
        erroCobrancaEntrega.Add("É Necessário no Mínimo um Endereço de Entrega!");
      }
      if(erroCobrancaEntrega.Count > 0)
      {
        Retorno retorno = new Retorno(erroCobrancaEntrega);
        return retorno;
      }
      else
      {
        return cliente;
      }
    }
  }
}