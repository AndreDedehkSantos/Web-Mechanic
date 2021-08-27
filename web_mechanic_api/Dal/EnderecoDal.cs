using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using web_mechanic_api.Models;
using web_mechanic_api.Queries;

namespace web_mechanic_api.Dal
{
  public class EnderecoDal : DalConnect, IDal
  {
    private MySqlConnection connection;
    public EnderecoDal()
    {
      this.connection = Connect();
    }

    public void Alterar(EntidadeDominio entidade)
    {
      var connection = Connect();
      var cmd = new MySqlCommand();
      try
      {
        Endereco endereco = (Endereco)entidade;
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = EnderecoQueries.alterar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@tipo", endereco.tipo);
        cmd.Parameters.AddWithValue("@descricao", endereco.descricao);
        cmd.Parameters.AddWithValue("@tipoLogradouro", endereco.tipoLogradouro);
        cmd.Parameters.AddWithValue("@logradouro", endereco.logradouro);
        cmd.Parameters.AddWithValue("@numero", endereco.numero);
        if(endereco.complemento == null)
        {
          cmd.Parameters.AddWithValue("@complemento", "");
        }
        else
        {
          cmd.Parameters.AddWithValue("@complemento", endereco.complemento);
        }
        cmd.Parameters.AddWithValue("@bairro", endereco.bairro);
        cmd.Parameters.AddWithValue("@cep", endereco.cep);
        if(endereco.cobranca)
        {
          cmd.Parameters.AddWithValue("@cobranca", 1);
        }
        else
        {
          cmd.Parameters.AddWithValue("@cobranca", 0);
        }
        if(endereco.entrega)
        {
          cmd.Parameters.AddWithValue("@entrega", 1);
        }
        else
        {
          cmd.Parameters.AddWithValue("@entrega", 0);
        }
        cmd.ExecuteNonQuery();

      }
      catch(Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        if(connection.State == ConnectionState.Open)
        {
          connection.Close();
        }
      }
    }

    public void Cadastrar(EntidadeDominio entidade)
    {
      var connection = Connect();
      var cmd = new MySqlCommand();
      try
      {
        Cliente cliente = (Cliente)entidade;
        Endereco endereco = cliente.enderecos[0];
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = EnderecoQueries.cadastar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@tipo", endereco.tipo);
        cmd.Parameters.AddWithValue("@descricao", endereco.descricao);
        cmd.Parameters.AddWithValue("@tipoLogradouro", endereco.tipoLogradouro);
        cmd.Parameters.AddWithValue("@logradouro", endereco.logradouro);
        cmd.Parameters.AddWithValue("@numero", endereco.numero);
        if(endereco.complemento == null)
        {
          cmd.Parameters.AddWithValue("@complemento", "");
        }
        else
        {
          cmd.Parameters.AddWithValue("@complemento", endereco.complemento);
        }
        cmd.Parameters.AddWithValue("@bairro", endereco.bairro);
        cmd.Parameters.AddWithValue("@cep", endereco.cep);
        if(endereco.cobranca)
        {
          cmd.Parameters.AddWithValue("@cobranca", 1);
        }
        else
        {
          cmd.Parameters.AddWithValue("@cobranca", 0);
        }
        if(endereco.entrega)
        {
          cmd.Parameters.AddWithValue("@entrega", 1);
        }
        else
        {
          cmd.Parameters.AddWithValue("@entrega", 0);
        }
        cmd.Parameters.AddWithValue("@cliente_id", cliente.id);
        cmd.ExecuteNonQuery();
      }
      catch(Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        if(connection.State == ConnectionState.Open)
        {
          connection.Close();
        }
      }
    }

    public void Deletar(EntidadeDominio entidade)
    {
      var connection = Connect();
      var cmd = new MySqlCommand();
      try
      {
        Endereco endereco = (Endereco)entidade;
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = EnderecoQueries.deletar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@id", endereco.id);
        cmd.ExecuteNonQuery();
      } 
      catch(Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        if(connection.State == ConnectionState.Open)
        {
          connection.Close();
        }
      }
    }

    public List<EntidadeDominio> Listar()
    {
      throw new System.NotImplementedException();
    }

    public List<EntidadeDominio> Pesquisar(EntidadeDominio entidade, List<string> filtros)
    {
      var cmd = new MySqlCommand();
      try
      {
        Cliente cliente = (Cliente)entidade;
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = EnderecoQueries.pesquisar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@cliente_id", cliente.id);
        var resultado = cmd.ExecuteReader();
        List<EntidadeDominio> listaEndereco = new List<EntidadeDominio>();
        while(resultado.Read())
        {
          Endereco endereco = new Endereco();
          endereco.id = Convert.ToInt32(resultado["id"]);
          endereco.tipo = resultado["tipo"].ToString();
          endereco.descricao = resultado["descricao"].ToString();
          endereco.tipoLogradouro = resultado["tipoLogradouro"].ToString();
          endereco.logradouro = resultado["logradouro"].ToString();
          endereco.numero = resultado["numero"].ToString();
          endereco.complemento = resultado["complemento"].ToString();
          endereco.bairro = resultado["bairro"].ToString();
          endereco.cep = resultado["cep"].ToString();
          if(Convert.ToInt32(resultado["cobranca"]) == 1)
          {
             endereco.cobranca = true;
          }
          else
          {
            endereco.cobranca = false;
          }
          if(Convert.ToInt32(resultado["entrega"]) == 1)
          {
             endereco.entrega = true;
          }
          else
          {
            endereco.entrega = false;
          }
          Cidade cidade = new Cidade();
          cidade.descricao = resultado["cidade"].ToString();
          endereco.cidade = cidade;
          Estado estado = new Estado();
          estado.uf = resultado["estado"].ToString();
          endereco.estado = estado;
          listaEndereco.Add(endereco);
        }
        return listaEndereco;
      }
      catch(Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        if(connection.State == ConnectionState.Open)
        {
          connection.Close();
        }
      }
    }
  }
}