using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeMirroring
{
    public interface IBTreeMirrorStrategy
    {
        void Mirror(Node root);
    }
}
