using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WCF.Data;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IInvoiceService
    {
        KoiTravelShop_InvoiceEntities1 db = new KoiTravelShop_InvoiceEntities1();

        public async Task<bool> CreateInvoice(Invoice invoice)
        {
            db.Invoices.Add(invoice);
            await db.SaveChangesAsync();
            return true; 
        }

        public List<Invoice> GetAll()
        {
           return  db.Invoices.ToList();
        }

        public async Task<bool> UpdateInvoice(Invoice invoice)
        {
            var found  = db.Invoices.FirstOrDefault(x => x.Id == invoice.Id);
            found.PaymentDate = invoice.PaymentDate;
            found.PaymentAmount = invoice.PaymentAmount;
            db.Invoices.AddOrUpdate(found);
            await db.SaveChangesAsync();
            return true;
        }

    }
}
