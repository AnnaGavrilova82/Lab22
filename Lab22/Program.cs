using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int r = random.Next();
                array[i] = r;
            }
            
            Action<object> action = new Action<object>(Sum);
            Task task1 = new Task(action, array);

            Action<Task, object> action2 = new Action<Task, object>(Max);
            Task task2 = task1.ContinueWith(action2, array);

            task1.Start();


            Console.WriteLine();
            Console.ReadKey();
        }

        static void Sum(object array)
        {
            int[] n = (int[])array;
            int s = 0;
            for (int i = 0; i < n.Length; i++)
            {
                s += n[i];
            }
            Console.WriteLine($"Сумма всех чисел массива = {s}");
        }
        static void Max(Task task, object array)
        {
            int[] n = (int[])array;
            Array.Sort(n);
            int max = n.Last();
            Console.WriteLine($"Максимальный элемент массива = {max}");
        }

    }
}
