using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikken.Model;

namespace Nettbutikken.DAL
{
    public class KundeRepositoryStub : IKundeRepository
    {
        public List<Kunde> hentAlle()
        {
            var kundeListe = new List<Kunde>();
            var kunde = new Kunde()
            {
                id = 1,
                Brukernavn = "PerPerPer",
                Email = "PerPerPer@Per.com",
                Passord = "Osloveien82",                
            };
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            return kundeListe;
        }
        public bool settInn(Kunde innKunde)
        {
           if(innKunde.Brukernavn == "")
           {
               return false;
           }
           else
           {
               return true;
           } 
        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            if(id==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool slettKunde(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Kunde hentEnKunde(int id)
        {
            if(id==0)
            {
                var kunde = new Kunde();
                kunde.id = 0;
                return kunde;
            }
            else
            {
                var kunde = new Kunde()
                {
                    id = 1,
                    Brukernavn = "PerPerPer",
                    Email = "PerPerPer@Per.com",
                    Passord = "Osloveien82"
                    };
                return kunde;
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