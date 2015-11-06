using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Nettbutikken.Controllers;
using Nettbutikken.BLL;
using Nettbutikken.DAL;
using System.Collections.Generic;
using Nettbutikken.Model;
using System.Web.Mvc;
using System.Web;
using System;

namespace EnhetsTest1
{
    [TestClass]
    public class OrdreEnhetstest
    {
        [TestMethod]
        public void Liste()
        {
            // Arrange
            var controller = new OrdreBehandlingController(new OrdreBLL(new OrdreRepositoryStub()));
            // uten test : var controller = new PersonController();
            var forventetResultat = new List<Kvitto>();
            var ordrer = new Kvitto()
            {
                Brukernavn = "PerPer",
                OrdreId = 1,
                OrdreDato = new DateTime(2015, 6, 10, 15, 24, 16),
                Varenavn = "Kaffemaskin",
                Antall = 2,
                Total = 100

            };
            forventetResultat.Add(ordrer);
            forventetResultat.Add(ordrer);
            forventetResultat.Add(ordrer);

            // Act
            var actionResult = (ViewResult)controller.Liste();
            var resultat = (List<Kvitto>)actionResult.Model;
            // Assert

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].Brukernavn, resultat[i].Brukernavn);
                Assert.AreEqual(forventetResultat[i].OrdreId, resultat[i].OrdreId);
                Assert.AreEqual(forventetResultat[i].OrdreDato, resultat[i].OrdreDato);
                Assert.AreEqual(forventetResultat[i].Varenavn, resultat[i].Varenavn);
                Assert.AreEqual(forventetResultat[i].Antall, resultat[i].Antall);
                Assert.AreEqual(forventetResultat[i].Total, resultat[i].Total);

            }
            
        }
        [TestMethod]
        public void enOrdre()
        {
            // Arrange
            var controller = new OrdreBehandlingController(new OrdreBLL(new OrdreRepositoryStub()));
            var forventetResultat = new List<Kvitto>();
            var ordrer = new Kvitto()
            {
                Brukernavn = "PerPer",
                OrdreId = 1,
                OrdreDato = new DateTime(2015, 6, 10, 15, 24, 16),
                Varenavn = "Kaffemaskin",
                Antall = 2,
                Total = 100

            };
            forventetResultat.Add(ordrer);
            forventetResultat.Add(ordrer);
            forventetResultat.Add(ordrer);
            // Act
            var actionResult = (ViewResult)controller.enOrdre("PerPer");
            var resultat = (List<Kvitto>)actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");

            // Assert
            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].Brukernavn, resultat[i].Brukernavn);
                Assert.AreEqual(forventetResultat[i].OrdreId, resultat[i].OrdreId);
                Assert.AreEqual(forventetResultat[i].OrdreDato, resultat[i].OrdreDato);
                Assert.AreEqual(forventetResultat[i].Varenavn, resultat[i].Varenavn);
                Assert.AreEqual(forventetResultat[i].Antall, resultat[i].Antall);
                Assert.AreEqual(forventetResultat[i].Total, resultat[i].Total);

            }
        }
    }
}
