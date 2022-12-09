using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeMirroring
{
    /// <summary>
    /// Используется <see cref="Stack{T}"/> для хранения промежуточных результатов.
    /// Плюс такой реализации в том, что, в отличие от рекурсивного алгоритма (<see cref="BTreeMirrorRecursionStrategy"/>), поддерживаются большие деревья.
    /// Минус - при небольших размерах дерева менее эффективен, чем рекурсия. Для организации стека организуется Generic тип, который так же требует дополнительной памяти и обработки (увеличение размера, копирование массива и т.п.). Соответственно для работы с узлами дерева появляется дополнительный слой методов (pop/push), вызов которых чуть но отнимает ресурсов.
    /// </summary>
    public class BTreeMirrorStackStrategy : IBTreeMirrorStrategy
    {
        public void Mirror(Node root)
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
