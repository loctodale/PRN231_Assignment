using Grpc.Net.Client;
using InvoiceGrpc;

internal class Program
{
    static void Main(string[] args)
    {
        var grpcChannel = GrpcChannel.ForAddress("https://localhost:7036");
        //var greeterClient = new Greeter.GreeterClient(grpcChannel);
        //var greeterReply = greeterClient.SayHello(new HelloRequest { Name = "Hello" });
        var invoiceClient = new InvoiceRPC.InvoiceRPCClient(grpcChannel);
        var invoiceCreateReply = invoiceClient.Create(new Invoice
        {
            Id = Guid.NewGuid().ToString(),
            PaymentAmount = 9999,
            PaymentDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
        });
        var invoiceReply = invoiceClient.GetAll(new Empty { });
        Console.WriteLine(invoiceReply.ToString());
        Console.ReadKey();
    }
}