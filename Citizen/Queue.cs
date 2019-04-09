using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizen
{
    class Queue:IEnumerable
    {
        private Node _head = null;
        private Node _tail = null;
        public void Add(Citizen man)
        {
            Node nodePassport = _tail;
            if (_head == null)
            {
                Node node = new Node();
                node.Citizen = man;
                _head = node;
                _tail = node;
                node.Index = 0;
                return;
            }
            else
            {
                while (nodePassport != null)
                {
                    if (nodePassport.Citizen.Passport.Equals(man.Passport))
                    {
                        Console.WriteLine("Number of passport №{0} is exist in list!",man.Passport);
                        return;
                    }
                    else
                    {
                        nodePassport = nodePassport.Previous;
                    }
                }
            }
            if (nodePassport == null)
            {
                if (man.Age < 65)
                {
                    Node node = new Node();
                    node.Citizen = man;

                    node.Previous = _tail;
                    node.Next = null;

                    node.Index = _tail.Index + 1;
                    _tail.Next = node;
                    _tail = node;
                }
                else
                {
                    Node node = new Node();
                    node.Citizen = man;

                    Node current = _tail;
                    while (current != null)
                    {
                        if ((node.Citizen.Age >= 65) && (current.Citizen.Age >= 65))
                        {
                            if (current == _tail)
                            {
                                node.Previous = _tail;
                                node.Next = null;

                                node.Index = _tail.Index + 1;
                                _tail.Next = node;
                                _tail = node;
                                return;
                            }
                            else
                            {
                                Node temp = current;
                                node.Next = current.Next;
                                node.Previous = current;
                                temp.Next = node;
                                return;
                            }
                        }
                        else
                        {
                            current = current.Previous;
                        }
                    }
                    if (current == null)
                    {
                        Node temp = _head;
                        _head = node;
                        node.Next = temp;
                        node.Next.Previous = node;
                    }
                }
            }

        }
        public Node ReturnLast()
        {
            if (_head == null)
            {
                return null;
            }
            else
            {
                return _tail;
            }
        }

        public int Contains(Citizen citizen)
        {
            if (_head == null)
            {
                return -1;
            }
            else
            {
                Node current = _head;
                while (current != null)
                {
                    if (current.Citizen.Equals(citizen))
                    {
                        return current.Index;                       
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
                return -1;
            }
        }
        public void Clear()
        {
            _head = null;
            _tail = null;
      
        }
        public void RemoveFirst ()
        {
            if (_head == null)
            {
                _head = null;
            }
            else
            {
                if (_head.Next == null)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _head = _head.Next;
                }
            }

        }
        public void Remove (Citizen citizen)
        {
            Node prev = null;
            Node current = _head;

            while (current != null)
            {
                if (current.Citizen.Equals(citizen))
                {
                    if (prev != null)
                    {
                        prev.Next = current.Next;
                    }
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {
                yield return current.Citizen;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
