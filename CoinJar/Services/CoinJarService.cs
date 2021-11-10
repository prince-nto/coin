using CoinJar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Services
{
    public class CoinJarService : ICoinJar
    {
        private List<ICoin> coins {  get; set; }
        private decimal coinJarTotalVolume { get; set; }
        private decimal totalAmount {  get; set; }
        private decimal volumeUsed { get; set; }

        public CoinJarService()
        {
            coins = new List<ICoin>();
            coinJarTotalVolume = 42;
            totalAmount = 0;
            volumeUsed = 0;
        }
        public void AddCoin(ICoin coin)
        {
            if (coin == null)
                throw new ArgumentNullException("Coin is null");

            if (coinJarTotalVolume < (volumeUsed + coin.Volume))
                throw new ArgumentException("Coin jar is overflowing");

            coins.Add(coin);
            totalAmount += coin.Amount;
            volumeUsed += coin.Volume;
        }

        public decimal GetTotalAmount()
        {
            return totalAmount;
        }

        public void Reset()
        {
            coins = new List<ICoin>();
            coinJarTotalVolume = 42;
            totalAmount = 0;
            volumeUsed = 0;
        }
    }
}
