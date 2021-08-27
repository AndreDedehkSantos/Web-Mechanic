namespace web_mechanic_api.Models
{
  public class Endereco : EntidadeDominio
  {
    public Endereco()
    {}
    public string tipo { get; set; }
    public string descricao { get; set; }
    public string tipoLogradouro { get; set; }
    public string logradouro { get; set; }
    public string numero { get; set; }
    public string complemento { get; set; }
    public string bairro { get; set; }
    public string cep { get; set; }
    public Cidade cidade { get; set; }
    public Estado estado { get; set; }
    public bool cobranca { get; set; }
    public bool entrega { get; set; }

  }
}