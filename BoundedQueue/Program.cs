using System;
using System.Collections.Generic;
using System.Linq;

public class BoundedQueue<T> : IEnumerable<T>
{
    private readonly Queue<T> _queue;
    private readonly int _capacity;

    public BoundedQueue(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Емкость должна быть больше 0", nameof(capacity));

        _capacity = capacity;
        _queue = new Queue<T>(capacity);
    }

    public int Count => _queue.Count;
    public int Capacity => _capacity;
    public bool IsEmpty => _queue.Count == 0;
    public bool IsFull => _queue.Count >= _capacity;

    public void Enqueue(T item)
    {
        if (_queue.Count >= _capacity)
        {
            _queue.Dequeue();
        }
        _queue.Enqueue(item);
    }

    public T Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("Очередь пуста");

        return _queue.Dequeue();
    }

    public T Peek()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("Очередь пуста");

        return _queue.Peek();
    }

    public void Clear()
    {
        _queue.Clear();
    }

    public bool Contains(T item)
    {
        return _queue.Contains(item);
    }

    public T[] ToArray()
    {
        return _queue.ToArray();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _queue.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return _queue.GetEnumerator();
    }
}
class Program
{
    static void Main()
    {
        var numbers = new BoundedQueue<int>(5);

        for (int i = 1; i <= 7; i++)
        {
            numbers.Enqueue(i);
        }

        foreach (var num in numbers)
        {
            Console.Write(num + " ");
        }
    }
}