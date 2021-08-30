using System.Collections.Generic;
using web_mechanic_api.Dal;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarExistenciaCliente : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      List<string> erroExistencia = new List<string>();
      ClienteDal clienteDal = new ClienteDal();
      string[] filtros = {"cpf = " + cliente.cpf};
      List<EntidadeDominio> retornoPesquisa = clienteDal.Pesquisar(cliente, filtros);
      if(retornoPesquisa.Count > 0)
      {
        erroExistencia.Add("CPF já Cadastrado!");
      }
      filtros[0] = cliente.email;
      retornoPesquisa = clienteDal.Pesquisar(cliente, filtros);
      if(retornoPesquisa.Count > 0)
      {
        erroExistencia.Add("Email já Cadastrado!");
      }
      if(erroExistencia.Count > 0)
      {
        Retorno retorno = new Retorno(erroExistencia);
        return retorno;
      }
      else{
        return cliente;
      }
    }
  }
}