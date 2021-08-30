using web_mechanic_api.Models;

namespace web_mechanic_api.Strategies
{
    public interface IStrategy
    {
        EntidadeDominio Processar(EntidadeDominio entidade);
    }
}