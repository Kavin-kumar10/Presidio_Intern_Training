using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblemApplication
{
    public class Node
    {
        public int Val { get; set; }
        public Node Next { get; set; }

        public Node(int val)
        {
            Val = val;
        }
    }

    public class LinkedList
    {
        public Node Head { get; set; }

        public void Add(int val)
        {
            var newNode = new Node(val);
            newNode.Next = Head; 
            Head = newNode;
        }

    }
    
}
