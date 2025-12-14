using System;
using System.Collections;
using System.Collections.Generic;


namespace BoundedQueue
{
    public class BoundedQueue<T> : ICollection<T>
    {
        private readonly Queue<T> _queue;
        private readonly int _capacity;
        private readonly OverflowBehavior _overflowBehavior;

        public BoundedQueue(int capacity, OverflowBehavior overflowBehavior = OverflowBehavior.RemoveOldest)
        {
            if (capacity <= 0)
                throw new ArgumentException("Емкость должна быть больше 0", nameof(capacity));

            _capacity = capacity;
            _overflowBehavior = overflowBehavior;
            _queue = new Queue<T>(capacity);
        }

        public int Count => _queue.Count;
        public int Capacity => _capacity;
        public bool IsEmpty => _queue.Count == 0;
        public bool IsFull => _queue.Count >= _capacity;
        public OverflowBehavior Behavior => _overflowBehavior;

        public bool IsReadOnly => false;

        public void Enqueue(T item)
        {
            if (_queue.Count >= _capacity)
            {
                switch (_overflowBehavior)
                {
                    case OverflowBehavior.RemoveOldest:
                        _queue.Dequeue();
                        _queue.Enqueue(item);
                        break;

                    case OverflowBehavior.ThrowException:
                        throw new InvalidOperationException("Очередь полна. Невозможно добавить новый элемент.");

                    default:
                        throw new ArgumentOutOfRangeException(nameof(_overflowBehavior), "Неизвестное поведение при переполнении");
                }
            }
            else
            {
                _queue.Enqueue(item);
            }
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        public void Add(T item)
        {
            Enqueue(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _queue.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException("Удаление произвольных элементов не поддерживается. Используйте Dequeue().");
        }
    }
}
