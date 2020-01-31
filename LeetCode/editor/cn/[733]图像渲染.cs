//有一幅以二维整数数组表示的图画，每一个整数表示该图画的像素值大小，数值在 0 到 65535 之间。 
//
// 给你一个坐标 (sr, sc) 表示图像渲染开始的像素值（行 ，列）和一个新的颜色值 newColor，让你重新上色这幅图像。 
//
// 为了完成上色工作，从初始坐标开始，记录初始坐标的上下左右四个方向上像素值与初始坐标相同的相连像素点，接着再记录这四个方向上符合条件的像素点与他们对应四个方
//向上像素值与初始坐标相同的相连像素点，……，重复该过程。将所有有记录的像素点的颜色值改为新的颜色值。 
//
// 最后返回经过上色渲染后的图像。 
//
// 示例 1: 
//
// 
//输入: 
//image = [[1,1,1],[1,1,0],[1,0,1]]
//sr = 1, sc = 1, newColor = 2
//输出: [[2,2,2],[2,2,0],[2,0,1]]
//解析: 
//在图像的正中间，(坐标(sr,sc)=(1,1)),
//在路径上所有符合条件的像素点的颜色都被更改成2。
//注意，右下角的像素没有更改为2，
//因为它不是在上下左右四个方向上与初始点相连的像素点。
// 
//
// 注意: 
//
// 
// image 和 image[0] 的长度在范围 [1, 50] 内。 
// 给出的初始点将满足 0 <= sr < image.length 和 0 <= sc < image[0].length。 
// image[i][j] 和 newColor 表示的颜色值在范围 [0, 65535]内。 
// 
// Related Topics 深度优先搜索


//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    // 并查集
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        if (image == null || image.Length == 0)
        {
            return null;
        }
        
        int rows = image.Length;
        int cols = image[0].Length;
        if (rows == 0 || cols == 0) return null;
        
        // 初始化有颜色的像素
        int[] pre = new int[rows * cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (image[i][j] >= 0)
                {
                    // 有颜色的点, 暂时只归自己掌管
                    pre[i * cols + j] = i * cols + j;
                }
                else
                {
                    // 无颜色点
                    pre[i * cols + j] = -1;
                }
            }
        }
        
        // 将竖直或水平相邻的陆地联结
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (image[i][j] !=image[sr][sc])
                {
                    continue;
                }
                // 水平
                // 如果前和后都是1,则合并他们
                if (j != cols - 1 && image[i][j] == image[i][j + 1] )
                {
                    Join(i * cols + j, i * cols + j + 1, pre);
                }

                // 竖直
                // 如果上和下都是1,则合并他们
                if (i != rows - 1 && image[i][j] == image[i + 1][j])
                {
                    Join(i * cols + j, (i + 1) * cols + j, pre);
                }
            }
        }


        for (int i = 0; i < pre.Length; i++)
        {
            if (pre[i]==-1)
            {
                continue;
            }
            if (Unionsearch(pre[i], pre) == Unionsearch(pre[sr * cols + sc],pre))
            {
                image[i / cols][i % cols] = newColor;
            }
        }

        return image;
    }
    
    private int Unionsearch(int root, int[] pre)
    {
        int son, tmp;
        son = root;
        // 判断当前陆地的上一级是不是掌管者
        // 最后相等的就是掌管一片陆地的掌管者
        while (root != pre[root])
            root = pre[root];

        // 使层级低的大侠直接拜在掌门手下
        // 下次查询只要问一次就能知道是否是同一个掌门
        while (son != root) //路径压缩
        {
            tmp      = pre[son];
            pre[son] = root;
            son      = tmp;
        }

        return root;
    }

    // 判断是否连通，不连通就合并
    private void Join(int root1, int root2, int[] pre)
    {
        int x, y;
        // 掌门1
        x = Unionsearch(root1, pre);
        // 掌门2
        y = Unionsearch(root2, pre);
        // 两个掌门不同,说明两个大侠的阵营不同
        if (x != y) //如果不连通，就把它们所在的连通分支合并
        {
            // 归属于一块岛
            pre[x] = y;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
