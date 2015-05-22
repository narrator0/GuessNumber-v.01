using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOFAB_BotCompete_
{
    class number
    {
        private int[] gnum;

        //set getter and setter
        public int[] Gnum
        {
            get { return gnum; }
        }

        //產生一個亂數(四個位數不能重複)
        public void randget()
        {
            int[] cut = new int[4];
            Random rand = new Random();

            do
            {
                int i = 0;
                for (i = 0; i < 4; i++)
                {
                    cut[i] = rand.Next() % 10;
                }
            } while (cut[0] == cut[1] || cut[0] == cut[2] || cut[0] == cut[3] || cut[1] == cut[2] || cut[1] == cut[3] || cut[2] == cut[3]);

            gnum = cut;
        }

    }
}
