using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeMirroring
{
    /// <summary>
    /// Используется рекурсия для обхода всех узлов дерева.
    /// Плюс такой реализации в скорости работы алгоритма, т.к. при каждой итерации по узлам дерева тратится меньше ресурсов, чем у <see cref="BTreeMirrorStackStrategy"/>.
    /// Минус - не подходит для сильно несбалансированных деревеьев с большим количеством уровней. Переход на один уровень вниз сопровождается вложенным вызовом метода, что требует выделения места на стеке. Т.о. есть риск упереться в максимальный размер стека
    /// </summary>
    public class BTreeMirrorRecursionStrategy : IBTreeMirrorStrategy
    {
        public void Mirror(Node root)
        {
            (root.Left, root.Right) = (root.Right, root.Left);

            if(root.Left != null)
                Mirror(root.Left);
            if(root.Right!= null) 
                Mirror(root.Right);
        }
    }
}
