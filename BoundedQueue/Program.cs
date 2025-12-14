using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundedQueue
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nRemoveOldest");
            var queue1 = new BoundedQueue<int>(3, OverflowBehavior.RemoveOldest);

            for (int i = 1; i <= 5; i++)
            {
                queue1.Enqueue(i);
                Console.WriteLine($"Добавлено: {i}, Содержимое: [{string.Join(", ", queue1)}]");
            }

            Console.WriteLine("\nThrowException");
            var queue2 = new BoundedQueue<int>(3, OverflowBehavior.ThrowException);

            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    queue2.Enqueue(i);
                    Console.WriteLine($"Добавлено: {i}, Содержимое: [{string.Join(", ", queue2)}]");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }
    }
}
