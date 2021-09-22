using System.Collections.Generic;
using System;
using System.Data;
using web_mechanic_api.Models;
using web_mechanic_api.Queries;
using MySql.Data.MySqlClient;
using web_mechanic_api.Strategies;

namespace web_mechanic_api.Dal
{
  public class ClienteDal : DalConnect, IDal
  {
    private MySqlConnection connection;
    public ClienteDal()
    {
      this.connection = Connect();
    }
    public EntidadeDominio Alterar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      var cmd = new MySqlCommand();
      try
      {
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = ClienteQueries.alterar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@id", cliente.id);
        cmd.Parameters.AddWithValue("@nome", cliente.nome);
        cmd.Parameters.AddWithValue("@dataNascimento", cliente.dataNascimento);
        cmd.Parameters.AddWithValue("@genero", cliente.genero);
        cmd.Parameters.AddWithValue("@cpf", cliente.cpf);
        cmd.Parameters.AddWithValue("@tipoTelefone", cliente.telefone.tipo);
        cmd.Parameters.AddWithValue("@dddTelefone", cliente.telefone.ddd);
        cmd.Parameters.AddWithValue("@numeroTelefone", cliente.telefone.numero);
        cmd.Parameters.AddWithValue("@email", cliente.email);
        cmd.Parameters.AddWithValue("@senha", cliente.senhas[0]);
        cmd.Parameters.AddWithValue("@ranking", cliente.ranking);
        if(cliente.status)
        {
          cmd.Parameters.AddWithValue("@status_cliente", 1);
        }
        else
        {
          cmd.Parameters.AddWithValue("@status_cliente", 0);
        }
        cmd.ExecuteNonQuery();
        return cliente;
      }
      catch(Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        if(connection.State == ConnectionState.Closed)
        {
          connection.Close();
        }
      }
    }

    public EntidadeDominio Cadastrar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      MySqlCommand cmd = new MySqlCommand();
      try
      {
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = ClienteQueries.cadastar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@nome", cliente.nome);
        cmd.Parameters.AddWithValue("@dataNascimento", cliente.dataNascimento);
        cmd.Parameters.AddWithValue("@genero", cliente.genero);
        cmd.Parameters.AddWithValue("@cpf", cliente.cpf);
        cmd.Parameters.AddWithValue("@tipoTelefone", cliente.telefone.tipo);
        cmd.Parameters.AddWithValue("@dddTelefone", cliente.telefone.ddd);
        cmd.Parameters.AddWithValue("@numeroTelefone", cliente.telefone.numero);
        cmd.Parameters.AddWithValue("@email", cliente.email);
        cmd.Parameters.AddWithValue("@senha", cliente.senhas[0]);
        cmd.Parameters.AddWithValue("@ranking", cliente.ranking);
        cmd.Parameters.AddWithValue("@status_cliente", 1);
        cliente.id = Convert.ToInt32(cmd.ExecuteScalar());
        cliente.enderecos[0].cliente_id = cliente.id;
        EnderecoDal enderecoDal = new EnderecoDal();
        enderecoDal.Cadastrar(cliente.enderecos[0]);
        return cliente;
      }
      catch(Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        connection.Close();
      }

    }

    public List<EntidadeDominio> Pesquisar(String[] filtros)
    {
      var cmd = new MySqlCommand();
      try
      {
        connection.Open();
        cmd.Connection = connection;
        string query = ClienteQueries.pesquisar_filtros;
        for(int i = 0; i < filtros.Length; i++)
        {
          query += filtros[i];
          if(i + 1 < filtros.Length)
          {
            query += " AND ";
          }
        }
        query += ");";
        cmd.CommandText = query;
        List<EntidadeDominio> clientes = new List<EntidadeDominio>();
        var resultado = cmd.ExecuteReader();
        while(resultado.Read())
        {
          Cliente cliente = new Cliente();
          Telefone telefone = new Telefone();
          cliente.id = Convert.ToInt32(resultado["id"]);
          cliente.nome = resultado["nome"].ToString();
          cliente.dataNascimento = resultado["dataNascimento"].ToString();
          cliente.genero = resultado["genero"].ToString();
          cliente.cpf = resultado["cpf"].ToString();
          telefone.id = 1;
          telefone.tipo = resultado["tipoTelefone"].ToString();
          telefone.ddd = resultado["dddTelefone"].ToString();
          telefone.numero = resultado["numeroTelefone"].ToString();
          cliente.email = resultado["email"].ToString();
          cliente.senhas.Add(resultado["senha"].ToString());
          cliente.ranking = Convert.ToInt32(resultado["ranking"]);
          if(Convert.ToInt32(resultado["status_cliente"]) == 1)
          {
            cliente.status = true;
          }
          else
          {
            cliente.status = false;
          }
          cliente.telefone = telefone;
          EnderecoDal enderecoDal = new EnderecoDal();
          string filtro1 = "cliente_id = " + cliente.id;
          string[] filtrosCliente = {filtro1};
          List<EntidadeDominio> enderecoEntidade = enderecoDal.Pesquisar(filtrosCliente);
          List<Endereco> enderecos = new List<Endereco>();
          foreach(EntidadeDominio endereco in enderecoEntidade)
          {
            enderecos.Add((Endereco)endereco);
          }
          CartaoDal cartaoDal = new CartaoDal();
          List<EntidadeDominio> cartaoEntidade = cartaoDal.Pesquisar(filtrosCliente);
          List<Cartao> cartoes = new List<Cartao>();
          foreach(EntidadeDominio cartao in cartaoEntidade)
          {
            cartoes.Add((Cartao)cartao);
          }
          cliente.enderecos = enderecos;
          cliente.cartoes = cartoes;
          
          clientes.Add(cliente);
        }
        return clientes;

      }
      catch(Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        connection.Close();
      }
    }
    
    public List<EntidadeDominio> Listar()
    {
      var cmd = new MySqlCommand();
      try
      {
        List<EntidadeDominio> clientes = new List<EntidadeDominio>();
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = ClienteQueries.listar;
        var resultado = cmd.ExecuteReader();
        while(resultado.Read())
        {
          Cliente cliente = new Cliente();
          Telefone telefone = new Telefone();
          cliente.id = Convert.ToInt32(resultado["id"]);
          cliente.nome = resultado["nome"].ToString();
          cliente.dataNascimento = resultado["dataNascimento"].ToString();
          cliente.genero = resultado["genero"].ToString();
          cliente.cpf = resultado["cpf"].ToString();
          telefone.tipo = resultado["tipoTelefone"].ToString();
          telefone.ddd = resultado["dddTelefone"].ToString();
          telefone.numero = resultado["numeroTelefone"].ToString();
          cliente.email = resultado["email"].ToString();
          cliente.senhas.Add(resultado["senha"].ToString());
          DescriptografarSenha descriptSenha = new DescriptografarSenha();
          cliente = (Cliente)descriptSenha.Processar(cliente);
          cliente.ranking = Convert.ToInt32(resultado["ranking"]);
          if(Convert.ToInt32(resultado["status_cliente"]) == 1)
          {
            cliente.status = true;
          }
          else
          {
            cliente.status = false;
          }
          cliente.telefone = telefone;
          EnderecoDal enderecoDal = new EnderecoDal();
          string filtro1 = "cliente_id = " + cliente.id;
          string[] filtros = {filtro1};
          List<EntidadeDominio> enderecoEntidade = enderecoDal.Pesquisar(filtros);
          List<Endereco> enderecos = new List<Endereco>();
          foreach(EntidadeDominio endereco in enderecoEntidade)
          {
            Endereco end = (Endereco)endereco;
            end.cliente_id = cliente.id;
            enderecos.Add((Endereco)end);
          }
          CartaoDal cartaoDal = new CartaoDal();
          List<EntidadeDominio> cartaoEntidade = cartaoDal.Pesquisar(filtros);
          List<Cartao> cartoes = new List<Cartao>();
          foreach(EntidadeDominio cartao in cartaoEntidade)
          {
            Cartao cart = (Cartao)cartao;
            cart.cliente_id = cliente.id;
            cartoes.Add((Cartao)cart);
          }
          cliente.enderecos = enderecos;
          cliente.cartoes = cartoes;
          
          clientes.Add(cliente);
        }
        return clientes;
      }
      catch(Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        connection.Close();
      }
    }
    public void Deletar(EntidadeDominio entidade)
    {
      throw new System.NotImplementedException();
    }

    public List<EntidadeDominio> Pesquisar(EntidadeDominio entidade)
    {
      throw new System.NotImplementedException();
    }

  }
}