using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigToDig
{
    class Class1
    {
        int[][] MatrixMultiplication(int[][] a, int[][] b)
        {
            int[][] r = new int[3][];
            int i, j, s = 0, k;
            for (i = 0; i < 3; i++)
            { //row of first matrix
                for (j = 0; j < 3; j++)
                {  //column of second matrix
                    s = 0;
                    for (k = 0; k < 3; k++)
                        s = s + a[i][k] * b[k][j];
                    r[i][j] = s;
                }

            }
            return r;

        }
    }
}
