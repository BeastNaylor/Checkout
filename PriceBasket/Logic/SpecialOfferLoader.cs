using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceBasket.Model;

namespace PriceBasket.Logic
{
    class SpecialOfferLoader : ISpecialOfferLoader
    {
        private DateTime _date;
        private ICollection<Tuple<DateTime, DateTime, ISpecialOffer>> _offers;

        public SpecialOfferLoader(DateTime currentDate)
        {
            _date = currentDate;
            InitAllOffers();
        }

        private void InitAllOffers()
        {
            var startThisWeek = new DateTime(2018, 03, 25);
            var endThisWeek = new DateTime(2018, 04, 1);
        
            _offers = new List<Tuple<DateTime, DateTime, ISpecialOffer>>();
            //TODO: move this function out of the code so Offers can be dynamically added
            var appleOffer = new DiscountOffer("Apples", 0.1m);
            var soupOffer = new MultibuyOffer("Soup", 2, "Bread", 0.5m);
            _offers.Add(new Tuple<DateTime, DateTime, ISpecialOffer>(startThisWeek, endThisWeek, appleOffer));
            _offers.Add(new Tuple<DateTime, DateTime, ISpecialOffer>(startThisWeek, endThisWeek, soupOffer));
        }

        public ICollection<ISpecialOffer> LoadCurrentOffers()
        {
            return _offers.Where(o => o.Item1 <= _date && o.Item2 >= _date).Select(o => o.Item3).ToList();
        }
    }
}
