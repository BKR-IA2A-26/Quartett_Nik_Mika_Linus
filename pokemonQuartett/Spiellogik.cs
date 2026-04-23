using System;
using System.Collections.Generic;
using System.Linq;

namespace pokemonQuartett
{
    public class Spiellogik
    {

        public Spieler Spieler1 { get; set; }
        public Spieler Spieler2 { get; set; }

        public Spiellogik(List<Pokemon> alleKarten)
        {

            Spieler1 = new Spieler("Spieler 1");
            Spieler2 = new Spieler("Spieler 2");


            Spieler1.wähler = true;
            Spieler2.wähler = false;

            MischeUndVerteile(alleKarten);
        }

        private void MischeUndVerteile(List<Pokemon> karten)
        {
            Random rnd = new Random();
            var gemischt = karten.OrderBy(x => rnd.Next()).ToList();

            for (int i = 0; i < gemischt.Count; i++)
            {

                if (i % 2 == 0)
                {
                    Spieler1.Handstapel.Add(gemischt[i]);
                }
                else
                {
                    Spieler2.Handstapel.Add(gemischt[i]);
                }
            }
        }

        public string Kampf(int KategorieIndex)
        {

            if (Spieler1.Handstapel.Count == 0 || Spieler2.Handstapel.Count == 0)
            {
                return "Spiel beendet!";
            }

            Pokemon p1 = Spieler1.Handstapel[0];
            Pokemon p2 = Spieler2.Handstapel[0];


            int wert1 = p1.WertPerIndex(KategorieIndex);
            int wert2 = p2.WertPerIndex(KategorieIndex);

            Spieler1.Handstapel.RemoveAt(0);
            Spieler2.Handstapel.RemoveAt(0);

            if (wert1 > wert2)
            {

                Spieler1.Handstapel.Add(p1);
                Spieler1.Handstapel.Add(p2);
                Spieler1.wähler = true;
                Spieler2.wähler = false;
                return $"{Spieler1.Name} gewinnt die Runde! {p1.Name} ({wert1}) schlägt {p2.Name} ({wert2}).";
            }
            else if (wert2 > wert1)
            {
                Spieler2.Handstapel.Add(p2);
                Spieler2.Handstapel.Add(p1);
                Spieler1.wähler = false;
                Spieler2.wähler = true;
                return $"{Spieler2.Name} gewinnt die Runde! {p2.Name} ({wert2}) schlägt {p1.Name} ({wert1}).";
            }
            else
            {
                Spieler1.Handstapel.Add(p1);
                Spieler2.Handstapel.Add(p2);
                return "Unentschieden! Jeder behält seine Karte.";
            }
        }
    }
}