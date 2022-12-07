using System;

namespace BinaryTreeMirroring
{
    public class Node
    {
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Value { get; private set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
