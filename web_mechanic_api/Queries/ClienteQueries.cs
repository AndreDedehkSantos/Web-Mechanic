namespace web_mechanic_api.Queries
{
    public class ClienteQueries
    {
        public static readonly string cadastar = "INSERT INTO cliente(nome, dataNascimento, genero, cpf, tipoTelefone, dddTelefone, numeroTelefone, email, senha, ranking, status_cliente) "
                                               + "VALUES(@nome, @dataNascimento, @genero, @cpf, @tipoTelefone, @dddTelefone, @numeroTelefone, @email, @senha, @ranking, @status_cliente); SELECT LAST_INSERT_ID();";
        public static readonly string alterar = "UPDATE cliente SET nome = @nome, dataNascimento = @dataNascimento, genero = @genero, cpf = @cpf, tipoTelefone = @tipoTelefone, dddTelefone = @dddTelefone, " 
                                              + "numeroTelefone = @numeroTelefone, email = @email, senha = @senha, ranking = @ranking, status_cliente = @status_cliente WHERE id = @id";
        public static readonly string listar = "SELECT * FROM cliente";
        public static readonly string pesquisar_filtros = "SELECT * FROM cliente WHERE (";
    }
}