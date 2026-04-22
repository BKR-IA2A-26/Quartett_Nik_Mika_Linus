using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonQuartett
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Typ { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Aspeed { get; set; }

        public string BildPfad { get; set; }


        //Trennung von Logik und Design. Gibt Wert basierend auf einer Zahl zurück
        public int WertPerIndex(int index)
        {
            switch (index)
            {
                case 0: return HP;
                case 1: return Attack;
                case 2: return Defense;
                case 3: return Aspeed;
                default: return 0;
            }
        }
    }
}
