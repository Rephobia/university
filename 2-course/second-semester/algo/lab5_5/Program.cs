using System;
using System.Collections;
using System.Collections.Generic;

namespace Program
{
    public class DoublyNode<T>
    {
        public T Data { get; set; }
        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Previous { get; set; }

        public DoublyNode(T data)
        {
            Data = data;
        }
    }

    public class Deque<T> : IEnumerable<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;
        private int count;

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }

        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException("Дек пуст");
            T output = head.Data;
            if (count == 1)
                head = tail = null;
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return output;
        }

        public T RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException("Дек пуст");
            T output = tail.Data;
            if (count == 1)
                head = tail = null;
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return output;
        }

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Дек пуст");
                return head.Data;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Дек пуст");
                return tail.Data;
            }
        }

        public int Count => count;
        public bool IsEmpty => count == 0;

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main()
        {
            var deque = new Deque<int>();

            Console.WriteLine("Добавим в дек: AddFirst(1), AddLast(2), AddFirst(0), AddLast(3)");
            deque.AddFirst(1);
            deque.AddLast(2);
            deque.AddFirst(0);
            deque.AddLast(3);

            Console.WriteLine("Дек после добавлений:");
            PrintDeque(deque);

            Console.WriteLine("\nУдаляем первый элемент: " + deque.RemoveFirst());
            Console.WriteLine("Удаляем последний элемент: " + deque.RemoveLast());

            Console.WriteLine("\nДек после удалений:");
            PrintDeque(deque);

            Console.WriteLine("\nПервый элемент: " + deque.First);
            Console.WriteLine("Последний элемент: " + deque.Last);
            Console.WriteLine("Содержит 2? " + (deque.Contains(2) ? "Да" : "Нет"));
            Console.WriteLine("Содержит 100? " + (deque.Contains(100) ? "Да" : "Нет"));
        }

        static void PrintDeque<T>(Deque<T> deque)
        {
            foreach (var item in deque)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}
