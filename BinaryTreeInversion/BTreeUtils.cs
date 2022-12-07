using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeMirroring
{
    public static class BTreeUtils
    {
        /// <summary>
        /// Используется <see cref="Stack{T}"/> для хранения промежуточных результатов, а не рекурсия.
        /// Код с рекурсией был бы более элегантным, но каждый вызов рекурсивной функции занимает место на стеке, размер которого сильно ограничен по сравнению с кучей. Само входное дерево расположено в куче и теоретически может быть сильно несбалансированным (высота дерева = кол-ву элементов в дереве = кол-ву вложенных вызовов рекурсии).
        /// </summary>
        public static void Mirror(Node root)
        {
            Stack<Node> stack = new Stack<Node>(new[] { root });

            Node nodeToMirror;
            do
            {
                nodeToMirror = stack.Pop();
                if ((nodeToMirror.Left ?? nodeToMirror.Right) == null)
                    continue;

                (nodeToMirror.Left, nodeToMirror.Right) = (nodeToMirror.Right, nodeToMirror.Left);

                if (nodeToMirror.Left != null)
                    stack.Push(nodeToMirror.Left);
                if (nodeToMirror.Right != null)
                    stack.Push(nodeToMirror.Right);
            }
            while (stack.Any());
        }
    }
}
