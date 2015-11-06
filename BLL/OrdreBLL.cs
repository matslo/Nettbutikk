using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikken.Model;
using Nettbutikken.DAL;

namespace Nettbutikken.BLL
{
    public class OrdreBLL : IOrdreLogikk
    {
        private IOrdreRepository _repository;

        public OrdreBLL()
        {
            _repository = new OrdreRepository();
        }

        public OrdreBLL(IOrdreRepository stub)
        {
            _repository = stub;
        }

        public List<Kvitto> hentAlle()
        {
            List<Kvitto> alleOrdre = _repository.hentAlle();
            return alleOrdre;
        }

        public List<Kvitto> hentenOrdre(string bnavn)
        {
            return _repository.hentenOrdre(bnavn);
        }

       
    }
}
