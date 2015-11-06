using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikken.Model;

namespace Nettbutikken.BLL
{
    public interface IOrdreLogikk
    {
        List<Kvitto> hentAlle();
        List<Kvitto> hentenOrdre(string bnavn);
    }
}
