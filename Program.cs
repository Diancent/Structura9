using System;
using System.Linq;
using System.Diagnostics;
namespace structura9Cshard
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Довжина першого масива: "); int n = int.Parse(Console.ReadLine());
            Console.Write("Довжина другого масива: "); int m = int.Parse(Console.ReadLine());
            Console.Write("Введіть перший масив: ");
            int[] A = Enumerable.Range(0, n).Select(v => int.Parse(Console.ReadLine())).ToArray();//заповнюєм перший масив
            Console.Write("Введіть другий масив: ");
            int[] B = Enumerable.Range(0, m).Select(v => int.Parse(Console.ReadLine())).ToArray();//заповнюєм другий масив
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            Search(A, B);
            stopwatch1.Stop();
            Console.WriteLine("\nВитрачено наносекунд на виконання пошуку: "+ 100*stopwatch1.ElapsedTicks);
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Sort(A);
            SortTwo(B);
            Console.WriteLine("\nВитрачено наносекунд на виконання сортування: " + 100 * stopwatch2.ElapsedTicks);
            stopwatch2.Stop();
            Console.ReadLine();
        }
        public static void Search(int[] A, int[] B)
        {
            A = A.GroupBy(v => v).Where(c => c.Count() == 1).SelectMany(y => y).ToArray();//вибираємо ел, які зустрічаються один раз
            for (int i = 0; i < A.Length; i++)
                if (B.Where(v => v == A[i]).Count() > 1) //якщо даний ел зустрічається в другому масиві більше одного разу
                    Console.Write("Ел який не повторюється і зустрічається в 2 масиві: "+A[i] + " ");//виводимо
        } 
        public static void Sort(int[] A)
        {
            Console.WriteLine();
            Console.Write("Відсортований масив: ");
            Array.Sort(A);

            foreach (var i in A)
            {
                Console.Write("{0} ", i);
            }
        }
        public static void SortTwo(int[] B)
        {
            Console.WriteLine();
            Console.Write("Відсортований масив: ");
            Array.Sort(B);

            foreach (var i in B)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
