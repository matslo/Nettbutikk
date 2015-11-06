using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikken.Model;

namespace Nettbutikken.DAL
{
    public class OrdreRepositoryStub : IOrdreRepository
    {
        public List<Kvitto> hentAlle()
        {
            var ordreliste = new List<Kvitto>();
            var ordre = new Kvitto()
            {
                Brukernavn = "PerPer",
                OrdreId = 1,
                OrdreDato = new DateTime(2015, 6, 10, 15, 24, 16),
                Varenavn = "Kaffemaskin",
                Antall = 2,
                Total = 100
            };
            ordreliste.Add(ordre);
            ordreliste.Add(ordre);
            ordreliste.Add(ordre);
            return ordreliste;

        }
        public List<Kvitto> hentenOrdre(string b)
        {
            var ordreliste = new List<Kvitto>();
            if (b == "")
            {
                var ordre = new Kvitto();
                ordre.Brukernavn = "";
                ordreliste.Add(ordre);
            }
            else
            {
                var ordrer = new Kvitto()
                {
                    Brukernavn = "PerPer",
                    OrdreId = 1,
                    OrdreDato = new DateTime(2015, 6, 10, 15, 24, 16),
                    Varenavn = "Kaffemaskin",
                    Antall = 2,
                    Total = 100
                };
                ordreliste.Add(ordrer);
            }
            return ordreliste;
        }
    }
}
