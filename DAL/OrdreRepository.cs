using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikken.Model;

namespace Nettbutikken.DAL
{
    public class OrdreRepository : IOrdreRepository
    {
        public List<Kvitto> hentAlle()
        {
            var db = new Dbcontext();
            //Skriver ut alle bestillinger for brukeren som er innlogget. Bruker brukernavnet fra session ved innlogging
            var bestillinger = (from odetaljer in db.OrdreDetaljers
                                from ord in db.Ordrer
                                from v in db.Varer
                                from b in db.dbBrukere
                                where odetaljer.OrdreId == ord.OrdreId && odetaljer.VareId == v.VareId && odetaljer.Ordre.Brukernavn == b.Brukernavn
                                select new Kvitto
                                {
                                    Brukernavn = odetaljer.Ordre.Brukernavn,
                                    OrdreId = odetaljer.Ordre.OrdreId,
                                    Antall = odetaljer.Antall,
                                    OrdreDato = odetaljer.Ordre.OrdreDato,
                                    Varenavn = odetaljer.Vare.Varenavn,
                                    Total = odetaljer.Ordre.Total

                                }).ToList();
            return bestillinger;
        }
        
        public List<Kvitto> hentenOrdre(string bnavn)
        {
            var db = new Dbcontext();
            var brukernavn = bnavn;
            string b = Convert.ToString(brukernavn);
            //Skriver ut alle bestillinger for brukeren som er innlogget. Bruker brukernavnet fra session ved innlogging
            var bestillinger = (from odetaljer in db.OrdreDetaljers
                                from ord in db.Ordrer
                                from v in db.Varer
                                where odetaljer.OrdreId == ord.OrdreId && odetaljer.VareId == v.VareId && odetaljer.Ordre.Brukernavn == b
                                select new Kvitto
                                {
                                    Brukernavn = b,
                                    OrdreId = odetaljer.Ordre.OrdreId,
                                    Antall = odetaljer.Antall,
                                    OrdreDato = odetaljer.Ordre.OrdreDato,
                                    Varenavn = odetaljer.Vare.Varenavn,
                                    Total = odetaljer.Ordre.Total

                                }).ToList();
            return bestillinger;
        }
    }
}
