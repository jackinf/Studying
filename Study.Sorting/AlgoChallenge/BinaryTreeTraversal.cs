using System.Collections.Generic;

namespace Study.Algo.AlgoChallenge
{
    public class BinaryTreeTraversal
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        public class Tree
        {
            public Node Root { get; set; }

            public void Insert(int value)
            {
                Node node = new Node {Value = value};
                var current = Root;
                if (current == null)
                {
                    Root = node;
                    return;
                }

                while (true)
                {
                    if (value < current.Value)
                    {
                        if (current.Left == null)
                        {
                            current.Left = node;
                            return;
                        }
                        current = current.Left;
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = node;
                            return;
                        }
                        current = current.Right;
                    }
                }
            }

            public IEnumerable<int> Inorder(Node root)
            {
                if (root != null)
                {
                    foreach (var i in Inorder(root.Left)) yield return i;
                    yield return root.Value;
                    foreach (var i in Inorder(root.Right)) yield return i;
                }
            }

            public IEnumerable<int> Preorder(Node root)
            {
                if (root != null)
                {
                    yield return root.Value;
                    foreach (var i in Preorder(root.Left)) yield return i;
                    foreach (var i in Preorder(root.Right)) yield return i;
                }
            }

            public IEnumerable<int> Postorder(Node root)
            {
                if (root != null)
                {
                    foreach (var i in Postorder(root.Left)) yield return i;
                    foreach (var i in Postorder(root.Right)) yield return i;
                    yield return root.Value;
                }
            }
        }
    }
}