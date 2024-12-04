using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestBot
{
    public class Position
    {
        //----------------------- Fields -----------------------
        // Если я правильно понял, часть этих данных должен задавать пользователь
        // А часть данных должны приходить от сервера, если запрашиваем параметры открытой позиции.
        #region Fields

        public string Symbol            = "Si";                       // Инструмент
        public ushort magic             = 111;                        // Уникальное число робота для различия своих сделок от сделок другого робота/пользователя
        public ulong ticket             = 0;                        // Уникальный номер позиции в общем списке
        public decimal openPrice        = 0;                        // Цена открытия.
        public DateTime openTime        = DateTime.MinValue;        // Время открытия.
        public decimal openVolume       = 0;                        // Открытый обьем.
        public decimal dontOpenVolume   = 0;                        // Не открытый обьем.
        public decimal takeProfitPrice  = 0;                        // Цена для закрытия позиции по тейку
        public decimal stopLossPrice    = 0;                        // Цена для закрытия позиции по стопу
        public int takeProfitSize       = 100;                        // Размер тейка в пунктах
        public int stopLossSize         = 100;                        // Размер стопа в пунктах 
        public PositionType posType     = PositionType.NoType;      // Тип позиции лонг/шорт

        #endregion

        public Position()
        {
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += NewTrade;
            timer.Start();
        }

        Random rnd = new Random();

        private void NewTrade(object sender, ElapsedEventArgs e)
        {
            // Если я правильно понял, то переменную trade класса Trade мы создали для отправки данных на сервер для открытия позиции в дальнейшем
            Trade trade = new Trade();
            int num = rnd.Next(-10, 10);
            
            trade.Volume = Math.Abs(num);
            trade.Symbol = Symbol;
            trade.Magic = magic;

            if (num > 0)
            {
                trade.PosType = PositionType.Long;
                trade.Price = SymbolInfo.GetMarketAsk();
                trade.TPPrice = trade.Price + takeProfitSize;
                trade.SLPrice = trade.Price - stopLossSize;
            }
            if (num < 0)
            {
                trade.PosType = PositionType.Short;
                trade.Price = SymbolInfo.GetMarketBid();
                trade.TPPrice = trade.Price - takeProfitSize;
                trade.SLPrice = trade.Price + stopLossSize;
            }

            //string str = "Volume = " + trade.Volume.ToString() + " / Price = " + trade.Price.ToString();

            if (num !=0) Console.WriteLine("Symbol = {0} | Price = {1} | Volume = {2} | PosType = {3} | TP = {4} | SL = {5}",trade.Symbol,trade.Price,trade.Volume,trade.PosType,trade.TPPrice,trade.SLPrice);

            
        }
    }
}
