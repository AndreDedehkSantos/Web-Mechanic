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
      Cliente cliente = (Cliente)entidade;
      Cartao cartao = cliente.cartoes[cliente.cartoes.Count - 1];
      CartaoDal cartaoDal = new CartaoDal();
      string[] filtros = {"numero = " + cartao.numero};
      List<EntidadeDominio> resultadoPesquisa = cartaoDal.Pesquisar(filtros);
      if(resultadoPesquisa.Count > 0)
      {
        List<string> erroExistencia = new List<string>();
        erroExistencia.Add("Cartão já cadastrado");
        Retorno retorno = new Retorno(erroExistencia);
        return retorno;
      }
      else
      {
        return cliente;
      }
    }
  }
}