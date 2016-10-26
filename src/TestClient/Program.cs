using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace TestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please provide the remote URL of the calculator service");
                return;
            }

            // Create random inputs
            Random numGen = new Random();
            double x = numGen.NextDouble() * 20;
            double y = numGen.NextDouble() * 20;

            var serviceAddress = $"{args[0]}/CalculatorService.svc";

            var client = new CalculatorServiceClient(new BasicHttpBinding(), new EndpointAddress(serviceAddress));
            Console.WriteLine($"{x} + {y} == {client.Add(x, y)}");
            Console.WriteLine($"{x} - {y} == {client.Subtract(x, y)}");
            Console.WriteLine($"{x} * {y} == {client.Multiply(x, y)}");
            Console.WriteLine($"{x} / {y} == {client.Divide(x, y)}");
        }
    }
    class CalculatorServiceClient : ClientBase<ICalculatorService>
    {
        public CalculatorServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }
        public double Add(double x, double y) => Channel.Add(x, y);
        public double Subtract(double x, double y) => Channel.Subtract(x, y);
        public double Multiply(double x, double y) => Channel.Multiply(x, y);
        public double Divide(double x, double y) => Channel.Divide(x, y);
    }

    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        double Add(double x, double y);
        [OperationContract]
        double Subtract(double x, double y);
        [OperationContract]
        double Multiply(double x, double y);
        [OperationContract]
        double Divide(double x, double y);
    }
}