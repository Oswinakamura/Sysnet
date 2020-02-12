using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Sysnet.Models;

namespace Sysnet.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            IEnumerable<Persona> personas = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44377/api/PersonaCrud");
            var consumeapi = hc.GetAsync("PersonaCrud");
            consumeapi.Wait();
            var redadata = consumeapi.Result;
            if (redadata.IsSuccessStatusCode)
            {
                var displaydata = redadata.Content.ReadAsAsync<IList<Persona>>();
                displaydata.Wait();
                personas = displaydata.Result;
            }
            return View(personas);
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44377/api/");
            var insertemp = hc.PostAsJsonAsync<Persona>("PersonaCrud", persona);
            insertemp.Wait();
            var savedata = insertemp.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            PersonaClass perobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44377/api/");
            var consumeapi = hc.GetAsync("PersonaCrud?id=" + id.ToString());
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayempdatalis = readdata.Content.ReadAsAsync<PersonaClass>();
                displayempdatalis.Wait();
                perobj = displayempdatalis.Result;
            }
            return View(perobj);
        }

        public ActionResult Edit(int id)
        {
            PersonaClass perobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44377/api/");
            var consumeapi = hc.GetAsync("PersonaCrud?id=" + id.ToString());
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayempdatalis = readdata.Content.ReadAsAsync<PersonaClass>();
                displayempdatalis.Wait();
                perobj = displayempdatalis.Result;
            }
            return View(perobj);
        }

        [HttpPost]
        public ActionResult Edit(PersonaClass pe)
        {

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44377/api/PersonaCrud");
            var update = hc.PutAsJsonAsync<PersonaClass>("PersonaCrud", pe);
            update.Wait();
            var savedata = update.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(pe);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44377/api/PersonaCrud");
            var delete = hc.DeleteAsync("PersonaCrud/" + id.ToString());
            delete.Wait();
            var savedata = delete.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");

        }
    }
}