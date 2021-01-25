using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncSumN
{
    public class Calculator
    {
        private async Task<int> SumAction(int n, CancellationToken token)
        {
            Console.WriteLine("Идет вычисление");
            int temp = 0;
            for (int i = 0; i <= n; i++)
            {
                Thread.Sleep(1000);
                temp += i;
                if(token.IsCancellationRequested)
                    return temp;
            }

            return temp;
        }

        public async Task<int> SumAsync(int n,CancellationToken token)
        {
            var result = await Task.Run(() => SumAction(n, token),token);

            if(!token.IsCancellationRequested)
            Console.WriteLine(result);

            return result;
        }
    }
}
