using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOFAB_BotCompete_
{
    class decide
    {
        public void decideab(int[] firstnum, int[] secondnum, ref int a, ref int b)
        {
            int i = 0, j = 0;
            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                {
                    if (firstnum[i] != secondnum[j])
                        continue;
                    if (i == j)
                        a++;
                    else
                        b++;
                }
        }
    }
}
