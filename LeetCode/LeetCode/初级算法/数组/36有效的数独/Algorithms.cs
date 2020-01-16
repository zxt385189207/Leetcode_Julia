/*
判断一个 9x9 的数独是否有效。只需要根据以下规则，验证已经填入的数字是否有效即可。

数字 1-9 在每一行只能出现一次。
数字 1-9 在每一列只能出现一次。
数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。


数独部分空格内已填入了数字，空白格用 '.' 表示。

示例 1:

输入:
[
  ["5","3",".",".","7",".",".",".","."],
  ["6",".",".","1","9","5",".",".","."],
  [".","9","8",".",".",".",".","6","."],
  ["8",".",".",".","6",".",".",".","3"],
  ["4",".",".","8",".","3",".",".","1"],
  ["7",".",".",".","2",".",".",".","6"],
  [".","6",".",".",".",".","2","8","."],
  [".",".",".","4","1","9",".",".","5"],
  [".",".",".",".","8",".",".","7","9"]
]
输出: true
示例 2:

输入:
[
  ["8","3",".",".","7",".",".",".","."],
  ["6",".",".","1","9","5",".",".","."],
  [".","9","8",".",".",".",".","6","."],
  ["8",".",".",".","6",".",".",".","3"],
  ["4",".",".","8",".","3",".",".","1"],
  ["7",".",".",".","2",".",".",".","6"],
  [".","6",".",".",".",".","2","8","."],
  [".",".",".","4","1","9",".",".","5"],
  [".",".",".",".","8",".",".","7","9"]
]
输出: false
解释: 除了第一行的第一个数字从 5 改为 8 以外，空格内其他数字均与 示例1 相同。
     但由于位于左上角的 3x3 宫内有两个 8 存在, 因此这个数独是无效的。
说明:

一个有效的数独（部分已被填充）不一定是可解的。
只需要根据以上规则，验证已经填入的数字是否有效即可。
给定数独序列只包含数字 1-9 和字符 '.' 。
给定数独永远是 9x9 形式的。

来源：力扣（LeetCode）
链接：https://leetcode-cn.com/problems/valid-sudoku
著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core
{
    public partial class Algorithms
    {
        public bool IsValidSudoku(char[][] board)
        {
            if (board == null || board.Length == 0)
            {
                return false;
            }

            Dictionary<char, int>[] row = new Dictionary<char, int>[9]; //行
            Dictionary<char, int>[] col = new Dictionary<char, int>[9]; //列
            Dictionary<char, int>[] box = new Dictionary<char, int>[9]; //宫
            //初始化哈希表
            for (int i = 0; i < 9; i++)
            {
                row[i] = new Dictionary<char, int>();
                col[i] = new Dictionary<char, int>();
                box[i] = new Dictionary<char, int>();
            }

            for (int i = 0; i < 9; i++) // 遍历每行
            {
                for (int j = 0; j < 9; j++) // 遍历列
                {
                    //当前没有字符 抬走 下一个
                    if (board[i][j].Equals('.'))
                    {
                        continue;
                    }

                    // 计算宫的索引
                    // 这个就是简单的规律，i是行标，j是列标。
                    // 行标决定一组block的起始位置（因为block为3行，所以除3取整得到组号，又因为每组block为3个，所以需要乘3），
                    // 列标再细分出是哪个block（因为block是3列，所以除3取整）
                    int k = i / 3 * 3 + j / 3;
                    //当前元素对应的行集合,列集合,宫集合,都不重复
                    if (!row[i].ContainsKey(board[i][j]) 
                        && !col[j].ContainsKey(board[i][j]) 
                        && !box[k].ContainsKey(board[i][j]))
                    {
                        row[i].Add(board[i][j], i);
                        col[j].Add(board[i][j], j);
                        box[k].Add(board[i][j], k);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}