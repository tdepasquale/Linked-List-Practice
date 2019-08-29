using System;

namespace Linked_List_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList();
            linkedList.addLast(1);
            linkedList.addLast(2);
            linkedList.addLast(3);
            linkedList.addLast(4);
            linkedList.addLast(5);
            linkedList.addLast(6);
            Console.WriteLine(linkedList.getMiddle());
        }
    }

    class Node
    {
        public int value;
        public Node next;

        public Node(int value, Node next = null)
        {
            this.value = value;
            this.next = next;
        }

        public void setNext(Node newNext)
        {
            next = newNext;
        }

        public Node getNext()
        {
            return next;
        }

        public int getValue()
        {
            return value;
        }
    }

    class LinkedList
    {
        private Node first = null;
        private Node last = null;
        private int count = 0;

        public void print()
        {
            var currentNode = first;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.getValue().ToString());
                currentNode = currentNode.getNext();
            }
        }

        public void addFirst(int newNodeValue)
        {
            Node newNode = new Node(newNodeValue, first);
            first = newNode;
            if (count == 0) last = newNode;
            count++;
        }

        public void addLast(int newNodeValue)
        {
            Node newLast = new Node(newNodeValue);
            if (count == 0)
            {
                first = newLast;
                last = newLast;
            }
            else
            {
                last.setNext(newLast);
                last = newLast;
            }
            count++;
        }

        public void deleteFirst()
        {
            if (count == 0) return;
            first = first.getNext();
            count--;
        }

        public void deleteLast()
        {
            if (count == 0) return;
            else if (count == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                var newLast = getSecondToLast();
                newLast.setNext(null);
                last = newLast;
            }
            count--;
        }

        public bool contains(int value)
        {
            Node currentNode = first;
            do
            {
                if (currentNode.getValue() == value) return true;
            } while (currentNode.getNext() != null);
            return false;
        }

        public int indexOf(int value)
        {
            int index = 0;
            Node currentNode = first;
            do
            {
                if (currentNode.getValue() == value) return index;
                else index++;
            } while (currentNode.getNext() != null);
            return -1;
        }

        public void reverse()
        {
            if (count < 2) return;
            Node originalFirst = first;
            Node currentFirst = first;
            Node next = first.next;
            while (next != null)
            {
                originalFirst.next = next.next;
                next.next = currentFirst;
                currentFirst = next;
                next = originalFirst.next;
            }
            first = currentFirst;
        }

        public Node getSecondToLast()
        {
            Node lastNode = first;
            Node secondToLastNode = first;
            if (count < 2) throw new Exception();
            while (lastNode.getNext() != null)
            {
                secondToLastNode = lastNode;
                lastNode = lastNode.getNext();
            }
            return secondToLastNode;
        }

        public int getKthFromEnd(int k)
        {
            if (count < k || k < 1) throw new IndexOutOfRangeException();

            int counter = 0;
            Node kPointer = null;
            var current = first;

            while (current != null)
            {
                counter++;
                if (counter == count - k + 1) kPointer = current;
                current = current.next;
            }

            return kPointer.value;
        }

        public int getKthFromEnd2(int k)
        {
            if (k < 1) throw new IndexOutOfRangeException();

            var slowCounter = first;
            var fastCounter = first;
            for (int i = 0; i < k; i++)
            {
                fastCounter = fastCounter.next;
                if (fastCounter == null) throw new IndexOutOfRangeException();
            }
            while (fastCounter != null)
            {
                slowCounter = slowCounter.next;
                fastCounter = fastCounter.next;
            }
            return slowCounter.value;
        }

        public string getMiddle()
        {
            if (count < 1) throw new InvalidOperationException();

            Node slowCounter = first, fastCounter = first.next;
            bool even = false;
            while (fastCounter != null)
            {
                fastCounter = fastCounter.next;
                if (even) slowCounter = slowCounter.next;
                even = !even;
            }
            if (!even) return slowCounter.value.ToString();
            else return slowCounter.value.ToString() + ", " + slowCounter.next.value.ToString();
        }

    }
}

