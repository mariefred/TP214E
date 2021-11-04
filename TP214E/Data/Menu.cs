using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TP214E.Data
{
    public class Menu
    {
        [BsonId]
        private ObjectId id;

        [BsonElement ("choixPlats")]
        private List<Recette> choixPlats;

        [BsonElement ("choixBreuvage")]
        private List<Aliment> choixBreuvage;

        [BsonConstructor]
        public Menu(List<Recette> pListePlats, List<Aliment> pListeBreuvages)
        {
            choixPlats = pListePlats;
            choixBreuvage = pListeBreuvages;
        }

        public List<Recette> ChoixPlats
        {
            get { return choixPlats; }
            set { choixPlats = value; }
        }

        public List<Aliment> ChoixBreuvage
        {
            get { return choixBreuvage; }
            set { choixBreuvage = value; }
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
