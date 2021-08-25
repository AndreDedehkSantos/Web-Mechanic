namespace web_mechanic_api.Queries
{
    public class CartaoQueries
    {
        public static readonly string cadastrar = "INSERT INTO cartao(bandeira, tipo, numero, dataValidade, codigoVerificacao, nomeImpresso, preferencial) "
                                                + "VALUES(@bandeira, @tipo, @numero, @dataValidade, @codigoVerificacao, @nomeImpreso, @preferencial)";
        public static readonly string pesquisar = "SELECT * FROM cartao WHERE cliente_id = @cliente_id";
        public static readonly string deletar = "DELETE FROM cartao WHERE id = @id";
    }
}