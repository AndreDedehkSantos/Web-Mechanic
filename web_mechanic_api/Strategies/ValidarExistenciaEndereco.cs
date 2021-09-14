using System.Collections.Generic;
using web_mechanic_api.Dal;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class ValidarExistenciaEndereco : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Endereco endereco = (Endereco)entidade;
      List<string> erroExistencia = new List<string>();
      List<EntidadeDominio> retornoEndereco = new List<EntidadeDominio>();
      EnderecoDal endDal = new EnderecoDal();
      string[] filtros = {"cliente_id = " + endereco.cliente_id, "cep = " + endereco.cep, "numero = " + endereco.numero, "complemento = " + endereco.complemento};
      List<EntidadeDominio> resultadoPesquisa = endDal.Pesquisar(filtros);
      if(resultadoPesquisa.Count > 0)
      {
        erroExistencia.Add("Endereço já cadastrado");
        Retorno retorno = new Retorno(erroExistencia);
        return retorno;
      }
      else
      {
        return endereco;
      }
    }
  }
}