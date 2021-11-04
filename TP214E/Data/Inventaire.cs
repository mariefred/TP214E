using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Inventaire
    {
        private List<Aliment> listeAliments;

        public List<Aliment> ListeAliments
        {
            get { return listeAliments; }
            set { listeAliments = value; }
        }

        public Inventaire()
        {
            listeAliments = new List<Aliment>();
        }
    }
}
