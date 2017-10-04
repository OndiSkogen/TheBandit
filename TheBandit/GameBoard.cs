using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBandit
{
    class GameBoard
    {
        private int[,] cards = new int[3, 3];
        Random rnd = new Random();
        private int winningLines;
        private int sum;

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

        private int GetMultiplier(int i)
        {
            switch (i)
            {
                case 1:
                    return 2;
                case 2:
                    return 3;
                case 3:
                    return 5;
                case 4:
                    return 10;
                case 5:
                    return 20;
                case 6:
                    return 50;
                default:
                    return 0;
            }
        }

        public int CheckWinnings(int[,] temp, int bet)
        {
            sum = 0;
            winningLines = 0;

            if (temp[0,0] == temp[1,0] && temp[0,0] == temp[2, 0])
            {
                sum += bet * GetMultiplier(temp[0, 0]);
                winningLines++;
            }

            if (temp[0, 1] == temp[1, 1] && temp[1, 0] == temp[2, 1])
            {
                sum += bet * GetMultiplier(temp[1, 0]);
                winningLines++;
            }

            if (temp[0, 2] == temp[1, 2] && temp[0, 2] == temp[2, 2])
            {
                sum += bet * GetMultiplier(temp[2, 0]);
                winningLines++;
            }

            if (temp[0, 0] == temp[1, 1] && temp[0, 0] == temp[2, 2])
            {
                sum += bet * GetMultiplier(temp[0, 0]);
                winningLines++;
            }

            if (temp[2, 0] == temp[1, 1] && temp[2, 0] == temp[0, 2])
            {
                sum += bet * GetMultiplier(temp[2, 0]);
                winningLines++;
            }          

            return sum;
        }

        public int GetWinningLines()
        {
            return winningLines;
        }

        public int GetSum()
        {
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