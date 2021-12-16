using System;

namespace DevFreela.Core.Entidades
{
    public class ComentarioProjeto : BaseEntity
    {
        public ComentarioProjeto(string conteudo, int projetoId, int usuarioId)
        {
            Conteudo = conteudo;
            ProjetoId = projetoId;
            UsuarioId = usuarioId;

            CriadoEm = DateTime.Now;
        }

        public string Conteudo { get; private set; }

        public int ProjetoId { get; private set; }

        public int UsuarioId { get; private set; }

        public DateTime CriadoEm { get; private set; }

    }
}
