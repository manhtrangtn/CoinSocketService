using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoinSocketServices.Commons;
using CoinSocketServices.Services;
using CoinSocketServices.Services.Implements;
using Newtonsoft.Json;
using WebSocketSharp;

namespace CoinSocketServices
{
    class Program
    {
        private readonly CommonConstants _commonConstants;
        private readonly CloudFirestoreRepository _cloudFirestoreRepository;

        private Program()
        {
            this._commonConstants = new CommonConstants();
            this._cloudFirestoreRepository = new CloudFirestoreRepository();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program._commonConstants.PrintProgramTitle();
            program.Start();
        }

        private void Start()
        {
            IWebsocketService coinCapService = new CoinCapService(_commonConstants, _cloudFirestoreRepository);
            IWebsocketService cryptoCompareService = new CryptoCompareService(_commonConstants, _cloudFirestoreRepository);

            Thread coinCapThread = new Thread(coinCapService.Websocket);
            Thread cryptoCompareThread = new Thread(cryptoCompareService.Websocket);

            coinCapThread.Start();
            cryptoCompareThread.Start();
        }
    }
}