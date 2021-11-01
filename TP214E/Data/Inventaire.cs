using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    class Inventaire
    {
        List<Aliment> listeAliments { get; set; }

        public Inventaire()
        {
            listeAliments = new List<Aliment>();
        }

       
    }
}
