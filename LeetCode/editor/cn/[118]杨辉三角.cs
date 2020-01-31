//给定一个非负整数 numRows，生成杨辉三角的前 numRows 行。 
//
// 
//
// 在杨辉三角中，每个数是它左上方和右上方的数的和。 
//
// 示例: 
//
// 输入: 5
//输出:
//[
//     [1],
//    [1,1],
//   [1,2,1],
//  [1,3,3,1],
// [1,4,6,4,1]
//] 
// Related Topics 数组


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    /// <summary>
    /// 空间复杂度为O(k),公式法，
    /// </summary>
    /// <param name="rowIndex"></param>
    /// <returns></returns>
    public IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> triangle = new List<IList<int>>();

        for (int i = 0; i < numRows; i++)
        {
            triangle.Add(GetYHRow(i));
        }

        return triangle;
    }
        
    public IList<int> GetYHRow(int rowIndex)
    {
        List<int> result = new List<int>();
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
    /// 正常算法
    /// </summary>
    /// <param name="numRows"></param>
    /// <returns></returns>
    public IList<IList<int>> Generate2(int numRows)
    {
        List<IList<int>> triangle = new List<IList<int>>();

        // First base case; if user requests zero rows, they get zero rows.
        if (numRows == 0)
        {
            return triangle;
        }

        // 第一个节点值为1
        triangle.Add(new List<int>());
        triangle[0].Add(1);

        for (int rowNum = 1; rowNum < numRows; rowNum++)
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

        return triangle;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
