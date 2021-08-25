using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using web_mechanic_api.Models;
using web_mechanic_api.Queries;

namespace web_mechanic_api.Dal
{
  public class CartaoDal: DalConnect, IDal
  {
    private MySqlConnection connection;
    public CartaoDal()
    {
      this.connection = Connect();
    }

    public void Cadastrar(EntidadeDominio entidade)
    {
      var connection = Connect();
      var cmd = new MySqlCommand();
      try
      {
        Cliente cliente = (Cliente)entidade;
        Cartao cartao = cliente.cartoes[0];
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = CartaoQueries.cadastrar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@tipo", cartao.tipo);
        cmd.Parameters.AddWithValue("@bandeira", cartao.bandeira);
        cmd.Parameters.AddWithValue("@numero", cartao.numero);
        cmd.Parameters.AddWithValue("@dataValidade", cartao.dataValidade);
        cmd.Parameters.AddWithValue("@codigoVerificacao", cartao.codigoVerificacao);
        cmd.Parameters.AddWithValue("@nomeImpresso", cartao.nomeImpresso);
        if (cartao.preferencial)
        {
          cmd.Parameters.AddWithValue("@preferencial", 1);
        }
        else
        {
          cmd.Parameters.AddWithValue("@preferencial", 0);
        }
        cmd.ExecuteNonQuery();

      }
      catch (Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
        {
          connection.Close();
        }
      }
    }

    public void Alterar(EntidadeDominio entidade)
    {
      throw new System.NotImplementedException();
    }

    public void Deletar(EntidadeDominio entidade)
    {
      var connection = Connect();
      var cmd = new MySqlCommand();
      try
      {
        Cartao cartao = (Cartao)entidade;
        connection.Open();
        cmd.Connection = connection;
        cmd.CommandText = CartaoQueries.deletar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@id", cartao.id);
        cmd.ExecuteNonQuery();
      }
      catch (Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
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
        cmd.CommandText = CartaoQueries.pesquisar;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@cliente_id", cliente.id);
        var resultado = cmd.ExecuteReader();
        List<EntidadeDominio> listaCartao = new List<EntidadeDominio>();
        while (resultado.Read())
        {
          Cartao cartao = new Cartao();
          cartao.id = Convert.ToInt32(resultado["id"]);
          cartao.bandeira = resultado["bandeira"].ToString();
          cartao.tipo = resultado["tipo"].ToString();
          cartao.numero = resultado["numero"].ToString();
          cartao.dataValidade = Convert.ToDateTime(resultado["dataValidade"]);
          cartao.codigoVerificacao = resultado["codigoVerificacao"].ToString();
          cartao.nomeImpresso = resultado["nomeImpresso"].ToString();
          if (Convert.ToInt32(resultado["preferencial"]) == 1)
          {
            cartao.preferencial = true;
          }
          else
          {
            cartao.preferencial = false;
          }
          listaCartao.Add(cartao);
        }
        return listaCartao;
      }
      catch (Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        if (connection.State == ConnectionState.Open)
        {
          connection.Close();
        }
      }
    }
  }
}