using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBandit
{
    class GameBoard
    {
        private string[,] cards = new string[3, 3];        
        Random rnd = new Random();
        private int winningLines;
        private int sum;

        //Metod som randomiserar ett gameboard och skickar tillbaka det.
        public string[,] Spin()
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

        private int GetMultiplier(string str)
        {
            switch (str)
            {
                case "/Images/Nio.png":
                    return 2;
                case "/Images/Tio.png":
                    return 3;
                case "/Images/Knekt.png":
                    return 5;
                case "/Images/Dam.png":
                    return 10;
                case "/Images/Kung.png":
                    return 20;
                case "/Images/Ess.png":
                    return 50;
                default:
                    return 0;
            }
        }

        public int CheckWinnings(string[,] temp, int bet)
        {
            sum = 0;
            winningLines = 0;

            if (temp[0,0] == temp[1,0] && temp[0,0] == temp[2, 0])
            {
                sum += bet * GetMultiplier(temp[0, 0]);
                winningLines++;
            }

            if (temp[0, 1] == temp[1, 1] && temp[0, 1] == temp[2, 1])
            {
                sum += bet * GetMultiplier(temp[0, 1]);
                winningLines++;
            }

            if (temp[0, 2] == temp[1, 2] && temp[0, 2] == temp[2, 2])
            {
                sum += bet * GetMultiplier(temp[0, 2]);
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
        private string GenerateCard()
        {
            int i = rnd.Next(101);

            if (i < 31) return "/Images/Nio.png";

            if (i > 30 && i < 56) return "/Images/Tio.png";

            if (i > 55 && i < 76) return "/Images/Knekt.png";

            if (i > 75 && i < 91) return "/Images/Dam.png";

            if (i > 90 && i < 99) return "/Images/Kung.png";

            else return "/Images/Ess.png";
        }
    }
}