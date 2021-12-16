using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entidades
{
    public class Projeto : BaseEntity
    {
        public Projeto(string titulo, string descricao, int clienteId, int freelancerId, decimal custoTotal)
        {
            Titulo = titulo;
            Descricao = descricao;
            ClienteId = clienteId;
            FreelancerId = freelancerId;
            CustoTotal = custoTotal;

            CriadoEm = DateTime.Now;
            Situacao = SituacaoProjetoEnum.Criado;
            Comentarios = new List<ComentarioProjeto>();
        }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public int ClienteId { get; private set; }

        public int FreelancerId { get; private set; }

        public decimal CustoTotal { get; set; }

        public DateTime CriadoEm { get; private set; }

        public DateTime? IniciadoEm { get; private set; }

        public DateTime? ConcluidoEm { get; private set; }

        public SituacaoProjetoEnum Situacao { get; private set; }

        public List<ComentarioProjeto> Comentarios { get; private set; }
    }
}
