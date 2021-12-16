namespace DevFreela.Core.Entidades
{
    public class UsuarioSkill : BaseEntity
    {
        public UsuarioSkill(int usuarioId, int skillId)
        {
            UsuarioId = usuarioId;
            SkillId = skillId;
        }

        public int UsuarioId { get; private set; }

        public int SkillId { get; private set; }
    }
}
