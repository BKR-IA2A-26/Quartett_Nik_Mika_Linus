using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonQuartett
{
    public class Spieler
    {
        public string Name { get; set; }

        public List<Pokemon> Handstapel { get; set; } = new List<Pokemon>();
        public bool wähler { get; set; }
        public Spieler(String name)
        {
            Name = name;
        }
    }
}
