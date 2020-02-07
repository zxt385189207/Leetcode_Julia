//给定一个 N 叉树，返回其节点值的前序遍历。 
//
// 例如，给定一个 3叉树 : 
//
// 
//
// 
//
// 
//
// 返回其前序遍历: [1,3,5,6,2,4]。 
//
// 
//
// 说明: 递归法很简单，你可以使用迭代法完成此题吗? Related Topics 树


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

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
public class Solution {
    List<int> list = new List<int>();
    // 前序遍历
    // 递归
    public IList<int> Preorder(Node root)
    {
        if (root==null)
        {
            return list;
        }
        list.Add(root.val);
            
        foreach (var child in root.children)
        {
            Preorder(child);
        }
        return list;
    }
    // 迭代
    public IList<int> Preorder1(Node root)
    {
        if (root==null)
        {
            return list;
        }
        Stack<Node> stack = new Stack<Node>();

        stack.Push(root);

        while (stack.Count!=0)
        {
            var curr = stack.Pop();
            list.Add(curr.val);
                
            // 先压最右边的
            foreach (var child in curr.children.Reverse())
            {
                stack.Push(child);
            }
        }
        return list;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
