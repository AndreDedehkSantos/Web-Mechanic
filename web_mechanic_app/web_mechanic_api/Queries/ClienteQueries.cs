namespace web_mechanic_api.Queries
{
    public class ClienteQueries
    {
        public static readonly string cadastar = "INSERT INTO cliente(nome, dataNascimento, genero, cpf, tipoTelfone, dddTelefone, numeroTelefone, email, senha, status) "
                                               + "VALUES(@nome, @dataNascimento, @genero, @cpf, @tipoTelfone, @dddTelefone, @numeroTelefone, @email, @senha, 1); SELECT last_insert_id";
        public static readonly string alterar = "UPADATE cliente SET nome = @nome, dataNascimento = @dataNascimento, genero = @genero, cpf = @cpf, tipoTelefone = @tipoTelefone, dddTelefone = @ddd, " 
                                              + "numeroTelefone = @numeroTelefone, email = @email, senha = @senha, status_cliente = @status WHERE id = @id";
        public static readonly string listar = "SELECT * FROM cliente";
        public static readonly string pesquisar = "SELECT * FROM cliente WHERE(";
    }
}