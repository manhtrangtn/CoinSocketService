using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CoinSocketServices.Commons;
using CoinSocketServices.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace CoinSocketServices.Services.Implements
{
    class CoinCapService : IWebsocketService
    {
        private readonly CommonConstants _commonConstants;
        private readonly CloudFirestoreRepository _cloudFirestoreRepository;

        public CoinCapService(CommonConstants commonConstants, CloudFirestoreRepository cloudFirestoreRepository)
        {
            this._commonConstants = commonConstants;
            this._cloudFirestoreRepository = cloudFirestoreRepository;
        }
        public void Websocket()
        {
            using (var ws = new WebSocket(CommonConstants.CoinCapUri)
            )
            {
                ws.OnMessage += (sender, e) =>
                {
                    Dictionary<string, double> coinCapCoin = JsonConvert.DeserializeObject<Dictionary<string, double>>(e.Data);
                    foreach (var valuePair in coinCapCoin)
                    {
                        CommonCoin commonCoin = new CommonCoin()
                        {
                            Price = valuePair.Value,
                            Symbol = _commonConstants.ConvertSymbols(valuePair.Key),
                            CurrencySymbol = CommonConstants.DefaultCurrencySymbol
                        };
                        _cloudFirestoreRepository.CreatOrUpdate(commonCoin, CommonConstants.CoinCapCollectionName);
                    }
                };
                ws.Connect();
                ws.Send(JsonConvert.SerializeObject(null));
                Console.ReadKey(true);
            }
        }
    }
}
