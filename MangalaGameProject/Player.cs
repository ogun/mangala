using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangalaGameProject
{
    class Player
    {
        private int hazne;  // Haznedeki taş sayısını tutar

        protected int Hazne
        {
            get { return hazne; }
            set { hazne = value; }
        }

        private List<int> cukur = new List<int>(6);

        public List<int> Cukur
        {
            get { return cukur; }
            set { cukur = value; }
        }

        public Player()
        {
        }
    }
}
