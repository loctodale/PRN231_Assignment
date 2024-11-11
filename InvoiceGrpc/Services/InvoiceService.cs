using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using InvoiceGrpc.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGrpc.Services
{
    public class InvoiceService : InvoiceRPC.InvoiceRPCBase
    {
        private readonly KoiTravelShop_InvoiceContext _context;

        public InvoiceService(KoiTravelShop_InvoiceContext context)
        {
            _context = context;
        }
        public override async Task<GetAllReply> GetAll(Empty request, ServerCallContext context)
        {
            var dbInvoices = await _context.Invoices.ToListAsync();
            var reply = new GetAllReply();
            foreach (var dbInvoice in dbInvoices)
            {
                reply.Invoices.Add(new Invoice
                {
                    Id = dbInvoice.Id.ToString(),
                    PaymentAmount = (double)dbInvoice.PaymentAmount,
                    PaymentDate = dbInvoice.PaymentDate.HasValue
                        ? Timestamp.FromDateTime(DateTime.SpecifyKind(dbInvoice.PaymentDate.Value, DateTimeKind.Utc))
                        : null
                });
            }

            return reply;
        }

        public override async Task<CreateReply> Create(Invoice request, ServerCallContext context)
        {
            Console.WriteLine(request.Id);
            var newInvoice = new Models.Invoice
            {
                Id = Guid.Parse(request.Id),
                PaymentAmount = (decimal)request.PaymentAmount,
                PaymentDate = DateTime.Now,

            };
            _context.Invoices.Add(newInvoice);
            await _context.SaveChangesAsync();
            var result = new CreateReply
            {
                Invoices = request,
            };
            return result;
        }

        public override async Task<UpdateReply> Update(Invoice request, ServerCallContext context)
        {
            Console.WriteLine(request.Id);
            //var newInvoice = new Models.Invoice
            //{
            //    Id = Guid.Parse(request.Id),
            //    PaymentAmount = (decimal)request.PaymentAmount,
            //    PaymentDate = DateTime.Now,

            //};
            var found = _context.Invoices.FirstOrDefault(x => x.Id == Guid.Parse(request.Id));
            found.PaymentDate = DateTime.Now;
            found.PaymentAmount = (decimal)request.PaymentAmount;
            _context.Invoices.Update(found);
            await _context.SaveChangesAsync();
            var result = new UpdateReply
            {
                Invoices = request,
            };
            return result;
        }
    }
}
