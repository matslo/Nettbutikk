using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikken.Model;

namespace Nettbutikken.BLL
{
    public interface IKundeLogikk
    {
        bool endreKunde(int id, Kunde innKunde);
        List<Kunde> hentAlle();
        Kunde hentEnKunde(int id);
        bool settInn(Kunde innKunde);
        bool slettKunde(int id);
        Byte[] lagHash(string Innpassord);
    }
}
