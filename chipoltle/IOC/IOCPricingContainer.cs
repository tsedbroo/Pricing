using System.Collections.Generic;
using chipoltle.Models;

namespace chipoltle.IOC
{
    public class IocPricingContainer
    {
        private static Dictionary<string, IPricingStrategy> pricingStrategies = new Dictionary<string, IPricingStrategy>();

        // example of Singleton pattern only one mom allowed
        private static IocPricingContainer _singleInstance;

        private IocPricingContainer()   
            // add to my Dictionary
        {
            pricingStrategies.Add(GlobalResource.OrderSelections_CustomerGroup_corporate, new CorporatePrice());
            pricingStrategies.Add(GlobalResource.OrderSelections_CustomerGroup_student, new StudentPrice());
            pricingStrategies.Add(GlobalResource.OrderSelections_CustomerGroup_regular_customer, new PricePublic());

           
        }

        public static IPricingStrategy Gimme(string key)
        {
            if (_singleInstance == null)
                _singleInstance = new IocPricingContainer();
            if (pricingStrategies.ContainsKey(key))
                return pricingStrategies[key];
            else
                throw new KeyNotFoundException("sorry kid you're going hungry");

            
        }
    }
}