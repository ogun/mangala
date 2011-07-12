using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangalaGameProject
{
    class Player
    {
        // Haznedeki taş sayısını tutar
        protected int Hazne { get; set; }


        private List<int> cukur = new List<int>(6);

        public List<int> Cukur
        {
            get { return cukur; }
            set { cukur = value; }
        }
    }
}
