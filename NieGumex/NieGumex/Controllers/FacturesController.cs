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
using NieGumex.ViewModels;
using Microsoft.AspNet.Identity;
using System.Xml;
using System.Xml.Linq;

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

        public async Task<ActionResult> Edifact(int? id)
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

            var produkty = (List<ProductsVm>)Session["Koszyk"];
            var factureName = db.Facture.OrderByDescending(a => a.FactureName).FirstOrDefault()?.FactureName;
            var productFacture = produkty.Select(a => a.Nazwa).Single();
            var iloscFacture = produkty.Select(b => b.WantIt).Single();
            var cenaFactures = (produkty.Select(c => c.Cena).Single()) * iloscFacture;
            var ean = produkty.Select(c => c.EAN).Single();
            var cenanettoFactures = (cenaFactures * 0.77m);

            foreach (var produkt in produkty)
            {
                var kompletyModel = db.Products.Find(produkt.ProductID);
                kompletyModel.LiczbaKompletow -= produkt.WantIt;

            }

            var number = 0;
            if (factureName != null)
            {
                var splited = factureName.Split(new string[] { "/" }, StringSplitOptions.None)[2];
                int.TryParse(splited, out number);
                number++;
            }

            var facture = new Facture
            {
                FactureName = factureName == null ? "Fac/" + DateTime.Now.Year.ToString() + "/1" : "Fac/" + DateTime.Now.Year.ToString() + "/" + number.ToString(),
                Produkt = productFacture.ToString(),
                Ilosc = iloscFacture,
                CenaBrutto = cenaFactures,
                CenaNetto = cenanettoFactures,
                EAN = ean,
            };

            Decimal kwVAT = cenaFactures - cenanettoFactures;
            ViewBag.kwotVAT = kwVAT;

            db.SaveChanges();
            return View(facture);
        }

        // POST: Factures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Facture facture)
        {
            if (ModelState.IsValid)
            {
                facture.DataPlatnosci = DateTime.Now;
                facture.DataWystawienia = DateTime.Now;
                db.Facture.Add(facture);
                db.SaveChanges();
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
        public async Task<ActionResult> Edit([Bind(Include = "FactureID,FactureName,DataWystawienia,Imie,Nazwisko,Nazwa,Miejscowosc,Ulica,NumerDomu,KodPocztowy,Nip,Produkt,EAN,Ilosc,CenaNetto,CenaBrutto,StawkaVat,numerKonta,Wojewodztwo,DataPlatnosci")] Facture facture)
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

        public async Task<ActionResult>FactureXML(int? id)
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


            //zapisuje xml z zwykłej faktury, ale dodaje też html'a z widoku FactureXML.. trzeba coś z tym returnem zrobić
            var xmlFac = db.Facture.Where(a => a.FactureID == id).ToList();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename = fakturka.xml");
            Response.ContentType = "text/xml";

            var serializer = new
            System.Xml.Serialization.XmlSerializer(xmlFac.GetType());
            serializer.Serialize(Response.OutputStream, xmlFac);
            
            return View();




            //*******CIAPKOWE*************


            //var factureName = db.Facture.OrderByDescending(a => a.FactureName).Where(v => v.FactureID == id);

            //XElement xml = new XElement("Faktura",
            //    new XElement("NrFaktury",
            //        factureName),
            //    new XElement("DataWystawienia",
            //        "dddddddddd")
            //);
            //viewModel.EdiDoDekodowania = xml.ToString();

            //using (XmlWriter writer = XmlWriter.Create("faktura.xml"))
            //{
            //    writer.WriteStartElement("faktura");
            //    writer.WriteElementString("NrFaktury", factureName.ToString());
            //    writer.WriteElementString("DataWystawienia", "dddddddddd");
            //    //writer.WriteElementString("NipSprzedawcy", fakturaEDIFact.NipSprzedawcy);
            //    //writer.WriteElementString("ImieSprzedawcy", fakturaEDIFact.ImieSprzedawcy);
            //    writer.WriteEndElement();
            //    writer.Flush();
            //}

        }

        public ActionResult FakturaXML(int? id)
        {

            var factureName = db.Facture.OrderByDescending(a => a.FactureName).Where(v => v.FactureID == id);

            XElement xml = new XElement("Faktura",
                new XElement("NrFaktury",
                    factureName),
                new XElement("DataWystawienia",
                    "dddddddddd")
            );
            //viewModel.EdiDoDekodowania = xml.ToString();

            using (XmlWriter writer = XmlWriter.Create("faktura.xml"))
            {
                writer.WriteStartElement("faktura");
                writer.WriteElementString("NrFaktury", factureName.ToString());
                //writer.WriteElementString("DataWystawienia", fakturaEDIFact.DataWystawienia.ToString());
                //writer.WriteElementString("NipSprzedawcy", fakturaEDIFact.NipSprzedawcy);
                //writer.WriteElementString("ImieSprzedawcy", fakturaEDIFact.ImieSprzedawcy);
                writer.WriteEndElement();
                writer.Flush();
            }
            return View();
        }
    }
}
