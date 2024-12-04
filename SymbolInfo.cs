using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBot
{
    public static class SymbolInfo
    {
        
        public static int GetSpread() 
        {
            Random rnd = new Random();
            return rnd.Next(1, 10);
        }

        public static int GetMarketAsk()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 10000);
        }

        public static int GetMarketBid()
        {
            Random rnd = new Random();
            return GetMarketAsk() - GetSpread();
        }
    }
}
