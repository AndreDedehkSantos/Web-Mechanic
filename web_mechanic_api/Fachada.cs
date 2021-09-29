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
    List<IStrategy> alterarClienteStrategies = new List<IStrategy>();
    List<IStrategy> cadastrarEnderecoStrategies = new List<IStrategy>();
    List<IStrategy> cartaoStrategies = new List<IStrategy>();
    public Fachada()
    {
      
      ValidarDadosCliente validarDadosCliente = new ValidarDadosCliente();
      ValidarExistenciaCliente validarExCliente = new ValidarExistenciaCliente();
      ValidarTelefoneCliente validarTelefoneCliente = new ValidarTelefoneCliente();
      ValidarEndereco validarEndereco = new ValidarEndereco();
      ValidarSenhaCliente validarSenhaCliente = new ValidarSenhaCliente();
      CriptografarSenha criptSenha = new CriptografarSenha();
      cadastrarClienteStrategies.Add(validarDadosCliente);
      cadastrarClienteStrategies.Add(validarExCliente);
      cadastrarClienteStrategies.Add(validarTelefoneCliente);
      cadastrarClienteStrategies.Add(validarSenhaCliente);
      cadastrarClienteStrategies.Add(criptSenha);

      alterarClienteStrategies.Add(validarDadosCliente);
      alterarClienteStrategies.Add(validarTelefoneCliente);

      ValidarEnderecoCobEnt validarEndCobEnt = new ValidarEnderecoCobEnt();
      ValidarExistenciaEndereco validarExEndereco = new ValidarExistenciaEndereco();
      cadastrarEnderecoStrategies.Add(validarEndereco);
      cadastrarEnderecoStrategies.Add(validarEndCobEnt);
      cadastrarEnderecoStrategies.Add(validarExEndereco);

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
        List<EntidadeDominio> validacoes = new List<EntidadeDominio>();
        switch(entidade.GetType().Name)
        {
          case "Cliente":
            Cliente cliente = (Cliente)entidade;
            validacoes.Clear();
            Console.WriteLine("Aqui Fachada!");
            int i = 0;
            foreach(IStrategy strategy in cadastrarClienteStrategies)
            {
              EntidadeDominio validacao = strategy.Processar(cliente);
              i++;
              Console.WriteLine("Valida " + i);
              if(validacao.GetType() == typeof(Retorno))
              {
                return validacao;
              }
            }
            i = 0;
            foreach(IStrategy strategy in cadastrarEnderecoStrategies)
            {
              i++;
              Console.WriteLine("Valida " + i);
              EntidadeDominio validacao = strategy.Processar(cliente.enderecos[0]);
              if(validacao.GetType() == typeof(Retorno))
              {
                return validacao;
              }
            }
            ClienteDal clienteDal = new ClienteDal();
            clienteDal.Cadastrar(cliente);
            return cliente;

          case "Endereco": 
            Endereco endereco = (Endereco)entidade;
            validacoes.Clear();
            foreach(IStrategy strategy in cadastrarEnderecoStrategies)
            {
               EntidadeDominio validacao = strategy.Processar(endereco);
              if(validacao.GetType() == typeof(Retorno))
              {
                return validacao;
              }
            }
            return endereco;

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

    public List<EntidadeDominio> Pesquisar(string[] filtros)
    {
      ClienteDal clienteDal = new ClienteDal();
      List<EntidadeDominio> resultadoPesquisa = new List<EntidadeDominio>();
      resultadoPesquisa = clienteDal.Pesquisar(filtros);
      return resultadoPesquisa;
    }

    public EntidadeDominio Alterar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      List<EntidadeDominio> validacoes = new List<EntidadeDominio>();
      List<string> errosValidacao = new List<string>();
      foreach(IStrategy strategy in alterarClienteStrategies)
      {
        EntidadeDominio validacao = strategy.Processar(cliente);
        if(validacao.GetType() == typeof(Retorno))
        {
          return validacao;
        }
      } 
      ClienteDal clienteDal = new ClienteDal();
      Cliente clienteRetorno = new Cliente();
      clienteDal.Alterar(cliente);
      return cliente;
    }

    public EntidadeDominio AlterarSenha(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      List<EntidadeDominio> validacoes = new List<EntidadeDominio>();
      List<string> errosValidacao = new List<string>();
      ValidarSenhaCliente validarSenhaCliente = new ValidarSenhaCliente();
      EntidadeDominio validacao = validarSenhaCliente.Processar(cliente);
      if(validacao.GetType() == typeof(Retorno))
      {
        return validacao;
      }
      ClienteDal clienteDal = new ClienteDal();
      Cliente clienteRetorno = new Cliente();
      clienteDal.Alterar(cliente);
      return cliente;
    }
  }
}