using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
