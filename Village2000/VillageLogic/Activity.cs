using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageLogic
{
    public class Activity
    {
        public IList<Person> People { get; private set; }
        public ActivityType Type { get; private set; }
        public int Length { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public Activity(IList<Person> people, ActivityType type, int length)
        {
            People = people;
            Type = type;
            Length = length;
            StartTime = DateTime.Now;
        }
    }
}
