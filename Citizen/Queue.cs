using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizen
{
    class Queue : IEnumerable
    {
        
        private Node _head = null;
        private Node _tail = null;

        //private static void RebildingIndex()
        //{
            //Node currentIndex = _head;
            //while (currentIndex.Next != null)
            //{
                //currentIndex.Next.Index = currentIndex.Index + 1;
                //currentIndex = currentIndex.Next;
            //}
        //}
 
        #region AddCitizen
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
            
            
                if (man.Age < Node.AgeOfRetiree)
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
                    Node currentIndex = _head;
                    Node current = _tail;
                    while (current != null)
                    {
                        if ((node.Citizen.Age >= Node.AgeOfRetiree) && (current.Citizen.Age >= Node.AgeOfRetiree))
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
                                
                                while (currentIndex.Next != null)
                                {
                                    currentIndex.Next.Index = currentIndex.Index + 1;
                                    currentIndex = currentIndex.Next;
                                }
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
                        
                        while (currentIndex.Next != null)
                        {
                            currentIndex.Next.Index = currentIndex.Index + 1;
                            currentIndex = currentIndex.Next;
                        }
                    }
                    
                }
            }

        }
        #endregion

        #region ReturnLast
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
        #endregion

        #region Contains
        public int Contains(int numberOfPassport)
        {
            if (_head == null)
            {
                return -1;
            }
            else
            {

                Node current = _head;
                current.Index = 0;
                while (current != null)
                {
                    if (current.Citizen.Passport.Equals(numberOfPassport))
                    {
                        return current.Index;                       
                    }
                    else
                    {
                        if (current.Next != null)
                        {
                            current.Next.Index = current.Index + 1;
                            current = current.Next;
                        }
                        else
                        {
                            current = current.Next;
                        }
                    }
                }
                return -1;
            }
        }
        #endregion

        public void Clear()
        {
            _head = null;
            _tail = null;
      
        }

        #region RemoveFirst
        public void RemoveFirst ()
        {
            if (_head == null)
            {
                _head = null;
                Console.WriteLine("The Queue is empty!");
            }
            else
            {
                Console.WriteLine("Remove the First Citizen is successfull");
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
        #endregion

        #region Remove
        public void Remove (string name)
        {
            if (_head == null)
            {
                _head = null;
                Console.WriteLine("There is no {0} in the Queue!", name);
            }
            else
            {
                Node current = _head;

                while (current != null)
                {
                    if (current.Citizen.Name.Equals(name))
                    {
                        Console.WriteLine("Remove {0} is successfull", name);
                        if (current == _head)
                        {
                            _head = current.Next;
                            return;
                        }
                        else if (current == _tail)
                        {
                            _tail.Previous.Next = null;
                            _tail = current.Previous;
                                                       
                            return;
                        }
                        else 
                        {
                            current.Previous.Next = current.Next;
                            current.Next.Previous = current.Previous;
                            return;
                        }
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
                Console.WriteLine("There is no {0} in the Queue!", name);

            }
        }
        #endregion

        public IEnumerator GetEnumerator()
        {
            Node current = _head;
            if (_head == null)
            {
                Console.WriteLine("The Queue is empty!");
            }
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
