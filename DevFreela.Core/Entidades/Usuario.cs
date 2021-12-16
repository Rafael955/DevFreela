using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entidades
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nomeCompleto, string email, DateTime dataNascimento)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            CriadoEm = DateTime.Now;
            Ativo = true;

            Skills = new List<UsuarioSkill>();
            ProjetosPessoais = new List<Projeto>();
            ProjetosFreelance = new List<Projeto>();
        }

        public string NomeCompleto { get; private set; }

        public string Email { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public DateTime CriadoEm { get; private set; }

        public bool Ativo { get; private set; }

        public List<UsuarioSkill> Skills { get; private set; }

        public List<Projeto> ProjetosPessoais { get; private set; }

        public List<Projeto> ProjetosFreelance { get; private set; }
    }
}
