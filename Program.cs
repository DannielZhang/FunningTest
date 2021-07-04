using System;
using System.Text.RegularExpressions;

namespace MiniGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start Game！");

            DisplayLogic.Init();

            DisplayLogic.curPlayer = 1;

            while (!DisplayLogic.gameOver)
            {
                Console.WriteLine("玩家 {0} 开始，请指定要操作的行和操作数量：（格式：行,数量）", DisplayLogic.curPlayer);
                var input = Console.ReadLine();
                Regex regex = new Regex("\\d{1},\\d{1}");

                if (!regex.Match(input).Success)
                {
                    Console.WriteLine("输入错误，请重试");
                    continue;
                }

                var split = input.Split(',');
                DisplayLogic.UpdateDisplay(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
            }
            
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 用于处理每次交互的显示
    /// </summary>
    class DisplayLogic
    {
        public static int[] countByRow;

        public static int curPlayer;

        public static bool gameOver;

        public static void Init()
        {
            countByRow = new int[3];
            for (int i = 0; i < 3; i++)
            {
                var count = 3 + i * 2;
                countByRow[i] = count;

                for (int j = 0; j < count; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("Row " + (i + 1).ToString() + ":");
                    }
                    Console.Write("*");
                    if (j == count - 1)
                    {
                        Console.Write(Environment.NewLine);
                    }
                }
            }
        }

        public static void UpdateDisplay(int row, int removeCount)
        {
            if (countByRow.Sum() < removeCount || countByRow[row - 1] < removeCount)
            {
                Console.WriteLine("所取出的对象数量超过剩余数量");
                return;
            }
            else if(countByRow.Sum() == removeCount)
            {
                Console.WriteLine("玩家{0} 输了！", curPlayer);
                return;
            }
            else if(countByRow .Sum() - removeCount == 1)
            {
                Console.WriteLine("玩家{0} 胜利！", curPlayer);
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                if(i == row - 1 && countByRow.Sum() > removeCount)
                {
                    countByRow[i] -= removeCount;
                }
                for (int j = 0; j < countByRow[i]; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("Row " + (i + 1).ToString() + ":");
                    }
                    Console.Write("*");
                    if (j == countByRow[i] - 1)
                    {
                        Console.Write(Environment.NewLine);
                    }
                }
            }

            curPlayer = curPlayer == 2 ? 1 : 2;
        }

    }

  

    public static class ExtensionMethods
    {
        public static int Sum(this int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
