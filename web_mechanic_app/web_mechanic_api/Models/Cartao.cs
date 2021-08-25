using System;

namespace web_mechanic_api.Models
{
    public class Cartao : EntidadeDominio
    {
        public Cartao(){}
        public string tipo { get; set; }
        public string bandeira { get; set; }
        public string numero { get; set; }
        public string codigoVerificacao { get; set; }
        public DateTime dataValidade { get; set; }
        public string nomeImpresso { get; set; }
    }
}