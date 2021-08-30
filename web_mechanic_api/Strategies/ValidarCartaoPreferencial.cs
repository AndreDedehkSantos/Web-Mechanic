using System.Collections.Generic;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarCartaoPreferencial : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;

      bool validaPreferencial = false;
      foreach(Cartao cartao in cliente.cartoes)
      {
        if(cartao.preferencial){
          validaPreferencial = true;
        }
      }
      if(!validaPreferencial)
      {
        List<string> erroPreferencial = new List<string>();
        erroPreferencial.Add("É necessário pelo menos um Cartão Preferencial");
        Retorno retorno = new Retorno(erroPreferencial);
        return retorno;
      }
      else
      {
        return cliente;
      }
    }
  }
}