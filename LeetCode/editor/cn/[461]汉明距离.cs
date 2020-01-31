//两个整数之间的汉明距离指的是这两个数字对应二进制位不同的位置的数目。 
//
// 给出两个整数 x 和 y，计算它们之间的汉明距离。 
//
// 注意： 
//0 ≤ x, y < 231. 
//
// 示例: 
//
// 
//输入: x = 1, y = 4
//
//输出: 2
//
//解释:
//1   (0 0 0 1)
//4   (0 1 0 0)
//       ↑   ↑
//
//上面的箭头指出了对应二进制位不同的位置。
// 
// Related Topics 位运算


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 汉明距离是使用在数据传输差错控制编码里面的，
    // 汉明距离是一个概念，它表示两个（相同长度）字对应位不同的数量，
    // 我们以d（x,y）表示两个字x,y之间的汉明距离。对两个字符串进行异或运算，
    // 并统计结果为1的个数，那么这个数就是汉明距离。
    public int HammingDistance(int x, int y)
    {
        int i     = x ^ y;
        int count = 0;
        while (i != 0)
        {
            // 判断最后一位是否为1
            if ((i & 1) == 1)
            {
                count++;
            }
            // 右移一位
            i = i >> 1;
        }

        return count;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
