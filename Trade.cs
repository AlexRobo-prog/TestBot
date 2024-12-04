using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TestBot
{
    public enum PositionType
    {
        NoType,
        Long,
        Short
    };

    public class Trade
    {


        //----------------------- Fields -----------------------
        #region Fields

        public string Symbol = "";
        public ushort Magic = 0;
        public decimal  Price       = 0;
        public string   SecCode     = "";
        public string   ClassCode   = "";
        public DateTime DateTime    = DateTime.MinValue;
        public string   Portfolio   = "";
        public PositionType PosType = PositionType.NoType;
        public decimal Lot = 0;
        public decimal TPPrice = 0;
        public decimal SLPrice = 0;

        #endregion

        public decimal Volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value;
            }
            
        }
        decimal _volume = 0;

        
    }
}
