﻿//Andreas Norberg, 2017
namespace TheBandit
{
    class Wallet
    {
        private int money;

        public int Money()
        {
            return money;
        }

        public void AddMoney(int add)
        {
            money += add;
        }

        public void SubtractMoney(int sub)
        {
            money -= sub;
        }
    }
}
