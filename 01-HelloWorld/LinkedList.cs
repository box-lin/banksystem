/// <summary>
/// 
/// Name: Boxiang Lin 
/// ID: 011601661
/// In-Class Exercise 1
/// 
/// </summary>
/// 
using System;
using System.Collections.Generic;
using System.Text;


namespace _01_HelloWorld
{

    /// <summary>
    /// This is a wrapper class of LinkedListNode
    /// </summary>
    public class LinkedList
    {
        private LinkedListNode head;

        //Initialization 
        public LinkedList()
        {
            head = null;
        }
        

        /// <summary>
        /// Wrap the value pass-in to the LinkedListNode and let the current tail point to it 
        /// </summary>
        /// <param name="val"></param>
        public void add(int val)
        {
            LinkedListNode node = new LinkedListNode(val);
            if (head == null)
            {
                head = node;
            }
            else
            {
                LinkedListNode cur = head;
                while(cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = node;
            }
        }


        /// <summary>
        /// An override toString method that traverses through the linked list and concatenate each val to a res string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            LinkedListNode cur = head;
            string res = "";
            while (cur != null)
            {
                res += cur.val;
                cur = cur.next;
                if(cur != null)
                {
                    res += "->";
                }
            }
            return "["+res+"]";
        }
    }
}
