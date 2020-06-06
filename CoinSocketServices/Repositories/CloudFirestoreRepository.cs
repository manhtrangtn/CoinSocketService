using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinSocketServices.Commons;
using CoinSocketServices.Models;
using Google.Cloud.Firestore;

namespace CoinSocketServices
{
    public class CloudFirestoreRepository
    {
        private readonly FirestoreDb _firestoreDb;
        public CloudFirestoreRepository()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + CommonConstants.GoogleFirebaseAuthenticationFileName;

                Environment.SetEnvironmentVariable(CommonConstants.GoogleFirebaseApplicationCredential, path);
                this._firestoreDb = FirestoreDb.Create(CommonConstants.GoogleFirebaseProjectId);

                Console.WriteLine("Connected!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection failed!" + e);
            }
        }

        public bool CreatOrUpdate(CommonCoin coin, string collection)
        {
            try
            {
                DocumentReference document = _firestoreDb.Collection(collection).Document(coin.Symbol);
                document.SetAsync(coin);
                Console.WriteLine(collection + ": Updated (" + coin.Symbol + ") success!");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(collection + ": Failed to update (" + coin.Symbol + ")");

                return false;
            }
        }
    }
}
