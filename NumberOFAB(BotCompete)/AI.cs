using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOFAB_BotCompete_
{
    class AI
    {
         private bool[,,,] search = new bool[10, 10, 10, 10];

        //將有沒有重複數字的設置為true
        public void setsearch()
        {
            int a = 0, b = 0, c = 0, d = 0;
            for(a=0;a<10;a++)
                for(b=0;b<10;b++)
                    for(c=0;c<10;c++)
                        for (d=0;d<10;d++)
                        {
                            if (a == b || a == c || a == d || b == c || b == d || c == d)
                                continue;
                            search[a, b, c, d] = true;
                        }
        }

        //set getter and setter
        public bool[,,,] Search
        {
            get { return search; }
        }

        //設定猜測
        public void setbotguess(int[] guessnum, int aresult, int bresult)
        {
            //先將不可能的選項設置為否
            int a = 0, b = 0, c = 0, d = 0;
            for (a = 0; a < 10; a++)
                for (b = 0; b < 10; b++)
                    for (c = 0; c < 10; c++)
                        for (d = 0; d < 10; d++)
                        {
                            //排除已經是否的
                            if (search[a, b, c, d] == false)
                                continue;

                            decide number = new decide();
                            int[] botnum = {a, b, c, d};
                            int testa = 0, testb = 0;
                            number.decideab(guessnum, botnum, ref testa, ref testb);

                            //排除還成立的
                            if (testa == aresult && testb == bresult)
                                continue;

                            search[a, b, c, d] = false;
                        }
        }


        //回傳猜測
        public void botguess(ref int[] guess)
        {
            int a = 0, b = 0, c = 0, d = 0;
            for (a = 0; a < 10; a++)
                for (b = 0; b < 10; b++)
                    for (c = 0; c < 10; c++)
                        for (d = 0; d < 10; d++)
                        {
                            if (search[a, b, c, d] == true)
                            {
                                guess[0] = a;
                                guess[1] = b;
                                guess[2] = c;
                                guess[3] = d;
                                break;
                            }
                        }
        }
    }
}
