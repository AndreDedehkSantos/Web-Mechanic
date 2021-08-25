namespace web_mechanic_api.Queries
{
    public class ClienteQueries
    {
        public static readonly string cadastar = "INSERT INTO cliente(nome, dataNascimento, genero, cpf, email, senha) VALUES(@nome, @dataNascimento, @genero, @cpf, @email, @senha)";

    }
}