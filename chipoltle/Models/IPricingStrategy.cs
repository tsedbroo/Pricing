using System;
using System.Collections.Generic;

namespace chipoltle.Models
{
    public interface IPricingStrategy
    {
        Decimal CalculateCost(Order aOrder);
    }

    public abstract class Pricing : IPricingStrategy
    {  // our pricing dictionary - 
        protected Dictionary<string, Decimal> Prices = new Dictionary<string, decimal>
        {
            {GlobalResource.OrderSelections_SelectItems_taco, 2.00m},
            {GlobalResource.OrderSelections_SelectItems_salad, 3.00m},
            {GlobalResource.OrderSelections_SelectItems_burrito, 3.00m},
            {GlobalResource.OrderSelections_SelectMeats_chicken, 1.00m},
            {GlobalResource.OrderSelections_SelectMeats_steak, 2.00m},
            {GlobalResource.OrderSelections_SelectMeats_veggie, 1.00m}
        };

        public abstract Decimal CalculateCost(Order anOrder);

       
        // business rule: give everyone a discount on one day of the week see resource file
        protected Decimal Discounts()
        {
            var now = DateTime.Now;
            if (now.ToString("ddd").Equals(GlobalResource.Calculate_Discounts_Weekday))
            {
                return .50m;
            }
            return 0m;
        }
    }


    // Business rule - regular people just get a discount depending on the day
    public class PricePublic : Pricing
    {
        public override Decimal CalculateCost(Order anOrder)
        {
            var price = Prices[anOrder.Item] + Prices[anOrder.Meat];
            return price - Discounts();
        }
    }

    // Business rule  - students get $.25 off their order
    public class StudentPrice : Pricing
    {
        public override Decimal CalculateCost(Order anOrder)
        {
            var price = (Prices[anOrder.Item] - .25m) + Prices[anOrder.Meat];
            return price - Discounts();
            
        }
    }

    //Business rule - corporate customers get $.30 off if they order "veggies" otherwise they pay more $.30 more for eating unhealthy
    public class CorporatePrice : Pricing
    {
        public override Decimal CalculateCost(Order anOrder)
        {
            // we want to encourage our corporate customer to eat healthy   
            var price = Prices[anOrder.Item] +
                        (anOrder.Item != null && anOrder.Item.Equals(GlobalResource.OrderSelections_SelectMeats_veggie) ? Prices[anOrder.Meat] - .30m : Prices[anOrder.Meat] + .30m);
            return price - Discounts();
        }
    }
}