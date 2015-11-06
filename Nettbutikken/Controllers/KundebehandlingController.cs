using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikken.BLL;
using Nettbutikken.Model;

namespace Nettbutikken.Controllers
{
    public class KundebehandlingController : Controller
    {
        // GET: Kundebehandling
        public ActionResult Index()
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }
        private IKundeLogikk _kundeBLL;

        public KundebehandlingController()
        {
            _kundeBLL = new KundeBLL();
        }

        public KundebehandlingController(IKundeLogikk stub)
        {
            _kundeBLL = stub;
        }

        public ActionResult Liste()
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    List<Kunde> alleKunder = _kundeBLL.hentAlle();
                    return View(alleKunder);
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

        public ActionResult Detaljer(int id)
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    Kunde enKunde = _kundeBLL.hentEnKunde(id);
                    return View(enKunde);
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

        public ActionResult Registrer()
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

        [HttpPost]
        public ActionResult Registrer(Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                bool insertOK = _kundeBLL.settInn(innKunde);
                if (insertOK)
                {
                    return RedirectToAction("Liste");
                }
            }
            return View();
        }

        public ActionResult Endre(int id)
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    Kunde enKunde = _kundeBLL.hentEnKunde(id);
                    return View(enKunde);
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

        [HttpPost]
        public ActionResult Endre(int id, Kunde endreKunde)
        {
           if (ModelState.IsValid)
            {
                bool endringOK = _kundeBLL.endreKunde(id, endreKunde);
                if (endringOK)
                {
                    return RedirectToAction("Liste");
                }
            }
            return View();
        }

        public ActionResult Slett(int id)
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    Kunde enKunde = _kundeBLL.hentEnKunde(id);
                    return View(enKunde);
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

        [HttpPost]
        public ActionResult Slett(int id, Kunde slettKunde)
        {
            bool slettOK = _kundeBLL.slettKunde(id);
            if (slettOK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }
    }
}