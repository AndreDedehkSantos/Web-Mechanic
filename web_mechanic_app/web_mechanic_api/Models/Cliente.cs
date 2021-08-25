using System;
using System.Collections.Generic;

namespace web_mechanic_api.Models
{
    public class Cliente : EntidadeDominio
    {
        public Cliente(){}
        public string nome { get; set; }
        public string cpf { get; set; }
        public string genero { get; set; }
        public DateTime dataNascimento { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public List<Telefone> telefones { get; set; }
        public List<Endereco> enderecos { get; set; }
        public List<Cartao> cartoes { get; set; }
    }
}