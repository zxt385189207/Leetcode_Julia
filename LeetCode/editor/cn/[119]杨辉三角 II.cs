//给定一个非负索引 k，其中 k ≤ 33，返回杨辉三角的第 k 行。 
//
// 
//
// 在杨辉三角中，每个数是它左上方和右上方的数的和。 
//
// 示例: 
//
// 输入: 3
//输出: [1,3,3,1]
// 
//
// 进阶： 
//
// 你可以优化你的算法到 O(k) 空间复杂度吗？ 
// Related Topics 数组


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 空间复杂度为O(k),公式法，
    /// </summary>
    /// <param name="rowIndex"></param>
    /// <returns></returns>
    public IList<int> GetRow(int rowIndex)
    {
        List<int> result =new List<int>();
        for (int i = 0; i <= rowIndex; ++i)
        {
            result.Add(1);
            for (int j = i - 1; j > 0; --j)
            {
                result[j] += result[j - 1];
            }
        }

        return result;
    }
        
    /// <summary>
    /// 根据118题修改而来
    /// </summary>
    /// <param name="rowIndex"></param>
    /// <returns></returns>
    public IList<int> GetRow1(int rowIndex)
    {
        List<IList<int>> triangle = new List<IList<int>>();

        // 第一个节点值为1
        triangle.Add(new List<int>());
        triangle[0].Add(1);
        if (rowIndex == 0)
        {
            return triangle[0];
        }


        for (int rowNum = 1; rowNum < rowIndex + 1; rowNum++)
        {
            // 当前行
            List<int> row = new List<int>();
            // 上一行
            IList<int> prevRow = triangle[rowNum - 1];

            // 每行第一个元素总是1
            row.Add(1);

            // 根据上一行值计算中间元素值
            for (int j = 1; j < rowNum; j++)
            {
                row.Add(prevRow[j - 1] + prevRow[j]);
            }

            // 最右边元素总是1
            row.Add(1);

            triangle.Add(row);
        }

        return triangle[rowIndex];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
