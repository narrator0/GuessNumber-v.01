using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOFAB_BotCompete_
{
    class Program
    {
        //切割四位數
        static void cutnum(int num, ref int[] cutnumber)
        {
            int k = 0;
            for (k = 0; k < 4; k++)
            {
                cutnumber[k] = num % 10;
                num = num / 10;
            }
        }

        static void Main(string[] args)
        {
            //起始畫面
            Console.WriteLine("猜數字遊戲!!!");
            Console.WriteLine("按任意鍵開始遊戲");
            Console.ReadLine();

            //規則說明


            //設定電腦的數字
            number botnum = new number();
            botnum.randget();

            //Console.WriteLine("{0}{1}{2}{3}", botnum.Gnum[3], botnum.Gnum[2], botnum.Gnum[1], botnum.Gnum[0]);

            //人第一次猜測
            int manguess = 0;
            int[] guessarray = new int[4];
            int i = 1;
            Console.Write("由你先開始猜，你猜的數字是?");
            do{
                try{
                    manguess = int.Parse(Console.ReadLine());

                    //切割數字           

                    cutnum(manguess, ref guessarray);

                    if (manguess < 0 || manguess > 9999 || guessarray[0] == guessarray[1] || guessarray[0] == guessarray[2] || guessarray[0] == guessarray[3] || guessarray[1] == guessarray[2] || guessarray[1] == guessarray[3] || guessarray[2] == guessarray[3])
                    {
                        Console.WriteLine("輸入錯誤!!!(輸入負數或是數字有重複)\n");
                        continue;
                    }                       
                    break;
                }
                catch{
                    Console.WriteLine("輸入錯誤請重新輸入!!\n");
                }
            }while(i==1);
                       
                                         

            //判斷結果並回傳
            int mana = 0, manb = 0;
            decide man = new decide();
            man.decideab(guessarray, botnum.Gnum, ref mana, ref manb);

            Console.WriteLine("{0}A{1}B\n", mana, manb);

            //換電腦猜
            Console.WriteLine("接著換我猜!請分別輸入A與B");
            Console.WriteLine("我猜1234");

            int bota = 0;
            int botb = 0;
            do
            {
                try
                {
                    bota = int.Parse(Console.ReadLine());
                    botb = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if(bota<0||bota>4||botb<0||botb>4||(bota+botb)>4)
                    {
                        Console.WriteLine("必須為0到4之間的數\n");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("輸入錯誤請重新輸入!!\n");
                }
            } while (i == 1);

            //將結果輸入電腦
            int[] firstguess = { 4, 3, 2, 1 };
            AI brain = new AI();
            brain.setsearch();
            brain.setbotguess(firstguess, bota, botb);

            //開始循環猜
            int mancount = 1, botcount = 1;
            int test = 1;
            do
            {
                if (mana != 4)
                {
                    Console.WriteLine("你猜的數字是?");
                    do
                    {
                        try
                        {
                            //人猜測並切割
                            manguess = int.Parse(Console.ReadLine());
                            cutnum(manguess, ref guessarray);

                            if (manguess < 0 || manguess > 9999 || guessarray[0] == guessarray[1] || guessarray[0] == guessarray[2] || guessarray[0] == guessarray[3] || guessarray[1] == guessarray[2] || guessarray[1] == guessarray[3] || guessarray[2] == guessarray[3])
                            {
                                Console.WriteLine("輸入錯誤!!!(輸入負數或是數字有重複)\n");
                                continue;
                            }
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("輸入錯誤請重新輸入!!\n");
                        }
                    } while (i == 1);

                    //判斷結果並回傳
                    mana = 0;
                    manb = 0;
                    man.decideab(guessarray, botnum.Gnum, ref mana, ref manb);

                    Console.WriteLine("{0}A{1}B\n", mana, manb);
                    mancount++;
                }

                if (bota != 4)
                {
                    //換電腦猜
                    int[] botguess = new int[4];
                    brain.botguess(ref botguess);
                    Console.WriteLine("我猜{0}{1}{2}{3}", botguess[3], botguess[2], botguess[1], botguess[0]);

                    test = botguess[3] + botguess[2] + botguess[1] + botguess[0];
                    if (test == 0)
                    {
                        Console.WriteLine("你給的提示有誤!!!");
                        Console.WriteLine("你輸了!!!\n");
                        break;
                    }
                    do
                    {
                        try
                        {
                            bota = 0;
                            botb = 0;
                            bota = int.Parse(Console.ReadLine());
                            botb = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            if (bota < 0 || bota > 4 || botb < 0 || botb > 4 || (bota + botb) > 4)
                            {
                                Console.WriteLine("必須為0到4之間的數\n");
                                continue;
                            }

                            //將結果輸入電腦
                            brain.setbotguess(botguess, bota, botb);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("輸入錯誤請重新輸入!!\n");
                        }
                    } while (i == 1);
                   
                    botcount++;
                }
            } while ((bota != 4) || (mana != 4));

            if (test != 0)
            {
                //顯示勝負
                if (botcount == mancount)
                {
                    Console.WriteLine("{0}:{0} 平手", botcount);
                }
                else if (botcount < mancount)
                {
                    Console.WriteLine("{0}:{1} 你輸了", botcount, mancount);
                }
                else if (botcount > mancount)
                {
                    Console.WriteLine("{0}:{1} 你贏了", botcount, mancount);
                }
            }
            


            Console.WriteLine("按任意鍵結束");
            Console.ReadLine();




        }
    }
}
