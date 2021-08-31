using System.Collections.Generic;
using web_mechanic_api.Models;

namespace web_mechanic_api.Dal
{
    public interface IDal
    {
      EntidadeDominio Cadastrar(EntidadeDominio entidade);
      List<EntidadeDominio> Listar();
      List<EntidadeDominio> Pesquisar(string[] filtros);
      EntidadeDominio Alterar(EntidadeDominio entidade);
      void Deletar(EntidadeDominio entidade);
    }
}