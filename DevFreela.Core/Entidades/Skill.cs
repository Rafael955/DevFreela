using System;

namespace DevFreela.Core.Entidades
{
    public class Skill : BaseEntity
    {
        public Skill(string descricao)
        {
            Descricao = descricao;
            CriadoEm = DateTime.Now;
        }

        public string Descricao { get; private set; }

        public DateTime CriadoEm { get; private set; }
    }
}
