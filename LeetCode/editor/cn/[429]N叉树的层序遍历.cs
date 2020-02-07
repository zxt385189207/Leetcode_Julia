//给定一个 N 叉树，返回其节点值的层序遍历。 (即从左到右，逐层遍历)。 
//
// 例如，给定一个 3叉树 : 
//
// 
//
// 
//
// 
//
// 返回其层序遍历: 
//
// [
//     [1],
//     [3,2,4],
//     [5,6]
//]
// 
//
// 
//
// 说明: 
//
// 
// 树的深度不会超过 1000。 
// 树的节点总数不会超过 5000。 
// Related Topics 树 广度优先搜索


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
    // 迭代
    public IList<IList<int>> LevelOrder(Node root)
    {
        List<IList<int>> list = new List<IList<int>>(); //结果数组
        if (root == null)
        {
            return list;
        }
            
        // 节点 层,数据对组成的队列
        Queue<KeyValuePair<Node, int>> queue = new Queue<KeyValuePair<Node, int>>();
        // 将根节点加入队列中
        queue.Enqueue(new KeyValuePair<Node, int>(root, 0));
        // 迭代
        while (queue.Count > 0)
        {
            var kvp = queue.Dequeue();
            // 创建对应层数的数组
            if (list.Count == kvp.Value)
            {
                list.Add(new List<int>());
            }
            // 将当前节点的值添加到对应的层
            list[kvp.Value].Add(kvp.Key.val);

            foreach (var child in kvp.Key.children)
            {
                queue.Enqueue(new KeyValuePair<Node, int>(child, kvp.Value + 1));
            }
        }

        return list;
    }

    // 递归
    public IList<IList<int>> LevelOrder1(Node root)
    {
        List<IList<int>> list = new List<IList<int>>(); 
            
        // 如果null就直接返回 否则开始递归
        return root == null ? list : LevelOrder(root, 0, list);
    }

    // 递归
    private List<IList<int>> LevelOrder(Node node, int level, List<IList<int>> list)
    {
        //当前层没有创建数组
        if (list.Count == level)
        {
            list.Add(new List<int>());
        }

        // 将当前节点的值添加到对应的层
        list[level].Add(node.val);
        foreach (var child in node.children)
        {
            list = LevelOrder(child, level + 1, list);
        }

        return list;
    }

}
//leetcode submit region end(Prohibit modification and deletion)
