using System.Collections.Generic;
using web_mechanic_api.Models;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api.Strategies
{
  public class CriptografarSenha : IStrategy
  {
    public EntidadeDominio Processar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      string senha = cliente.senhas[0];
      string senhaCript = string.Empty;
      for(int i = 0; i  < senha.Length; i++)
      {
        int caracter = (int)senha[i];
        int caracterCript = caracter + senha.Length;
        senhaCript += char.ConvertFromUtf32(caracterCript);
      }
      List<string> retoroSenha = new List<string>();
      retoroSenha.Add(senhaCript);
      Retorno retorno = new Retorno(retoroSenha);
      return retorno;
    }
  }
}