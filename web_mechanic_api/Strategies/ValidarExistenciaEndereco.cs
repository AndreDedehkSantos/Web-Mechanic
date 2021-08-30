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
      Cliente cliente = (Cliente)entidade;
      Endereco endereco = cliente.enderecos[cliente.enderecos.Count - 1];
      List<string> erroExistencia = new List<string>();
      EnderecoDal enderecoDal = new EnderecoDal();
      string[] filtros = {"cep = " + endereco.cep, "numero = " + endereco.numero, "complemento = " + endereco.complemento};
      List<EntidadeDominio> resultadoPesquisa = enderecoDal.Pesquisar(cliente, filtros);
      if(resultadoPesquisa.Count > 0)
      {
        erroExistencia.Add("Endereço já cadastrado");
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