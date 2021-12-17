using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistencia
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto asp.net core 1", "teste",1,1,1500),
                new Project("Meu projeto asp.net core 2", "teste",1,1,4500),
                new Project("Meu projeto asp.net core 3", "teste",1,1,10000),
                new Project("Meu projeto asp.net core 4", "teste",1,1,8230),
            };

            Users = new List<User>
            {
                new User("Fulano da Silva", "fulano_da_silva@gmail.com",new DateTime(1985,9,10)),
                new User("Beltrano da Cunha", "beltrano111@gmail.com",new DateTime(1972,11,21)),
                new User("Ciclano Farias", "ciclano_fa@gmail.com",new DateTime(1991,6,16)),
                new User("John Doe", "johndoe@hotmail.com",new DateTime(1981,4,1)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }

        public List<Project> Projects { get; set; }

        public List<User> Users { get; set; }

        public List<Skill> Skills { get; set; }
        
        public List<ProjectComment> ProjectComments { get; set; }

    }
}
