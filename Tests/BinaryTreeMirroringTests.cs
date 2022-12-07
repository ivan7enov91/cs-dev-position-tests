using BinaryTreeMirroring;
using System.Text;
using Xunit.Sdk;

namespace Tests
{
    /// <summary>
    /// Тесты на <see cref="BTreeUtils.Mirror(Node)"/>
    /// </summary>
    public class BinaryTreeMirroringTests
    {
        [Theory]
        [InlineData("1()()", "1()()")]
        [InlineData("1(2()())()", "1()(2()())")]
        [InlineData("1()(2()())", "1(2()())()")]
        [InlineData("1(2()())(3()())", "1(3()())(2()())")]
        [InlineData("1(2(3()())())()", "1()(2()(3()()))")]
        [InlineData("1()(2()(3()()))", "1(2(3()())())()")]
        public void TestMirroring(string inputTreeStr, string expectedTreeStr)
        {
            var treeUnderTest = ParseTree(inputTreeStr);
            BTreeUtils.Mirror(treeUnderTest);

            var expectedTree = ParseTree(expectedTreeStr);

            Assert.True(CheckBTreeEquals(treeUnderTest, expectedTree));
        }

        #region Вспомогательные методы

        /// <summary>
        /// Парсит дерево из его текстового представления вида 1 (2()(3()())) (4()()):
        /// 
        ///             1
        ///           /   \
        ///          2     4
        ///         / \   
        ///    (null)  3 
        /// </summary>
        private static Node ParseTree(string treeStr)
        {
            Node? leftSubtree = default;

            var firstBracketIndex = treeStr.IndexOf('(');
            int value = int.Parse(treeStr.Substring(0, firstBracketIndex));

            var childTreeStr = treeStr.Substring(firstBracketIndex, treeStr.Length - firstBracketIndex);
            bool leftSubtreeDone = false;
            int numOpenedBrackets = 0;
            int nodeStrStartIdx = 0;
            for (int i = 0; i < childTreeStr.Length; i++)
            {
                if (childTreeStr[i] == '(')
                {
                    if (numOpenedBrackets == 0)
                        nodeStrStartIdx = i + 1;
                    numOpenedBrackets++;
                }
                    
                if (childTreeStr[i] == ')')
                    numOpenedBrackets--;

                if(numOpenedBrackets == 0)
                {
                    Node? parsedSubtree = default;
                    if(i > nodeStrStartIdx)
                        parsedSubtree = ParseTree(childTreeStr.Substring(nodeStrStartIdx, i - nodeStrStartIdx));

                    if (leftSubtreeDone)
                    {
                        return new Node(value)
                        {
                            Left = leftSubtree,
                            Right = parsedSubtree
                        };
                    }
                    else
                    {
                        leftSubtree = parsedSubtree;
                        leftSubtreeDone = true;
                    }
                }
            }

            throw new InvalidOperationException("invalid input tree string");
        }

        /// <summary>
        /// Здесь уже допускаем рекурсивные вызовы, т.к. это тесты - их размеры заранее известны и влазят в стек
        /// </summary>
        private static bool CheckBTreeEquals(Node? treeRoot1, Node? treeRoot2)
        {
            if (treeRoot1 == null ^ treeRoot2 == null) 
                return false;

            if (treeRoot1 == null)
                return true;

            if(treeRoot1!.Value != treeRoot2!.Value)
                return false;

            return CheckBTreeEquals(treeRoot1.Left, treeRoot2.Left) && 
                    CheckBTreeEquals(treeRoot1.Right, treeRoot2.Right);
        }

        #endregion
    }
}