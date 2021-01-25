using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncSumN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            Calculator calculator = new Calculator();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int n))
                {
                    tokenSource.Cancel();
                    tokenSource = new CancellationTokenSource();

                    calculator.SumAsync(n, tokenSource.Token);
                    Console.WriteLine("Введите другое число для перезагрузки с новыми параметрами");
                }
                else
                    Console.WriteLine("Это не число");
            }
        }
    }
}
