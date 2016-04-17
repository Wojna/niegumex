using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NieGumex.Contex;
using NieGumex.Models;

namespace NieGumex.Controllers
{
    public class FacturesController : Controller
    {
        private ProduktyContext db = new ProduktyContext();

        // GET: Factures
        public async Task<ActionResult> Index()
        {
            return View(await db.Facture.ToListAsync());
        }

        // GET: Factures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FactureID,FactureName,DataWystawienia,Imie,Nazwisko,Nazwa,Miejscowosc,Ulica,NumerDomu,KodPocztowy,Nip,Produkt,Ilosc,CenaNetto,CenaBrutto,StawkaVat")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Facture.Add(facture);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(facture);
        }

        // GET: Factures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FactureID,FactureName,DataWystawienia,Imie,Nazwisko,Nazwa,Miejscowosc,Ulica,NumerDomu,KodPocztowy,Nip,Produkt,Ilosc,CenaNetto,CenaBrutto,StawkaVat")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facture).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(facture);
        }

        // GET: Factures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = await db.Facture.FindAsync(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Facture facture = await db.Facture.FindAsync(id);
            db.Facture.Remove(facture);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
