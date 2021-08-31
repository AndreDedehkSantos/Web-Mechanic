namespace web_mechanic_api.Queries
{
    public class EnderecoQueries
    {
        public static readonly string cadastar = "INSERT INTO endereco(tipo, descricao, tipoLogradouro, logradouro, numero, complemento, bairro, cep, cobranca, entrega, cidade, estado, cliente_id)"
                                               + " VALUES(@tipo, @descricao, @tipoLogradouro, @logradouro, @numero, @complemento, @bairro, @cep, @cobranca, @entrega, @cidade, @estado, @cliente_id);";
        public static readonly string alterar = "UPDATE endereco SET tipo = @tipo, descricao = @descricao, tipoLogradouro = @tipoLogradouro, logradouro = @logradouro, numero = @numero,"
                                              + "complemento = @complemento, bairro = @bairro, cep = @cep, cobranca = @cobranca, entrega = @entrega, cidade = @cidade, estado = @estado "
                                              + "WHERE id = @id";
  
        public static readonly string pesquisar_filtros = "SELECT * FROM endereco WHERE (";
        public static readonly string deletar = "DELETE FROM endereco WHERE id = @id";
    }
}