using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CoinSocketServices.Commons
{
    class CommonConstants
    {
        public const string CryptoCompareWebsocketUri = "wss://streamer.cryptocompare.com/v2?api_key=";
        public const string CoinCapUri = "wss://ws.coincap.io/prices?assets=bitcoin,ethereum,monero,litecoin,dash,doge,tether,ripple,bitcoincash,bitcoinsv";

        public const string CryptoCompareApiKey = "f6c8c7ee3a128854086066a06da5c2ed372b7d3ccbc9847baa832722f4e21d3c";

        public const string DefaultCurrencySymbol = "USD";
        public const string CryptoCompareCollectionName = "CryptoCompare";
        public const string CoinCapCollectionName = "CoinCap";
        public const string GoogleFirebaseProjectId = "coin-market-2020";
        public const string GoogleFirebaseAuthenticationFileName = @"coin-market.json";
        public const string GoogleFirebaseApplicationCredential = "GOOGLE_APPLICATION_CREDENTIALS";

        public JArray CryptoCompareCoinArray = new JArray();
        public Dictionary<string, Object> CryptoCompareCoinRequestParams = new Dictionary<string, Object>();
        
        public CommonConstants()
        {
            CryptoCompareCoinArray.Add("2~Coinbase~BTC~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~ETH~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~XMR~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~LTC~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~DASH~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~DOGE~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~USDT~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~XRP~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~BCH~USD");
            CryptoCompareCoinArray.Add("2~Coinbase~BSV~USD");

            var jObject = new JObject
            {
              { "subs", CryptoCompareCoinArray }
            };

            CryptoCompareCoinRequestParams.Add("action", "SubAdd");
            CryptoCompareCoinRequestParams.Add("subs", CryptoCompareCoinArray.ToObject<string[]>());

        }

        public string ConvertSymbols(string name)
        {
            switch (name)
            {
                case "bitcoin": return "BTC";
                case "ethereum": return "ETH";
                case "monero": return "XMR";
                case "litecoin": return "LTC";
                case "dash": return "DASH";
                case "doge": return "DOGE";
                case "tether": return "USDT";
                case "ripple": return "XRP";
                case "bitcoincash": return "BCH";
                case "bitcoinsv": return "BSV";
                default:
                    return "";
            }
        }


        public void PrintProgramTitle()
        {
          Console.WriteLine(" _____       _       _____            _        _   ");
          Console.WriteLine("/  __ \\     (_)     /  ___|          | |      | |  ");
          Console.WriteLine("| /  \\/ ___  _ _ __ \\ `--.  ___   ___| | _____| |_ ");
          Console.WriteLine("| |    / _ \\| | '_ \\ `--. \\/ _ \\ / __| |/ / _ \\ __|");
          Console.WriteLine("| \\__/\\ (_) | | | | /\\__/ / (_) | (__|   <  __/ |_");
          Console.WriteLine(" \\____/\\___/|_|_| |_\\____/ \\___/ \\___|_|\\_\\___|\\__| __SERVICE");
          Console.WriteLine("_______________TEAM 05________________T1809E_______________");
          Console.WriteLine("_______________________Created By TrangDM2_________________");
          Console.WriteLine("___________________________________________________________");
        }
    }
}