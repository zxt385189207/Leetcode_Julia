//设计一个找到数据流中第K大元素的类（class）。注意是排序后的第K大元素，不是第K个不同的元素。 
//
// 你的 KthLargest 类需要一个同时接收整数 k 和整数数组nums 的构造器，它包含数据流中的初始元素。每次调用 KthLargest.add，返
//回当前数据流中第K大的元素。 
//
// 示例: 
//
// 
//int k = 3;
//int[] arr = [4,5,8,2];
//KthLargest kthLargest = new KthLargest(3, arr);
//kthLargest.add(3);   // returns 4
//kthLargest.add(5);   // returns 5
//kthLargest.add(10);  // returns 5
//kthLargest.add(9);   // returns 8
//kthLargest.add(4);   // returns 8
// 
//
// 说明: 
//你可以假设 nums 的长度≥ k-1 且k ≥ 1。 
// Related Topics 堆


//leetcode submit region begin(Prohibit modification and deletion)
    // 执行效率似乎不理想
    class KthLargest
    {
        private TreeNode root;
        private int      kth;
        
        public class TreeNode
        {
            public int      val;
            public TreeNode left;
            public TreeNode right;

            // 该节点值出现次数
            public int cnt;

            public TreeNode(int x)
            {
                val = x;
                cnt = 1;
            }
        }
        
        // 构建树
        private TreeNode Insert(TreeNode root, int n)
        {
            if (root == null)
            {
                return new TreeNode(n);
            }

            if (n < root.val)
            {
                root.left = Insert(root.left, n);
            }
            else if (n > root.val)
            {
                root.right = Insert(root.right, n);
            }

            root.cnt++;
            return root;
        }

        // 二叉搜索树的搜索
        private TreeNode Search(TreeNode root, int n)
        {
            if (root == null) 
                return null;
            
            // 左子树节点数
            int leftChildCount = root.left == null ? 0 : root.left.cnt;
            
            // 右子树节点数
            int rightChildCount = root.right == null ? 0 : root.right.cnt;
            
            // 根节点出现次数
            int rootCount = root.cnt - rightChildCount - leftChildCount;
            
            // 先在右子树中搜索第n大的节点，如果n小于等于右子树中节点数，说明第n大的节点在右子树
            if (n <= rightChildCount)
            {
                return Search(root.right, n);
            }
            // 如果n大于右子树节点数加根节点出现次数，那么第n大的节点在左子树

            if (n > rightChildCount + rootCount)
            {
                return Search(root.left, n - rightChildCount - rootCount);
            }
            
            // 如果n等于右子树节点数加根节点出现次数，那么第n大的节点为根节点
            return root;
        }

        // 构造函数, 将数组以二叉搜索树的结构建立一颗树
        public KthLargest(int k, int[] nums)
        {
            kth = k;
            for (int i = 0; i < nums.Length; i++)
            {
                // 以数组第一个数为根节点
                root = Insert(root, nums[i]);
            }
        }

        public int Add(int val)
        {
            root = Insert(root, val);
            return Search(root, kth).val;
        }
    }

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
//leetcode submit region end(Prohibit modification and deletion)
