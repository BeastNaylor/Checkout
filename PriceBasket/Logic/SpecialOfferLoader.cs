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
        private ICollection<SpecialOfferDuration> _offers;

        public SpecialOfferLoader(DateTime currentDate)
        {
            _date = currentDate;
            InitAllOffers();
        }

        private void InitAllOffers()
        {
            var startThisWeek = new DateTime(2018, 03, 25);
            var endThisWeek = new DateTime(2018, 04, 1);
        
            _offers = new List<SpecialOfferDuration>();
            //TODO: move this function out of the code so Offers can be dynamically added
            var appleOffer = new DiscountOffer("Apples", 0.1m);
            var soupOffer = new MultibuyOffer("Soup", 2, "Bread", 0.5m);
            _offers.Add(new SpecialOfferDuration() { StartDate = startThisWeek, EndDate = endThisWeek, SpecialOffer = appleOffer });
            _offers.Add(new SpecialOfferDuration() { StartDate = startThisWeek, EndDate = endThisWeek, SpecialOffer = soupOffer });
        }

        public ICollection<ISpecialOffer> LoadCurrentOffers()
        {
            return _offers.Where(o => o.StartDate <= _date && o.EndDate >= _date).Select(o => o.SpecialOffer).ToList();
        }

        private class SpecialOfferDuration
        {
            public DateTime StartDate;
            public DateTime EndDate;
            public ISpecialOffer SpecialOffer;
        }
    }
}
