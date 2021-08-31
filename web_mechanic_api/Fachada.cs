using System;
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
      CriptografarSenha criptSenha = new CriptografarSenha();
      cadastrarClienteStrategies.Add(validardadosCliente);
      cadastrarClienteStrategies.Add(validarExCliente);
      cadastrarClienteStrategies.Add(validarTelefoneCliente);
      cadastrarClienteStrategies.Add(validarEndereco);
      cadastrarClienteStrategies.Add(validarSenhaCliente);
      cadastrarClienteStrategies.Add(criptSenha);

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
      try
      {
        switch(entidade.GetType().Name)
        {
          case "Cliente":
            Cliente cliente = (Cliente)entidade;
            List<EntidadeDominio> validacoes = new List<EntidadeDominio>();
            List<string> errosValidacao = new List<string>();
            int i = 1;
            foreach(IStrategy strategy in cadastrarClienteStrategies)
            {
              Console.WriteLine("Valida " + i);
              EntidadeDominio validacao = strategy.Processar(cliente);
              if(validacao.GetType() == typeof(Retorno))
              {
                return validacao;
              }
              i++;
            } 
            ClienteDal clienteDal = new ClienteDal();
            Cliente clienteRetorno = new Cliente();
            clienteDal.Cadastrar(cliente);
            return cliente;
            
          default:
            return null;
        }
      }
      catch(Exception excessao)
      {
        throw excessao;
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