using System;
using TheIsleMapCalculator.Enums;

namespace TheIsleMapCalculator.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new PositionCalculator(Map.IsleV3);
            var data = calc.ParseGameLocation("X=477317.844 Y=199894.969 Z=-72458.117");
            var result = calc.CalculateGameLocation(data);

            Console.WriteLine(result.ToString());
            Console.ReadKey();
        }
    }
}
