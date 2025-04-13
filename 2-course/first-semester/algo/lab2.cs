using System;


class Program
{
	static void Main(string[] args)
	{
		double A = 1;
		double B = 20;
		double C = 3;
		
		double D = B * B - 4 * A * C;
		
		if (D < 0) {
			Console.WriteLine("Нет корней");
		} else if (D == 0) {
			Console.WriteLine("Корень" + (B * -1) / (2 *A));
		} else {
			double x1 = (-B + Math.Sqrt(D) / (2 * A));
			double x2 = (-B - Math.Sqrt(D) / (2 * A));
			Console.WriteLine("Корни: " + x1 + " и "  + x2);
		}
		
	}
}
