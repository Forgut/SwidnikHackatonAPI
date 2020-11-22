using System;

namespace SwidnikHackaton.FakeDataBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            double lat = 51.2130;
            double lang = 22.6780;
            string date = "GETDATE()";
            Guid guid = Guid.NewGuid();

            string result = "";
            for (int i = 0; i < 100; i++)
            {
                result += $"insert into PedestrianTraffic values({guid.ToString().ToUpper()},{lat + 0.001*i}, {lang},{date})\n";
            }
            Console.WriteLine(result);
        }
    }
}
