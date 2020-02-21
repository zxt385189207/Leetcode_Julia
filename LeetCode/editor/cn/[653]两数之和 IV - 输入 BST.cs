//给定一个二叉搜索树和一个目标结果，如果 BST 中存在两个元素且它们的和等于给定的目标结果，则返回 true。 
//
// 案例 1: 
//
// 
//输入: 
//    5
//   / \
//  3   6
// / \   \
//2   4   7
//
//Target = 9
//
//输出: True
// 
//
// 
//
// 案例 2: 
//
// 
//输入: 
//    5
//   / \
//  3   6
// / \   \
//2   4   7
//
//Target = 28
//
//输出: False
// 
//
// 
// Related Topics 树


//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    // 递归+哈希
    public bool FindTarget(TreeNode root, int k)
    {
        HashSet<int> set = new HashSet<int>();
        return Find(root, k, set);
    }

    public bool Find(TreeNode root, int k, HashSet<int> set)
    {
        if (root == null)
            return false;
        if (set.Contains(k - root.val))
            return true;

        set.Add(root.val);

        return Find(root.left, k, set) || Find(root.right, k, set);
    }

    // 迭代
    public bool fFindTarget2(TreeNode root, int k)
    {
        HashSet<int>    set   = new HashSet<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            if (set.Contains(k - node.val))
                return true;
            set.Add(node.val);
            if (node.right != null)
                queue.Enqueue(node.right);
            if (node.left != null)
                queue.Enqueue(node.left);
        }

        return false;
    }

    // BST序列化+对撞指针
    public bool FindTarget3(TreeNode root, int k)
    {
        List<int> list = new List<int>();
        Inorder(root, list);
        // 首位指针
        int l = 0, r = list.Count - 1;
        while (l < r)
        {
            int sum = list[l] + list[r];
            if (sum == k)
                return true;
            if (sum < k)
                l++;
            else
                r--;
        }

        return false;
    }
    // 中序, 递增排列
    public void Inorder(TreeNode root, List<int> list)
    {
        if (root == null)
            return;
        Inorder(root.left, list);
        list.Add(root.val);
        Inorder(root.right, list);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
