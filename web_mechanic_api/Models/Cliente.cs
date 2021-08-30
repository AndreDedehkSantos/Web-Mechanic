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
        public string dataNascimento { get; set; }
        public string email { get; set; }
        public List<string> senhas = new List<string>();
        public Telefone telefone { get; set; }
        public List<Endereco> enderecos { get; set; }
        public List<Cartao> cartoes { get; set; }
        public int ranking { get; set; }
        public bool status { get; set; }
    }
}