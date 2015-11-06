using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikken.Model;
using Nettbutikken.DAL;

namespace Nettbutikken.BLL
{
    public class KundeBLL : IKundeLogikk
    {
        private IKundeRepository _repository;

        public KundeBLL()
        {
            _repository = new KundeRepository();
        }

        public KundeBLL(IKundeRepository stub)
        {
            _repository = stub;
        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            return _repository.endreKunde(id, innKunde); ;
        }

        public List<Kunde> hentAlle()
        {
            List<Kunde> allePersoner = _repository.hentAlle();
            return allePersoner;
        }

        public Kunde hentEnKunde(int id)
        {
            return _repository.hentEnKunde(id);
        }

        public byte[] lagHash(string Innpassord)
        {
            return _repository.lagHash(Innpassord);
        }

        public bool settInn(Kunde innKunde)
        {
            return _repository.settInn(innKunde);
        }

        public bool slettKunde(int id)
        {
            return _repository.slettKunde(id);
        }
    }
}
