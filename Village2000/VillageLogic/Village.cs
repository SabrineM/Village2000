using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageLogic
{
    public class Village
    {
        public IList<Person> Villagers { get; private set; } 

        public Village()
        {
            Villagers = new List<Person>();

            Villagers.Add(new Person
            {
                Name = "Indbygger 1"
            });

            Villagers.Add(new Person
            {
                Name = "Indbygger 2"
            });
        }
    }
}
