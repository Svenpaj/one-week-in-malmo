using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace one_week_in_malmo
{
    public class Quest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int Experience { get; set; } 

        public Quest(string name, string description, int experience)
        {
            Name = name;
            Description = description;
            Experience = experience;
            IsComplete = false;
        }

        public int Complete()
        {
            IsComplete = true;
            return Experience;
        }

    }
}