using System.Collections.Generic;

namespace Study.Algo.AlgoChallenge
{
    /// <summary>
    /// Given an integer value and a pointer to the head of the linked list,
    /// delete all the nodes from the list that are greater than the specified value.
    /// </summary>
    public class LinkedListDeleteGreaterValueNodes
    {
        public static void Run(LinkedList<int> list, int maxAllowedValue)
        {
            if (list.Count == 0)
                return;

            LinkedListNode<int> nextNode = list.First;
            do
            {
                if (nextNode.Value > maxAllowedValue)
                {
                    var temp = nextNode;
                    nextNode = nextNode.Next;
                    list.Remove(temp);
                }
                else
                    nextNode = nextNode.Next;
            } while (nextNode != null);
        }
    }
}