//给定一个包含 m x n 个元素的矩阵（m 行, n 列），请按照顺时针螺旋顺序，返回矩阵中的所有元素。 
//
// 示例 1: 
//
// 输入:
//[
// [ 1, 2, 3 ],
// [ 4, 5, 6 ],
// [ 7, 8, 9 ]
//]
//输出: [1,2,3,6,9,8,7,4,5]
// 
//
// 示例 2: 
//
// 输入:
//[
//  [1, 2, 3, 4],
//  [5, 6, 7, 8],
//  [9,10,11,12]
//]
//输出: [1,2,3,4,8,12,11,10,9,5,6,7]
// 
// Related Topics 数组


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 外圈逐层遍历
    public IList<int> SpiralOrder(int[][] matrix)
    {
        List<int> ans = new List<int>();
        if (matrix.Length == 0)
            return ans;
        // 左上角坐标是0,0
        // 右下角坐标就是matrix.Length - 1,matrix[0].Length - 1
        int r1 = 0, r2 = matrix.Length - 1;
        int c1 = 0, c2 = matrix[0].Length - 1;
        while (r1 <= r2 && c1 <= c2)
        {
            for (int c = c1; c <= c2; c++)
                ans.Add(matrix[r1][c]);

            for (int r = r1 + 1; r <= r2; r++)
                ans.Add(matrix[r][c2]);

            if (r1 < r2 && c1 < c2)
            {
                for (int c = c2 - 1; c > c1; c--)
                    ans.Add(matrix[r2][c]);

                for (int r = r2; r > r1; r--)
                    ans.Add(matrix[r][c1]);
            }

            r1++;
            r2--;
            c1++;
            c2--;
        }

        return ans;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
