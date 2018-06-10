using System.Linq;
using NUnit.Framework;
using Study.Algo.AlgoChallenge;

namespace Study.Algo.Tests.AlgoChallenge
{
    public class BinaryTreeTraversalTests
    {
        private BinaryTreeTraversal.Tree _tree;

        [SetUp]
        public void SetUp()
        {
            _tree = new BinaryTreeTraversal.Tree();
            _tree.Insert(30);
            _tree.Insert(35);
            _tree.Insert(57);
            _tree.Insert(15);
            _tree.Insert(63);
            _tree.Insert(49);
            _tree.Insert(89);
            _tree.Insert(77);
            _tree.Insert(67);
            _tree.Insert(98);
            _tree.Insert(91);
        }

        [Test]
        public void InorderTraversalTest()
        {
            var result = _tree.Inorder(_tree.Root).ToList();
            Assert.AreEqual("15 30 35 49 57 63 67 77 89 91 98", string.Join(" ", result));
        }

        [Test]
        public void PreorderTraversalTest()
        {
            var result = _tree.Preorder(_tree.Root);
            Assert.AreEqual("30 15 35 57 49 63 89 77 67 98 91", string.Join(" ", result));
        }

        [Test]
        public void PostorderTraversalTest()
        {
            var result = _tree.Postorder(_tree.Root);
            Assert.AreEqual("15 49 67 77 91 98 89 63 57 35 30", string.Join(" ", result));
        }
    }
}