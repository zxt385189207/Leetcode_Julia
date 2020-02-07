//给定一个 N 叉树，找到其最大深度。 
//
// 最大深度是指从根节点到最远叶子节点的最长路径上的节点总数。 
//
// 例如，给定一个 3叉树 : 
//
// 
//
// 
//
// 
//
// 我们应返回其最大深度，3。 
//
// 说明: 
//
// 
// 树的深度不会超过 1000。 
// 树的节点总不会超过 5000。 
// Related Topics 树 深度优先搜索 广度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
public class Solution {
      // 递归
        public int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            int max = 0;
            foreach (var child in root.children)
            {
                max = Math.Max(max, MaxDepth(child));
            }
            
            // 叶子节点 = 1 + Max(0 , 0)
            return max + 1;
        }
        /// <summary>
        /// 迭代 BFS层次遍历思想(宽度优先搜索 又称广度优先搜索)
        /// 所有因为展开节点而得到的子节点都会被加进一个先进先出的队列中(队列或者链表)。
        /// 时间复杂度O(n)
        /// 空间复杂度:线性表最差O(n)、二叉树完全平衡最好O(logn)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth1(Node root)
        {            
            if (root == null)
            {
                return 0;
            }

            //BFS的层次遍历思想，记录二叉树的层数，
            //横向遍历完，层数即为最大深度
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int maxDepth = 0;

            while (queue.Count != 0)
            {
                // 记录深度
                maxDepth++;
                // 队列里的个数
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    // 从左到右依次出队, 
                    Node node = queue.Dequeue();
                    foreach (var child in node.children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return maxDepth;
            
        }
        
        /// <summary>
        /// 迭代, DFS的层次遍历思想(深度优先搜索)
        /// 对每一个可能的分支路径深入到不能再深入为止, 用的一个先进后出的栈
        /// 时间复杂度O(n)
        /// 空间复杂度:线性表最差O(n)、二叉树完全平衡最好O(logn)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth2(Node root) 
        {
        
            if (root == null)
            {
                return 0;
            }

            Stack<KeyValuePair<Node, Int32>> stack = new Stack<KeyValuePair<Node, Int32>>();

            // 放入根节点, 深度为1
            stack.Push(new KeyValuePair<Node, Int32>(root, 1));

            int maxDepth = 0;
            // DFS实现前序遍历，每个节点记录其所在深度
            // 栈中元素不为0 继续遍历
            while (stack.Count != 0)
            {
                KeyValuePair<Node, Int32> pair = stack.Pop();
                Node node = pair.Key;

                //DFS过程不断比较更新最大深度
                maxDepth = Math.Max(maxDepth, pair.Value);
                //记录当前节点所在深度
                int curDepth = pair.Value;

                // 当前节点的子节点入栈，同时深度+1
                // 先放最右子节点,因为是stack 先进后出, 后入先出
                foreach (var child in node.children)
                {
                    stack.Push(new KeyValuePair<Node, Int32>(child, curDepth + 1));
                }
            }

            return maxDepth;
        }
}
//leetcode submit region end(Prohibit modification and deletion)
