using System.Collections.Generic;
using web_mechanic_api.Dal;
using web_mechanic_api.Models;
using web_mechanic_api.Strategies;
using web_mechanic_api.ViewModels;

namespace web_mechanic_api
{
  public class Fachada
  {
    List<IStrategy> cadastrarClienteStrategies = new List<IStrategy>();
    List<IStrategy> enderecoStrategies = new List<IStrategy>();
    List<IStrategy> cartaoStrategies = new List<IStrategy>();
    public Fachada()
    {
      
      ValidarDadosCliente validardadosCliente = new ValidarDadosCliente();
      ValidarExistenciaCliente validarExCliente = new ValidarExistenciaCliente();
      ValidarTelefoneCliente validarTelefoneCliente = new ValidarTelefoneCliente();
      ValidarEndereco validarEndereco = new ValidarEndereco();
      ValidarSenhaCliente validarSenhaCliente = new ValidarSenhaCliente();
      cadastrarClienteStrategies.Add(validardadosCliente);
      cadastrarClienteStrategies.Add(validarExCliente);
      cadastrarClienteStrategies.Add(validarTelefoneCliente);
      cadastrarClienteStrategies.Add(validarEndereco);
      cadastrarClienteStrategies.Add(validarSenhaCliente);

      ValidarEnderecoCobEnt validarEndCobEnt = new ValidarEnderecoCobEnt();
      ValidarExistenciaEndereco validarExEndereco = new ValidarExistenciaEndereco();
      enderecoStrategies.Add(validarEndereco);
      enderecoStrategies.Add(validarEndCobEnt);
      enderecoStrategies.Add(validarExEndereco);

      ValidarCartao validarCartao = new ValidarCartao();
      ValidarExistenciaCartao validarExCartao = new ValidarExistenciaCartao();
      ValidarCartaoPreferencial validarCartaoPref = new ValidarCartaoPreferencial();
      cartaoStrategies.Add(validarCartao);
      cartaoStrategies.Add(validarExCartao);
      cartaoStrategies.Add(validarCartaoPref);

    }
    public EntidadeDominio Cadastrar(EntidadeDominio entidade)
    {
      switch(entidade.GetType().Name)
      {
        case "Cliente":
          Cliente cliente = (Cliente)entidade;
          List<EntidadeDominio> validacoes = new List<EntidadeDominio>();
          List<string> errosValidacao = new List<string>();
          foreach(IStrategy strategy in cadastrarClienteStrategies)
          {
            validacoes.Add(strategy.Processar(cliente));
          }
          foreach(EntidadeDominio validacao in validacoes)
          {
            if(validacao.GetType() == typeof(Retorno))
            {
              Retorno erros = (Retorno)validacao;
              foreach(string erro in erros.retornoString)
              {
                errosValidacao.Add(erro);
              }
            }
          }
          if(errosValidacao.Count > 0)
          {
            Retorno retorno = new Retorno(errosValidacao);
            return retorno;
          }
          else
          {
            ClienteDal clienteDal = new ClienteDal();
            clienteDal.Cadastrar(cliente);
            return cliente;
          }

          default:
            return null;
      }
    }
    public List<EntidadeDominio> Listar()
    {
      ClienteDal clienteDal = new ClienteDal();
      List<EntidadeDominio> clientes = new List<EntidadeDominio>();
      clientes = clienteDal.Listar();
      return clientes;
    }
  }
}