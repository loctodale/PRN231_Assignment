using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceWCFClient
{
    public interface IInvoice
    {
        List<string> GetAll();
        string GetById(string id);
        void Create();
    }
}
