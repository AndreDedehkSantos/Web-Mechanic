using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
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

    public EntidadeDominio Cadastrar(EntidadeDominio entidade)
    {
      var connection = Connect();
      var cmd = new MySqlCommand();
      try
      {
        Cartao cartao = (Cartao)entidade;
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
        cmd.Parameters.AddWithValue("@cliente_id", cartao.cliente_id);
        cmd.ExecuteNonQuery();
        return cartao;

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
        connection.Close();
      }
      catch (Exception excessao)
      {
        throw excessao;
      }
      finally
      {
        connection.Close();
      }
    }


    public List<EntidadeDominio> Pesquisar(string[] filtros)
    {
      var cmd = new MySqlCommand();
      try
      {
        connection.Open();
        cmd.Connection = connection;
        string query = CartaoQueries.pesquisar_filtros;
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
        var resultado = cmd.ExecuteReader();
        List<EntidadeDominio> cartoes = new List<EntidadeDominio>();
        while (resultado.Read())
        {
          Cartao cartao = new Cartao();
          cartao.id = Convert.ToInt32(resultado["id"]);
          cartao.bandeira = resultado["bandeira"].ToString();
          cartao.tipo = resultado["tipo"].ToString();
          cartao.numero = resultado["numero"].ToString();
          cartao.dataValidade = resultado["dataValidade"].ToString();
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
          cartoes.Add(cartao);
        }
        connection.Close();
        return cartoes;
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
    public EntidadeDominio Alterar(EntidadeDominio entidade)
    {
      throw new System.NotImplementedException();
    }

    public List<EntidadeDominio> Listar()
    {
      throw new System.NotImplementedException();
    }
  }
}