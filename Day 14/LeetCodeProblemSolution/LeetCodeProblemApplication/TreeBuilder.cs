using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblemApplication
{
    public class TreeBuilder
    {
        public TreeNode BuildTree(int[] values)
        {
            if (values == null || values.Length == 0)
            {
                return null;
            }

            var queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(values[0]);
            queue.Enqueue(root);

            int i = 1;
            while (queue.Count > 0 && i < values.Length)
            {
                var current = queue.Dequeue();

                // Check for null values in the input array
                if (values[i] != -1)
                {
                    current.Left = new TreeNode(values[i]);
                    queue.Enqueue(current.Left);
                }
                i++;

                if (i < values.Length && values[i] != -1)
                {
                    current.Right = new TreeNode(values[i]);
                    queue.Enqueue(current.Right);
                }
                i++;
            }

            return root;
        }
    }
}
