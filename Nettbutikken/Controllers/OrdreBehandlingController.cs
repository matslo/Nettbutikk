using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikken.BLL;
using Nettbutikken.Model;


namespace Nettbutikken.Controllers
{
    public class OrdreBehandlingController : Controller
    {
        // GET: OrdreBehandling
        private IOrdreLogikk _OrdreBLL;

        public OrdreBehandlingController()
        {
            _OrdreBLL = new OrdreBLL();
        }

        public OrdreBehandlingController(IOrdreLogikk stub)
        {
            _OrdreBLL = stub;
        }

        public ActionResult Liste()
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {
                    List<Kvitto> allOrdre = _OrdreBLL.hentAlle();
                    return View(allOrdre);
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

        public ActionResult enOrdre(string b)
        {
            if (Session["AdminInne"] != null)
            {
                bool loggetInn = (bool)Session["AdminInne"];
                if (loggetInn)
                {

                    List<Kvitto> ordreBruker = _OrdreBLL.hentenOrdre(b);
                    return View(ordreBruker);
                }
            }
            return RedirectToAction("Logginn", "Konto");
        }

    }
}