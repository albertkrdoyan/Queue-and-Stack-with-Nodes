using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class QueueNode<T>
    {
        class Node<T>
        {
            public Node<T> next;
            public T value;
        }

        Node<T> begin, end, last;
        int size;
        public int Size { get { return size; } }
        public T Last { get { return last.value; } set { last.value = value; } }
        public T First { get { return begin.next.value; } set { begin.next.value = value; } }

        public QueueNode()
        {
            begin = new Node<T>();
            end = new Node<T>();
            begin.next = end;
            last = end;
            size = 0;
        }

        public void Add(T item)
        {
            InnerAdd(ref begin.next, item);
        }

        private void InnerAdd(ref Node<T> n, T item)
        {
            if (n == end)
            {
                n = new Node<T> { value = item };
                n.next = end;
                last = n;
                size++;
                return;
            }
            InnerAdd(ref n.next, item);
        }

        public T Remove()
        {
            T rem_item = begin.next.value;

            begin = begin.next;
            size--;

            return rem_item;
        }

        public void Print()
        {
            Node<T> curr = begin;
            while (curr != end)
            {
                if (curr == begin)
                    Console.Write("{ ");
                else
                    Console.Write(curr.value + " ");

                curr = curr.next;
            }
            Console.WriteLine("}");
        }
    }

    class StackNode<T>
    {
        class NodeS<T>
        {
            public NodeS<T> next, prev;
            public T value;
        }

        NodeS<T> begin, end;
        int size;

        public int Size { get { return size; } }

        public StackNode()
        {
            begin = new NodeS<T>();
            end = new NodeS<T>();
            begin.next = end;
            end.prev = begin;
            size = 0;
        }

        public void Print()
        {
            NodeS<T> current = begin;

            while (current != end)
            {
                if (current == begin)
                    Console.Write("{ ");
                else
                    Console.Write(current.value + " ");

                current = current.next;
            }
            Console.WriteLine("}");
        }

        public void Push(T item)
        {
            InnerPush(ref begin.next, item);
        }

        private void InnerPush(ref NodeS<T> node, T item) {

            if (node == end)
            {
                node = new NodeS<T> 
                {
                   value = item,
                   next = end,
                   prev = end.prev
                };
                end.prev = node;
                size++;
                return;
            }
            InnerPush(ref node.next, item);
        }

        public T Pop()
        {
            T item = end.prev.value;
            size--;

            try
            {
                end.prev = end.prev.prev;
                end.prev.next = end;
            }catch(Exception)
            {
                throw new NullReferenceException("No Item to remove");
            }

            return item;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            return;
            QueueNode<int> q = new QueueNode<int>();
            q.Add(1);
            q.Add(2);
            q.Add(3);
            q.Add(4);
            q.Add(5);

            q.Print();

            Console.WriteLine("Removed: {0}.", q.Remove());
            Console.WriteLine("Removed: {0}.", q.Remove());

            q.Print();

            Console.ReadKey();
            return;
            StackNode<int> s = new StackNode<int>();
            s.Push(1);
            s.Push(2);
            s.Push(5);

            s.Print();

            s.Push(7);
            s.Push(9);
            s.Push(11);

            s.Print();

            Console.WriteLine("POP: {0}.", s.Pop());
            Console.WriteLine("POP: {0}.", s.Pop());
            Console.WriteLine("POP: {0}.", s.Pop());

            s.Print();

            Console.WriteLine("POP: {0}.", s.Pop());
            Console.WriteLine("POP: {0}.", s.Pop());

            s.Print();

            s.Push(15);
            s.Push(20);

            s.Print();

            Console.WriteLine("POP: {0}.", s.Pop());
            Console.WriteLine("POP: {0}.", s.Pop());
            Console.WriteLine("POP: {0}.", s.Pop());

            s.Print();

            Console.ReadKey();
        }
    }
}
