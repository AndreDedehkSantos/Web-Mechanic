using System.Collections.Generic;
using System;
using System.Data;
using web_mechanic_api.Models;
using MySqlConnector;
using web_mechanic_api.Queries;

namespace web_mechanic_api.Dal
{
  public class ClienteDal : DalConnect, IDal
  {

    public ClienteDal()
    {}
    public void Alterar(EntidadeDominio entidade)
    {
      throw new System.NotImplementedException();
    }

    public void Cadastrar(EntidadeDominio entidade)
    {
      Cliente cliente = (Cliente)entidade;
      var connection = Connect();
      var cmd = new MySqlCommand();
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
        cmd.Parameters.AddWithValue("@email", cliente.email);
        cmd.Parameters.AddWithValue("@senha", cliente.senha);
        cliente.id = Convert.ToInt32(cmd.ExecuteScalar());

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
      throw new System.NotImplementedException();
    }

    public List<EntidadeDominio> Listar(EntidadeDominio entidade)
    {
      throw new System.NotImplementedException();
    }

    public List<EntidadeDominio> Procurar(EntidadeDominio entidade, List<string> filtros)
    {
      throw new System.NotImplementedException();
    }
  }
}