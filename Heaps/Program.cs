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
            int[] vals = new int[1000];
            Random rand = new Random();
            for(int j = 0; j < vals.Length; j++)
            {
                vals[j] = rand.Next();
            }
            foreach (int v in vals)
            {
                Console.Write(v.ToString() + ' ');
                heap.Insert(v);
            }
            Console.WriteLine();
            int[] sorted = new int[vals.Length];
            int i = 0;
            int num = 0;
            do
            {
                num = heap.Pop();
                sorted[i] = num;
                i++;
                Console.Write(num.ToString() + ' ');
            } while (heap.Size > 1);
            Console.WriteLine("\n" + (Sorted(sorted) ? "Sorted" : "NOT Sorted"));
            Console.ReadKey();
        }

        static bool Sorted(int[] vals)
        {
            for (int i = 0; i < vals.Length - 2; i++)
            {
                if (vals[i + 1] < vals[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
