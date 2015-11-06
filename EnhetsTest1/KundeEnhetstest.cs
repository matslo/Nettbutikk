using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Nettbutikken.Controllers;
using Nettbutikken.BLL;
using Nettbutikken.DAL;
using System.Collections.Generic;
using Nettbutikken.Model;
using System.Web.Mvc;
using System.Web;

namespace EnhetsTest1
{
    [TestClass]
    public class KundeEnhetstest
    {
        [TestMethod]
        public void Liste()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            // uten test : var controller = new PersonController();
            var forventetResultat = new List<Kunde>();
            var kunde = new Kunde()
            {
                id = 1,
                Brukernavn = "PerPerPer",
                Email = "PerPerPer@Per.com",
                Passord = "Osloveien82",

            };
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);

            // Act
            var actionResult = (ViewResult)controller.Liste();
            var resultat = (List<Kunde>)actionResult.Model;
            // Assert

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].id, resultat[i].id);
                Assert.AreEqual(forventetResultat[i].Brukernavn, resultat[i].Brukernavn);
                Assert.AreEqual(forventetResultat[i].Email, resultat[i].Email);
                Assert.AreEqual(forventetResultat[i].Passord, resultat[i].Passord);
            }
            /*
            Det som kommer under er bare for å vise hva Assert.IsTrue kan gjøre (dvs alt!)
            string forventet1 = "Her er en mulighet";
            string forventet2 = "Her er en mulighet til";
            string virkelig = "Her er en mulighet";
            if (virkelig == forventet1 || virkelig==forventet2)
                test = true;
            else 
                test = false;
            Assert.IsTrue(test);
             
             */
        }
        [TestMethod]
        public void Registrer()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.Registrer();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Registrer_Post_OK()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));

            var forventetKunde = new Kunde()
            {
                Brukernavn = "PerPer",
                Email = "PerPerPer@Per.com",
                Passord = "Osloveien82"
            };
            // Act
            var result = (RedirectToRouteResult)controller.Registrer(forventetKunde);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Liste");
        }
        [TestMethod]
        public void Registrer_Post_Model_feil()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            var forventetKunde = new Kunde();
            controller.ViewData.ModelState.AddModelError("fornavn", "Ikke oppgitt fornavn");

            // Act
            var actionResult = (ViewResult)controller.Registrer(forventetKunde);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Registrer_Post_DB_feil()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            var forventetKunde = new Kunde();
            forventetKunde.Brukernavn = "";

            // Act
            var actionResult = (ViewResult)controller.Registrer(forventetKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Detaljer()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            var forventetResultat = new Kunde()
            {
                id = 1,
                Brukernavn = "PerPerPer",
                Email = "PerPerPer@Per.com",
                Passord = "Osloveien82"

            };
            // Act
            var actionResult = (ViewResult)controller.Detaljer(1);
            var resultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(forventetResultat.id, resultat.id);
            Assert.AreEqual(forventetResultat.Brukernavn, resultat.Brukernavn);
            Assert.AreEqual(forventetResultat.Email, resultat.Email);
            Assert.AreEqual(forventetResultat.Passord, resultat.Passord);
        }
        [TestMethod]
        public void Slett()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.Slett(1);
            var resultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");


        }
        [TestMethod]
        public void Slettet_funnet_Post()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            var innKunde = new Kunde()
            {
                Brukernavn = "PerPer",
                Email = "PerPerPer@Per.com",
                Passord = "Osloveien82",
            };

            // Act
            var actionResult = (RedirectToRouteResult)controller.Slett(1, innKunde);

            // Assert
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Liste");
        }
        [TestMethod]
        public void Slett_ikke_funnet_Post()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            var innKunde = new Kunde()
            {
                Brukernavn = "PerPer",
                Email = "PerPerPer@Per.com",
                Passord = "Osloveien82",
               
            };

            // Act
            var actionResult = (ViewResult)controller.Slett(0, innKunde);
            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.Endre(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.Endre(0);
            var kundeResultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(kundeResultat.id, 0);
        }
        [TestMethod]
        public void Endre_ikke_funnet_Post()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            var innKunde = new Kunde()
            {
                id = 0,
                Brukernavn = "PerPer",
                Email = "PerPerPer@Per.com",
                Passord = "Osloveien82"
            };

            // Act
            var actionResult = (ViewResult)controller.Endre(0, innKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_feil_validering_Post()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            var innKunde = new Kunde();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.Endre(0, innKunde);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_funnet()
        {
            // Arrange
            var controller = new KundebehandlingController(new KundeBLL(new KundeRepositoryStub()));
            var innKunde = new Kunde()
            {
                Brukernavn = "PerPer",
                Email = "PerPerPer@Per.com",
                Passord = "Osloveien82"
                
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.Endre(1, innKunde);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "Liste");
        }
    }
}
