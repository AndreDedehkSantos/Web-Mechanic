using System.Collections.Generic;
using web_mechanic_api.Models;

namespace web_mechanic_api.ViewModels
{
    public class Retorno: EntidadeDominio
    {
      public Retorno(List<string> retornoString)
      {
        this.retornoString = retornoString;
      }
      public List<string> retornoString {get; set;}
    }
}