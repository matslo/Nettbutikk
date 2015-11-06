using Nettbutikken.Model;
using System;
using System.Collections.Generic;

namespace Nettbutikken.DAL
{
    public interface IKundeRepository
    {
        bool endreKunde(int id, Kunde innKunde);
        List<Kunde> hentAlle();
        Kunde hentEnKunde(int id);
        bool settInn(Kunde innKunde);
        bool slettKunde(int id);
        Byte[] lagHash(string Innpassord);
    }
}
