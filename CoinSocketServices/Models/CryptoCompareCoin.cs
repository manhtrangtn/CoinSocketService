using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSocketServices.Models
{
    class CryptoCompareCoin
    {
        public int TYPE { get; set; }
        //0 TYPE: 2,
        public string MARKET { get; set; }
        //1 MARKET: "Coinbase",
        public string FROMSYMBOL { get; set; }
        //2 FROMSYMBOL: "BTC",
        public string TOSYMBOL { get; set; }
        //3 TOSYMBOL: "USD",
        public int FLAGS { get; set; }
        //4 FLAGS: 4,
        public double PRICE { get; set; }
        //5 PRICE: 10100.01,
        public long LASTUPDATE { get; set; }
        //6 LASTUPDATE: 1591073303,
        public double LASTVOLUME { get; set; }
        //7 LASTVOLUME: 0.01940784,
        public double LASTVOLUMETO { get; set; }
        //8 LASTVOLUMETO: 196.0193780784,
        public double LASTTRADEID { get; set; }
        //9 LASTTRADEID: 93678504,
        public double VOLUMEDAY { get; set; }
        //10 VOLUMEDAY: 4755.7709327,
        public double VOLUMEDAYTO { get; set; }
        //11 VOLUMEDAYTO: 48059922.6916242,
        public double VOLUME24HOUR { get; set; }
        //12 VOLUME24HOUR: 11694.11574374,
        public double VOLUME24HOURTO { get; set; }
        //13 VOLUME24HOURTO: 115638261.500159,
        public double OPENDAY { get; set; }
        //14 OPENDAY: 10219.97,
        public double HIGHDAY { get; set; }
        //15 HIGHDAY: 10237.59,
        public double LOWDAY { get; set; }
        //16 LOWDAY: 10037.6,
        public double OPEN24HOUR { get; set; }
        //17 OPEN24HOUR: 9548.99,
        public double HIGH24HOUR { get; set; }
        //18 HIGH24HOUR: 10350.01,
        public double LOW24HOUR { get; set; }
        //19 LOW24HOUR: 9496.84,
        public double VOLUMEHOUR { get; set; }
        //20 VOLUMEHOUR: 422.95353295,
        public double VOLUMEHOURTO { get; set; }
        //21 VOLUMEHOURTO: 4268885.14184708,
        public double OPENHOUR { get; set; }
        //22 OPENHOUR: 10091,
        public double HIGHHOUR { get; set; }
        //23 HIGHHOUR: 10113.21,
        public double LOWHOUR { get; set; }
        //24 LOWHOUR: 10065.78,
        
    }
}
