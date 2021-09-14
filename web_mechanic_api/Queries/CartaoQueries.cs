namespace web_mechanic_api.Queries
{
    public class CartaoQueries
    {
        public static readonly string cadastrar = "INSERT INTO cartao(bandeira, tipo, numero, dataValidade, codigoVerificacao, nomeImpresso, preferencial, cliente_id) "
                                                + "VALUES(@bandeira, @tipo, @numero, @dataValidade, @codigoVerificacao, @nomeImpreso, @preferencial, @cliente_id)";
        public static readonly string pesquisar_filtros = "SELECT * FROM cartao WHERE (";
        public static readonly string deletar = "DELETE FROM cartao WHERE id = @id";
    }
}