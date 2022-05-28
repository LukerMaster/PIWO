using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIWO_Core.Database.Entities;
using PIWO_Core.Interfaces;

namespace PIWO_Core.API
{
    public static class Statistics
    {
        /// <summary>
        /// Returns the alcohol (only alcohol, in liters) sold in certain period (inclusive period).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="onlyAlcohol">Whether to sum only alcohol volume or entire drink.</param>
        /// <returns>Alcohol purchased in liters.</returns>
        public static decimal AlcoholSoldBetween(this IAlcoholContext context, DateTime from, DateTime to, bool onlyAlcohol = true)
        {
            decimal sum = 0;
            foreach (var purchase in context.Purchases)
            {
                decimal multiplier = onlyAlcohol ? (purchase.Alcohol.Voltage * 0.01M) : 1M;

                if (purchase.Date >= from && purchase.Date <= to)
                    sum += purchase.Alcohol.Volume * multiplier;
            }
            return sum;
        }

        public class CityPurchasesData
        {
            internal CityPurchasesData(City city, decimal vol, int pur)
            {
                this.city = city;
                this.alcoholVolume = vol;
                this.purchases = pur;
            }
            public City city;
            public decimal alcoholVolume;
            public int purchases;
        }

        /// <summary>
        /// Gets a list of purchases within a certain city and the amount of alcohol (in liters).
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IEnumerable<CityPurchasesData> GetCityPurchasesData(this IAlcoholContext context)
        {
            List<CityPurchasesData> cityList = new List<CityPurchasesData>();
            foreach (var city in context.Cities)
            {
                decimal vol = 0;
                int purchases = 0;
                foreach (var purchaseInCity in context.Purchases.Where(e => e.Shop.City == city))
                {
                    vol += purchaseInCity.Alcohol.Volume * purchaseInCity.Alcohol.Voltage * 0.01M;
                    purchases++;
                }
                cityList.Add(new CityPurchasesData(city, vol, purchases));
            }

            return cityList;
        }
    }
}
