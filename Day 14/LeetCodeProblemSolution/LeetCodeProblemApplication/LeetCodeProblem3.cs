using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblemApplication
{

    public class LeetCodeProblem3
    {
        //141. Linked List Cycle
        //Verified in Leetcode problem 3

        public class ListNode  
        {
            public int Val;
            public ListNode Next;

            public ListNode(int val)
            {
                Val = val;
            }
        }
        public async static Task<ListNode> CreateList(int[] data)
        {
            ListNode head = null;
            ListNode current = null;

            foreach (int val in data)
            {
                ListNode newNode = new ListNode(val);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    current.Next = newNode;
                }
                current = newNode;
            }

            return head;
        }
        
        //Main Logic verified in Leetcode
        public async static Task<bool> LinkedListLoopFinder(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();
            while (head != null)
            {
                if (list.Contains(head)) return true;
                list.Add(head);
                head = head.Next;
            }
            return false;
        }

        public async static void LinkedListProblem()
        {
            int[] listData = { 3, 2, 0, -1 };
            ListNode head = await CreateList(listData);
            bool hasLoop = await LinkedListLoopFinder(head);
            Console.WriteLine(hasLoop);
        }
        public static void Main(string[] args)
        {
            LinkedListProblem();
        }

    }
}
