using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Program
    {
        static void Main(string[] args)
        {

            Heap<int> heap = new Heap<int>((int x, int y) => x - y, 1);
            int[] vals = new int[] { 1, 5, 4, 6 };
            foreach(int v in vals)
            {
                Console.Write(v.ToString() + ' ');
            }
            Console.WriteLine();
            int[] sorted = new int[vals.Length];
            int num = 0;
            do
            {
                num = heap.Pop();
            } while (num != null);
        }
    }
}
