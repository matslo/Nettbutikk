using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikken.Model;

namespace Nettbutikken.DAL
{
    public class KundeRepository : IKundeRepository
    {
        public List<Kunde> hentAlle()
        {
            var db = new Dbcontext();
            List<Kunde> alleKunder = db.dbBrukere.Select(k => new Kunde()
            {
                id = k.Id,
                Brukernavn = k.Brukernavn,
                Email = k.Email,
            }
                                ).ToList();
            return alleKunder;
        }

        public bool settInn(Kunde innKunde)
        {

            byte[] passordDb = lagHash(innKunde.BekreftPassord);
            var nyKunde = new dbBruker()
            {
                Brukernavn = innKunde.Brukernavn,
                Email = innKunde.Email,
                Passord = passordDb
            };
            var db = new Dbcontext();
            try
            {
                db.dbBrukere.Add(nyKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        public bool endreKunde(int id, Kunde innKunde)
        {
            byte[] passordDb = lagHash(innKunde.Passord);
            var db = new Dbcontext();
            try
            {
                dbBruker endreKunde = db.dbBrukere.FirstOrDefault(k => k.Id == id);
                endreKunde.Brukernavn = innKunde.Brukernavn;
                endreKunde.Email = innKunde.Email;
                endreKunde.Passord = passordDb;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool slettKunde(int slettId)
        {
            var db = new Dbcontext();
            try
            {
                dbBruker slettKunde = db.dbBrukere.FirstOrDefault(k => k.Id == slettId);
                db.dbBrukere.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
        public Kunde hentEnKunde(int id)
        {
            var db = new Dbcontext();

            var enDbKunde = db.dbBrukere.FirstOrDefault(k => k.Id == id);

            if (enDbKunde == null)
            {
                return null;
            }
            else
            {
                var utKunde = new Kunde()
                {
                    id = enDbKunde.Id,
                    Brukernavn = enDbKunde.Brukernavn,
                    Email = enDbKunde.Email
                };
                return utKunde;
            }
        }
        public byte[] lagHash(string innPassord)
        {
            //Hash passord
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            if (innPassord != null)
            {
                innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
                utData = algoritme.ComputeHash(innData);
                return utData;

            }
            return null;
        }
    }
}