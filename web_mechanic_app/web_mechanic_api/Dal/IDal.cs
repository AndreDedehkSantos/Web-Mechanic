using System.Collections.Generic;
using web_mechanic_api.Models;

namespace web_mechanic_api.Dal
{
    public interface IDal
    {
      public void Cadastrar(EntidadeDominio entidade);
      public List<EntidadeDominio> Listar (EntidadeDominio entidade);
      public List<EntidadeDominio> Procurar(EntidadeDominio entidade, List<string> filtros);
      public void Alterar(EntidadeDominio entidade);
      public void Deletar(EntidadeDominio entidade);
    }
}