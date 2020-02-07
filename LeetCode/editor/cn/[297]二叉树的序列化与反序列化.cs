//序列化是将一个数据结构或者对象转换为连续的比特位的操作，进而可以将转换后的数据存储在一个文件或者内存中，同时也可以通过网络传输到另一个计算机环境，采取相反方
//式重构得到原数据。 
//
// 请设计一个算法来实现二叉树的序列化与反序列化。这里不限定你的序列 / 反序列化算法执行逻辑，你只需要保证一个二叉树可以被序列化为一个字符串并且将这个字符串
//反序列化为原始的树结构。 
//
// 示例: 
//
// 你可以将以下二叉树：
//
//    1
//   / \
//  2   3
//     / \
//    4   5
//
//序列化为 "[1,2,3,null,null,4,5]" 
//
// 提示: 这与 LeetCode 目前使用的方式一致，详情请参阅 LeetCode 序列化二叉树的格式。你并非必须采取这种方式，你也可以采用其他的方法解决这
//个问题。 
//
// 说明: 不要使用类的成员 / 全局 / 静态变量来存储状态，你的序列化和反序列化算法应该是无状态的。 
// Related Topics 树 设计


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
public class Codec {

        // 前序遍历, 根左右
        // 输出成[1,2,3,4]型字符串
        public string serialize(TreeNode root)
        {
            StringBuilder   s = new StringBuilder();
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root == null)
                return "[]";

            q.Enqueue(root);
            s.Append("[");

            while (q.Count != 0)
            {
                TreeNode curr = q.Dequeue();

                if (curr == null)
                    s.Append(",null");
                else
                {
                    // 第一个节点值前没逗号
                    if (curr == root)
                        s.Append(curr.val);
                    else
                        s.Append("," + curr.val);
                    // 前序:根左右
                    q.Enqueue(curr.left);
                    q.Enqueue(curr.right);
                }
            }

            s.Append("]");
            return s.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            // 去掉首尾的[], 然后按照,分割成字符串列表
            string[] s = data.Replace("[", "").Replace("]", "").Split(',');
            // 计数节点
            int count = 1;

            if (s[0].Equals("null") || s[0].Equals(""))
                return null;

            Queue<TreeNode> q = new Queue<TreeNode>();
            // 解析第一个节点
            TreeNode root = new TreeNode(int.Parse(s[0]));
            
            q.Enqueue(root);
            
            while (q.Count != 0 && count < s.Length)
            {
                TreeNode curr = q.Dequeue();
                // 如果s[count]节点不为null, 就创建一个新节点放入队列
                if (!s[count].Equals("null"))
                {
                    curr.left = new TreeNode(int.Parse(s[count]));
                    q.Enqueue(curr.left);
                }
                count++;
                
                // // 如果s[count]节点不为null, 就创建一个新节点放入队列
                if (!s[count].Equals("null"))
                {
                    curr.right = new TreeNode(int.Parse(s[count]));
                    q.Enqueue(curr.right);
                }
                count++;
            }

            return root;
        }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
//leetcode submit region end(Prohibit modification and deletion)
