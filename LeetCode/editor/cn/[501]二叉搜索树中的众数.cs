//给定一个有相同值的二叉搜索树（BST），找出 BST 中的所有众数（出现频率最高的元素）。 
//
// 假定 BST 有如下定义： 
//
// 
// 结点左子树中所含结点的值小于等于当前结点的值 
// 结点右子树中所含结点的值大于等于当前结点的值 
// 左子树和右子树都是二叉搜索树 
// 
//
// 例如： 
//给定 BST [1,null,2,2], 
//
//    1
//    \
//     2
//    /
//   2
// 
//
// 返回[2]. 
//
// 提示：如果众数超过1个，不需考虑输出顺序 
//
// 进阶：你可以不使用额外的空间吗？（假设由递归产生的隐式调用栈的开销不被计算在内） 
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
    // 迭代
    // 中序遍历BST 的结果是一个升序的序列 因此 寻找中序就是寻找最大的相等子序列 1 2 3 4 4 4 5 5 6 7 众数是 4 4 4
    public int[] FindMode1(TreeNode root)
    {
        List<int> list = new List<int>();

        Stack<TreeNode> stack   = new Stack<TreeNode>();
        TreeNode        curr    = root;
        TreeNode pre     = null;
        int             maxcount     = 1;
        int             count = 1;
        while (curr != null || stack.Count > 0)
        {
            // 一直Push左子节点到栈中, 
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }   

            curr = stack.Pop();

            if (preNode != null)
            {
                if (preNode.val == curr.val)
                    count++;
                else
                    count = 1;

                if (maxcount < count)
                {
                    list.Clear();
                    list.Add(curr.val);
                    maxcount = count;
                }
                else if (maxcount == count)
                    list.Add(curr.val);
            }
            else
                list.Add(curr.val);
            
            preNode  = curr;
            curr = curr.right;
        }

        return list.ToArray();
    }

    // 递归
    //历史元素中众数出现的最大次数
    int maxTimes = 0;
    //当前元素出现的次数
    int curTimes = 0;
    //前驱节点
    TreeNode preNode = null;

    public int[] FindMode(TreeNode root)
    {
        List<int> result = new List<int>();
        GetResult(root, result);
        return result.ToArray();
    }
    private void GetResult(TreeNode root, List<int> result)
    {
        if (root == null)
            return;
        // 中序遍历,先进左子节点递归
        GetResult(root.left, result);
        
        if (preNode != null)
            curTimes = root.val == preNode.val ? curTimes + 1 : 1;
        else
            curTimes = 1;

        if (curTimes == maxTimes)
            result.Add(root.val);
        else if (curTimes > maxTimes)
        {
            result.Clear();
            result.Add(root.val);
            maxTimes = curTimes;
        }

        preNode = root;
        // 中序遍历,最后进右子节点递归
        GetResult(root.right, result);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
