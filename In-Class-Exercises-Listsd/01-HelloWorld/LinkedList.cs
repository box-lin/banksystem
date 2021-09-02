using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HelloWorld
{
    public class LinkedList
    {
        private LinkedListNode head;
        private int size;

        public LinkedList()
        {
            head = null;
            size = 0;
        }
        
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
            size++;
        }

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
                    res += ",";
                }
            }
            return "["+res+"]";
        }
    }

    //Node component
    class LinkedListNode
    {
        public int val;
        public LinkedListNode next;

        public LinkedListNode(int val)
        {
            this.val = val;
        }
    }
}
