using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace pokemonQuartett
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Spiellogik spiel;
        public MainWindow()
        {
            InitializeComponent();

            List<Pokemon> startKarten = ErstellePokemonListe();
            spiel = new Spiellogik(startKarten);

            AktualisiereAnzeige();
            
        }
        private void AktualisiereAnzeige() 
        {
            Spieler amZug = spiel.Spieler1.wähler ? spiel.Spieler1 : spiel.Spieler2; //Gucken wer dran ist

            if (amZug.Handstapel.Count > 0)
            {
                Pokemon aktuelle = amZug.Handstapel[0];

                AktuellerSpielerText.Text = amZug.Name; //Zeigt ob Spieler 1 oder 2
                PlayerNameText.Text = aktuelle.Name;    
                PlayerTypText.Text = "Typ: " + aktuelle.Typ;
                PlayerHPText.Text = "HP: " + aktuelle.HP;
                PlayerAttackText.Text = "Angriff: " + aktuelle.Attack;
                PlayerDefenseText.Text = "Abwehr: " + aktuelle.Defense;
                PlayerAspeedText.Text = "Speed: " + aktuelle.Aspeed;

                //KartenZähler
                Spieler1KartenZaehler.Text = spiel.Spieler1.Handstapel.Count + " Karten";
                Spieler2KartenZaehler.Text = spiel.Spieler2.Handstapel.Count + " Karten";

                //Bilder wenn kein Bild = nichts
                string ordnerPfad = @"C:\Users\Nik Steuernagel\Desktop\IA2A Schule\Software\pokemonQuartett\pokemonQuartett\Images\";
                string vollerPfad = ordnerPfad + aktuelle.BildPfad;

                if (System.IO.File.Exists(vollerPfad))
                {
                    PokemonBild.Source = new BitmapImage(new Uri(vollerPfad));
                }
                else
                {
                    PokemonBild.Source = null;
                }

            }
        }

        private void BtnKategorie_Click(object sender, RoutedEventArgs e)
        {
            Button geklickterButton = (Button)sender; 
            int wahlIndex = -1;

            //Werte => Index (Passend zur WertPerIndex)
            if (geklickterButton.Name == "BtnHP") wahlIndex = 0;  
            else if (geklickterButton.Name == "BtnAttack") wahlIndex= 1;
            else if (geklickterButton.Name == "BtnDefense") wahlIndex = 2;
            else if (geklickterButton.Name == "BtnAspeed") wahlIndex = 3;

            string ergebnisText = spiel.Kampf(wahlIndex);
            MessageBox.Show(ergebnisText);

            if(spiel.Spieler1.Handstapel.Count == 0 || spiel.Spieler2.Handstapel.Count == 0)
            {
                string gewinner = spiel.Spieler1.Handstapel.Count > 0 ? "Spieler 1" : "Spieler 2";
                WinText.Text = gewinner + " Gewinnt!🏆";
                WinScreen.Visibility = Visibility.Visible;
            }else 
            {
                AktualisiereAnzeige();
            }
        }
        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            List<Pokemon> frischeKarten = ErstellePokemonListe();

            spiel = new Spiellogik(frischeKarten);


            WinScreen.Visibility = Visibility.Collapsed;
            AktualisiereAnzeige();
        }
        private List<Pokemon> ErstellePokemonListe()
        {
            List<Pokemon> liste = new List<Pokemon>();
            // Gen 1: Kanto
            liste.Add(new Pokemon { Name = "Bisasam", Typ = "Pflanze", HP = 45, Attack = 49, Defense = 49, Aspeed = 45, BildPfad = "bisasam.png" });
            liste.Add(new Pokemon { Name = "Glumanda", Typ = "Feuer", HP = 39, Attack = 52, Defense = 43, Aspeed = 65, BildPfad = "glumanda.png" });
            liste.Add(new Pokemon { Name = "Schiggy", Typ = "Wasser", HP = 44, Attack = 48, Defense = 65, Aspeed = 43, BildPfad = "schiggy.png" });

            // Gen 2: Johto
            liste.Add(new Pokemon { Name = "Endivie", Typ = "Pflanze", HP = 45, Attack = 49, Defense = 65, Aspeed = 45, BildPfad = "endivie.png" });
            liste.Add(new Pokemon { Name = "Feurigel", Typ = "Feuer", HP = 39, Attack = 52, Defense = 43, Aspeed = 65, BildPfad = "feurigel.png" });
            liste.Add(new Pokemon { Name = "Karnimani", Typ = "Wasser", HP = 50, Attack = 65, Defense = 64, Aspeed = 43, BildPfad = "karnimani.png" });

            // Gen 3: Hoenn
            liste.Add(new Pokemon { Name = "Geckarbor", Typ = "Pflanze", HP = 40, Attack = 45, Defense = 35, Aspeed = 70, BildPfad = "geckarbor.png" });
            liste.Add(new Pokemon { Name = "Flemmli", Typ = "Feuer", HP = 45, Attack = 60, Defense = 40, Aspeed = 45, BildPfad = "flemmli.png" });
            liste.Add(new Pokemon { Name = "Hydropi", Typ = "Wasser", HP = 50, Attack = 70, Defense = 50, Aspeed = 40, BildPfad = "hydropi.png" });

            // Gen 4: Sinnoh
            liste.Add(new Pokemon { Name = "Chelast", Typ = "Pflanze", HP = 55, Attack = 68, Defense = 64, Aspeed = 31, BildPfad = "chelast.png" });
            liste.Add(new Pokemon { Name = "Panflam", Typ = "Feuer", HP = 44, Attack = 58, Defense = 44, Aspeed = 61, BildPfad = "panflam.png" });
            liste.Add(new Pokemon { Name = "Plinfa", Typ = "Wasser", HP = 53, Attack = 51, Defense = 53, Aspeed = 40, BildPfad = "plinfa.png" });

            // Gen 5: Einall
            liste.Add(new Pokemon { Name = "Serpifeu", Typ = "Pflanze", HP = 45, Attack = 45, Defense = 55, Aspeed = 63, BildPfad = "serpifeu.png" });
            liste.Add(new Pokemon { Name = "Floink", Typ = "Feuer", HP = 65, Attack = 63, Defense = 45, Aspeed = 45, BildPfad = "floink.png" });
            liste.Add(new Pokemon { Name = "Ottaro", Typ = "Wasser", HP = 55, Attack = 55, Defense = 45, Aspeed = 45, BildPfad = "ottaro.png" });

            // Gen 6: Kalos
            liste.Add(new Pokemon { Name = "Igamaro", Typ = "Pflanze", HP = 56, Attack = 61, Defense = 65, Aspeed = 38, BildPfad = "igamaro.png" });
            liste.Add(new Pokemon { Name = "Fynx", Typ = "Feuer", HP = 40, Attack = 45, Defense = 40, Aspeed = 60, BildPfad = "fynx.png" });
            liste.Add(new Pokemon { Name = "Froxy", Typ = "Wasser", HP = 41, Attack = 56, Defense = 40, Aspeed = 71, BildPfad = "froxy.png" });

            // Gen 7: Alola
            liste.Add(new Pokemon { Name = "Bauz", Typ = "Pflanze", HP = 68, Attack = 55, Defense = 55, Aspeed = 42, BildPfad = "bauz.png" });
            liste.Add(new Pokemon { Name = "Flamiau", Typ = "Feuer", HP = 45, Attack = 65, Defense = 40, Aspeed = 70, BildPfad = "flamiau.png" });
            liste.Add(new Pokemon { Name = "Robball", Typ = "Wasser", HP = 50, Attack = 54, Defense = 54, Aspeed = 40, BildPfad = "robball.png" });

            // Gen 8: Galar
            liste.Add(new Pokemon { Name = "Chimpep", Typ = "Pflanze", HP = 50, Attack = 65, Defense = 50, Aspeed = 65, BildPfad = "chimpep.png" });
            liste.Add(new Pokemon { Name = "Hopplo", Typ = "Feuer", HP = 50, Attack = 71, Defense = 40, Aspeed = 69, BildPfad = "hopplo.png" });
            liste.Add(new Pokemon { Name = "Memmeon", Typ = "Wasser", HP = 50, Attack = 40, Defense = 40, Aspeed = 70, BildPfad = "memmeon.png" });

            // Gen 9: Paldea
            liste.Add(new Pokemon { Name = "Felori", Typ = "Pflanze", HP = 40, Attack = 61, Defense = 54, Aspeed = 65, BildPfad = "felori.png" });
            liste.Add(new Pokemon { Name = "Krokel", Typ = "Feuer", HP = 67, Attack = 45, Defense = 59, Aspeed = 36, BildPfad = "krokel.png" });
            liste.Add(new Pokemon { Name = "Kwaks", Typ = "Wasser", HP = 55, Attack = 65, Defense = 45, Aspeed = 50, BildPfad = "kwaks.png" });

            // --- Die 5 Legendären (Nr. 28 bis 32) ---
            liste.Add(new Pokemon { Name = "Mewtu", Typ = "Psycho", HP = 106, Attack = 110, Defense = 90, Aspeed = 130, BildPfad = "mewtu.png" });
            liste.Add(new Pokemon { Name = "Groudon", Typ = "Psycho/Flug", HP = 106, Attack = 90, Defense = 130, Aspeed = 110, BildPfad = "groudon.png" });
            liste.Add(new Pokemon { Name = "Kyogre", Typ = "Wasser", HP = 100, Attack = 100, Defense = 90, Aspeed = 90, BildPfad = "kyogre.png" });
            liste.Add(new Pokemon { Name = "Pikachu", Typ = "Drache/Flug", HP = 60, Attack = 70, Defense = 40, Aspeed = 65, BildPfad = "pikachu.png" });
            liste.Add(new Pokemon { Name = "Letarking", Typ = "Normal", HP = 120, Attack = 120, Defense = 120, Aspeed = 10, BildPfad = "letarking.png" }); 
       
            return liste;
        }
    }
    }
