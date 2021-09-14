using System.Collections.Generic;
using web_mechanic_api.Dal;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarExistenciaCartao : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cartao cartao = (Cartao)entidade;
      List<EntidadeDominio> retornoPesquisa = new List<EntidadeDominio>();
      string filtro = "cliente_id = " + cartao.cliente_id;
      string[] filtros = {filtro};
      CartaoDal cartaoDal = new CartaoDal();
      retornoPesquisa = cartaoDal.Pesquisar(filtros);
      if(retornoPesquisa.Count > 0)
      {
        List<string> erroExistencia = new List<string>();
        erroExistencia.Add("Cartão já cadastrado");
        Retorno retorno = new Retorno(erroExistencia);
        return retorno;
      }
      else
      {
        return cartao;
      }
    }
  }
}