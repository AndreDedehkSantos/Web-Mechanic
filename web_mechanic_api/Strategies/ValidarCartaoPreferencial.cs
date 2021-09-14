using System.Collections.Generic;
using web_mechanic_api.Dal;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarCartaoPreferencial : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cartao cartao = (Cartao)entidade;
      List<EntidadeDominio> retornoPesquisa = new List<EntidadeDominio>();
      string filtro = "cliente_id = " + cartao.cliente_id;
      string[] filtros = {filtro};
      CartaoDal cartaoDal = new CartaoDal();
      retornoPesquisa = cartaoDal.Pesquisar(filtros);
      List<Cartao> cartoesCliente = new List<Cartao>();
      foreach(EntidadeDominio element in retornoPesquisa)
      {
        cartoesCliente.Add((Cartao)element);
      }
      bool validaPreferencial = false;
      foreach(Cartao cartaoCleinte in cartoesCliente)
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
        return cartao;
      }
    }
  }
}