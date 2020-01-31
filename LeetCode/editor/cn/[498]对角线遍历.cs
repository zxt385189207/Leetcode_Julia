//给定一个含有 M x N 个元素的矩阵（M 行，N 列），请以对角线遍历的顺序返回这个矩阵中的所有元素，对角线遍历如下图所示。 
//
// 
//
// 示例: 
//
// 输入:
//[
// [ 1, 2, 3 ],
// [ 4, 5, 6 ],
// [ 7, 8, 9 ]
//]
//
//输出:  [1,2,4,7,5,3,6,8,9]
//
//解释:
//
// 
//
// 
//
// 说明: 
//
// 
// 给定矩阵中的元素总数不会超过 100000 。 
// 
//


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix)
    {
        
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return new int[0];
        }
        
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int[] res = new int[rows * cols];

        // 横坐标 + 纵坐标 = 定和，在同一对角线上
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (!dic.ContainsKey(r + c))
                {
                    dic[r + c] = new List<int>();
                }

                dic[r + c].Add(matrix[r][c]);
            }
        }

        int index = 0;
        for (int i = 0; i < dic.Count; i++)
        {
            // 奇数是正序输出
            if (i % 2 != 0)
            {
                foreach (var temp in dic[i])
                {
                    res[index] = temp;
                    index++;
                }
            }
            else
            {
                foreach (var temp in dic[i].ToArray().Reverse())
                {
                    res[index] = temp;
                    index++;
                }
            }
        }

        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
