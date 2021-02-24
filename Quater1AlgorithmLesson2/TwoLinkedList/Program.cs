using System;

namespace ClassDoubleLinkedList
{
    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }

            public Node(int value)
            {
                Value = value;
            }
            public Node() { } 
           
            
        }

        public interface IlinkedList
        {
            //return count of list items
            int GetCount();

            //add new item of list
            void AddNode(int value);
            
            //add new item of list after specified
            void AddNodeAfter(Node node, int value);

            //remove item of list by index
            void RemoveNode(int index);

            //remove specified item of list
            void RemoveNode(Node node);

            //find item of list
            Node FindNode(int searchValue);


        }

       
        class TwoLinkedListImplementation : IlinkedList
        {
            public Node head;
            public Node tail;                                  

            //return count of list items
            public int GetCount()
            {
                int count = 0;
                Node curNode = head;
                while (curNode != null)
                {
                    count++;
                    curNode = curNode.NextNode;
                }
                return count;
            }

            //add new item of list
            public void AddNode(int value)
            {
                Node newNode = new Node(value);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    tail.NextNode = newNode;
                    newNode.PrevNode = tail;
                }
                tail = newNode;

            }

            //add new item of list after specified
            public void AddNodeAfter(Node node, int value)
            {
                Node curNode = head;

                while (curNode != node)
                {
                    curNode = curNode.NextNode;
                }

                Node newNode = new Node(value);

                switch (curNode)
                {
                    
                    case Node n when n == tail:
                        tail.NextNode = newNode;
                        newNode.PrevNode = tail;
                        tail = newNode;
                        break;

                    default:
                        newNode.NextNode = curNode.NextNode;
                        curNode.NextNode = newNode;
                        newNode.PrevNode = curNode;
                        curNode = newNode;
                        break;

                }

            }

            //remove item of list by index
            public void RemoveNode(int index)
            {

                if (index == 0)
                {
                    Node newHead = head.NextNode;
                    head.NextNode = null;
                    head = newHead;
                } else if (index == GetCount() - 1)
                {
                    Node newHead = tail.PrevNode;
                    newHead.NextNode = null;
                    tail.PrevNode = null;
                    tail = newHead;
                } else

                {
                    int curIndex = 0;
                    Node curNode = head;
                    while (curNode != null)
                    {
                        if (curIndex == index)
                        {
                            Node curnNodePrev = curNode.PrevNode;
                            Node curnNodeNext = curNode.NextNode;
                            if (curnNodePrev != null)
                            {
                                curnNodePrev.NextNode = curnNodeNext;
                            }
                            if (curnNodeNext != null)
                            {
                                curnNodeNext.PrevNode = curnNodePrev;
                            }
                            
                        }

                        curNode = curNode.NextNode;
                        curIndex++;
                    }
                }

            }



            //remove specified item of list
            public void RemoveNode(Node node) 
            {
                if (node == head)
                {
                    Node newHead = head.NextNode;
                    head.NextNode = null;
                    head = newHead;
                }
                else
                {
                    Node curNode = head;
                    while (curNode != null)
                    {
                        if (curNode == node)
                        {
                            Node curnNodePrev = curNode.PrevNode;
                            Node curnNodeNext = curNode.NextNode;
                            if (curnNodePrev != null)
                            {
                                curnNodePrev.NextNode = curnNodeNext;
                            }
                            if (curnNodeNext != null)
                            {
                                curnNodeNext.PrevNode = curnNodePrev;
                            }

                        }
                        curNode = curNode.NextNode;
                    }
                }     
            }


            //find item of list
            public Node FindNode(int searchValue)
            {
                Node curNode = head;
                while (curNode != null)
                {
                    if (curNode.Value == searchValue)
                    {
                        return curNode;
                    }
                    curNode = curNode.NextNode;
                };

                return null;
            }
        }


        static void OutPutListValues(TwoLinkedListImplementation testTwoLinkedList)
        {
            Node curNode = testTwoLinkedList.head;
            curNode = testTwoLinkedList.head;
            while (curNode != null)
            {
                Console.Write($"{ curNode?.Value } ");
                curNode = curNode.NextNode;
            };
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            const int countAdditionalNote = 5;

            TwoLinkedListImplementation testTwoLinkedList = new TwoLinkedListImplementation();

            //testing method AddNode
            for (int i = 1; i <= countAdditionalNote; i++)
            {  
                testTwoLinkedList.AddNode(i);
            };

            Console.WriteLine("Testing method AddNode:");
            Console.Write("Input TwoLinkedList Values: 1 2 3 4 5; Expected: 1 2 3 4 5; Result: ");
            OutPutListValues(testTwoLinkedList);


            //testing return count of list items
            Console.WriteLine();
            Console.WriteLine("Testing method GetCount:");
            Console.Write($"Input: TwoLinkedList Of 5 items; Expected: 5; Result: { testTwoLinkedList.GetCount() }");
            Console.WriteLine();


            //testing AddNodeAfter 
            Console.WriteLine();
            Console.WriteLine("Testing method AddNodeAfter:");
            testTwoLinkedList.AddNodeAfter(testTwoLinkedList.head, 6);
            Console.Write("Input specified node = head, value = 6; Expected: 1 6 2 3 4 5; Result: ");
            OutPutListValues(testTwoLinkedList);

            testTwoLinkedList.AddNodeAfter(testTwoLinkedList.tail, 7);;
            Console.Write("Input specified node = tail, value = 7; Expected: 1 6 2 3 4 5 7; Result: ");
            OutPutListValues(testTwoLinkedList);


            //testing remove item of list by index
            Console.WriteLine();
            Console.WriteLine("Testing method RemoveNode(int index):");
            testTwoLinkedList.RemoveNode(1);
            Console.Write("Input index = 1; Expected: 1 2 3 4 5 7; Result: ");
            OutPutListValues(testTwoLinkedList);

            testTwoLinkedList.RemoveNode(5);
            Console.Write("Input index = 5; Expected: 1 2 3 4 5; Result: ");
            OutPutListValues(testTwoLinkedList);


            //testing remove specified item of list
            Console.WriteLine();
            Console.WriteLine("Testing method RemoveNode(Node node):");
            testTwoLinkedList.RemoveNode(testTwoLinkedList.tail);
            Console.Write("specified item = tail; Expected: 1 2 3 4 ; Result: ");
            OutPutListValues(testTwoLinkedList);

            testTwoLinkedList.RemoveNode(testTwoLinkedList.head);
            Console.Write("specified item = head; Expected: 2 3 4; Result: ");
            OutPutListValues(testTwoLinkedList);

            testTwoLinkedList.RemoveNode(testTwoLinkedList.head.NextNode);
            Console.Write("specified item = head.NextNode; Expected: 2 4; Result: ");
            OutPutListValues(testTwoLinkedList);


            //testing find item of list
            Console.WriteLine();
            Console.WriteLine("Testing method FindNode(int searchValue):");
            Console.Write("specified int searchValue = 5; Expected: Item is not found ; Result: ");
            Console.Write((testTwoLinkedList.FindNode(5)?.Value ?? -999999) == -999999 ? "Item is not found" : testTwoLinkedList.FindNode(5)?.Value.ToString());

            Console.WriteLine();
            Console.Write("specified int searchValue = 5; Expected: 4; Result: ");
            Console.Write((testTwoLinkedList.FindNode(4)?.Value ?? -999999) == -999999 ? "Item is not found" : testTwoLinkedList.FindNode(4)?.Value.ToString());
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
