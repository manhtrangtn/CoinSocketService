using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinSocketServices.Commons;
using CoinSocketServices.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace CoinSocketServices.Services.Implements
{
    class CryptoCompareService : IWebsocketService
    {
        private readonly CommonConstants _commonConstants;
        private readonly CloudFirestoreRepository _cloudFirestoreRepository;

        public CryptoCompareService(CommonConstants commonConstants, CloudFirestoreRepository cloudFirestoreRepository)
        {
            this._commonConstants = commonConstants;
            this._cloudFirestoreRepository = cloudFirestoreRepository;
        }
        public void Websocket()
        {
            using (var ws = new WebSocket(CommonConstants.CryptoCompareWebsocketUri + CommonConstants.CryptoCompareApiKey)
            )
            {
                ws.OnMessage += (sender, e) =>
                  {
                      CryptoCompareCoin cryptoCompareCoin = JsonConvert.DeserializeObject<CryptoCompareCoin>(e.Data);
                      if (!string.IsNullOrEmpty(cryptoCompareCoin.FROMSYMBOL))
                      {
                          CommonCoin commonCoin = new CommonCoin()
                          {
                              Symbol = cryptoCompareCoin.FROMSYMBOL,
                              Price = cryptoCompareCoin.PRICE,
                              HighPrice = cryptoCompareCoin.HIGH24HOUR,
                              OpenPrice = cryptoCompareCoin.OPEN24HOUR,
                              CurrencySymbol = cryptoCompareCoin.TOSYMBOL,
                              Timestamp = cryptoCompareCoin.LASTUPDATE
                          };

                          _cloudFirestoreRepository.CreatOrUpdate(commonCoin, CommonConstants.CryptoCompareCollectionName);
                      }
                  };

                ws.Connect();
                ws.Send(JsonConvert.SerializeObject(_commonConstants.CryptoCompareCoinRequestParams));

                Console.ReadKey(true);
            }
        }
    }
}
