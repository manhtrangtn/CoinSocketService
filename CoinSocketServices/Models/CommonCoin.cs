using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace CoinSocketServices.Models
{
    [FirestoreData]
    public class CommonCoin
    {
        [FirestoreDocumentId]
        [FirestoreProperty]
        public string Symbol { get; set; }
        [FirestoreProperty]
        public long Timestamp { get; set; }
        [FirestoreProperty]
        public string CurrencySymbol { get; set; }
        [FirestoreProperty]
        public double Price { get; set; }
        [FirestoreProperty]
        public double OpenPrice { get; set; }
        [FirestoreProperty]
        public double HighPrice { get; set; }
    }
}
