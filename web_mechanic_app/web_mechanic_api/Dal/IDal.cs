using System.Collections.Generic;
using web_mechanic_api.Models;

namespace web_mechanic_api.Dal
{
    public interface IDal
    {
      void Cadastrar(EntidadeDominio entidade);
      List<EntidadeDominio> Listar();
      List<EntidadeDominio> Pesquisar(EntidadeDominio entidade, List<string> filtros);
      void Alterar(EntidadeDominio entidade);
      void Deletar(EntidadeDominio entidade);
    }
}