using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Menu
    {
        private List<Recette> choixPlats { get; set; }
        private List<Aliment> choixBreuvage { get; set; }

        public Menu(List<Recette> pListePlats, List<Aliment> pListeBreuvages)
        {
            choixPlats = pListePlats;
            choixBreuvage = pListeBreuvages;
        }

        public void AjouterPlatAuMenu(Recette pRecette)
        {
            choixPlats.Add(pRecette);
        }

        public void RetirerPlatAuMenu(Recette pRecette)
        {
            choixPlats.Remove(pRecette);
        }

        public void AjouterBreuvageAuMenu(Aliment pBreuvage)
        {
            choixBreuvage.Add(pBreuvage);
        }

        public void RetirerBreuvageAuMenu(Aliment pBreuvage)
        {
            choixBreuvage.Remove(pBreuvage);
        }
    }
}
