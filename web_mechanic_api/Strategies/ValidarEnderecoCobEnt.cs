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
      Endereco endereco = (Endereco)entidade;
      List<EntidadeDominio> retornoEndereco = new List<EntidadeDominio>();
      EnderecoDal endDal = new EnderecoDal();
      string filtro = "cliente_id = " + endereco.cliente_id;
      string[] filtros = {filtro};
      retornoEndereco = endDal.Pesquisar(filtros);
      List<Endereco> enderecosCliente = new List<Endereco>();
      foreach(EntidadeDominio element in retornoEndereco)
      {
        enderecosCliente.Add((Endereco)element);
      }
      List<string> erroCobrancaEntrega = new List<string>();
      bool validaCobranca = false;
      bool validaEntrega = false;
      if(enderecosCliente.Count > 1)
      {
        foreach(Endereco enderecoCliente in enderecosCliente)
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
          return endereco;
        }
      }
      return endereco;
    }
  }
}