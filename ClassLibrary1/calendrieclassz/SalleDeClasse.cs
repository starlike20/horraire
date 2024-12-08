using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendrieclassz
{
    public class SalleDeClasse
    {
        public int ID_SalleDeClasse { get; set; }
        public string NomSalle { get; set; }
        public int Capacité { get; set; }

        public SalleDeClasse(int iD_SalleDeClasse, string nomSalle, int capacité)
        {
            ID_SalleDeClasse = iD_SalleDeClasse;
            NomSalle = nomSalle;
            Capacité = capacité;
        }

        public SalleDeClasse() : this(0, "rien", 0) { }

        public override string ToString()
        {
            return "ID_SalleDeClasse=" + ID_SalleDeClasse + "NomSalle=" + NomSalle + "Capacité=" + Capacité;
        }

    }
}