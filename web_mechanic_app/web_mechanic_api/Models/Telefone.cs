namespace web_mechanic_api.Models
{
    public class Telefone : EntidadeDominio
    {
        public Telefone(){}
        public string tipo { get; set; }
        public string ddd { get; set; }
        public string numero { get; set; }
    }
}