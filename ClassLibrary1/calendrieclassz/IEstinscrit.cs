using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendrieclassz
{
    public interface IEstinscrit
    {
        bool suivre(Cours a);
        bool sinscrire(Cours a);
    }
}