namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class Solutions
    {
        #region 766. Toeplitz Matrix
        /// <summary>
        /// Given an m x n matrix, return true if the matrix is Toeplitz.
        /// Otherwise, return false.
        /// A matrix is Toeplitz if every diagonal from top-left to 
        /// bottom-right has the same elements.
        /// https://leetcode.com/problems/toeplitz-matrix/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (matrix[i][j] != matrix[i + 1][j + 1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
