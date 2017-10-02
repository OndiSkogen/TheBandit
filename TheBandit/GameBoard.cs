using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBandit
{
    class GameBoard
    {
        int[,] cards = new int[3, 3];
        Random rnd = new Random();

        //Metod som randomiserar ett gameboard och skickar tillbaka det.
        public int[,] Spin()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cards[i, j] = GenerateCard();
                }
            }
            return cards;
        }

        private double GetMultiplier(int i)
        {
            switch (i)
            {
                case 1:
                    return 1.2;
                case 2:
                    return 2;
                case 3:
                    return 2.5;
                case 4:
                    return 5;
                case 5:
                    return 10;
                case 6:
                    return 50;
                default:
                    return 0;
            }
        }

        public double CheckWinnings(int[,] temp, int bet)
        {
            double sum = 0;

            if (temp[0,0] == temp[0,1] && temp[0,0] == temp[0, 2])
            {
                sum += bet * GetMultiplier(temp[0, 0]);
            }

            if (temp[1, 0] == temp[1, 1] && temp[1, 0] == temp[1, 2])
            {
                sum += bet * GetMultiplier(temp[1, 0]);
            }

            if (temp[2, 0] == temp[2, 1] && temp[2, 0] == temp[2, 2])
            {
                sum += bet * GetMultiplier(temp[2, 0]);
            }

            if (temp[0, 0] == temp[1, 1] && temp[0, 0] == temp[2, 2])
            {
                sum += bet * GetMultiplier(temp[0, 0]);
            }

            if (temp[2, 0] == temp[1, 1] && temp[2, 0] == temp[0, 2])
            {
                sum += bet * GetMultiplier(temp[2, 0]);
            }

            return sum;
        }

        //Returnerar ett randomiserat kort enligt angivna %
        private int GenerateCard()
        {
            int i = rnd.Next(101);

            if (i < 31) return 1;

            if (i > 30 && i < 56) return 2;

            if (i > 55 && i < 76) return 3;

            if (i > 75 && i < 91) return 4;

            if (i > 90 && i < 99) return 5;

            else return 6;
        }
    }
}