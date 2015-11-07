using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using chipoltle.Models;

namespace chipoltle.ViewModel
{
    public class CounterViewModel
    {
        public string Item { get; set; }
        public int Count { get; set; }

    
        // count up the number of times each item is ordered
        public IEnumerable<CounterViewModel> CountResults(List<Order> myOrders)
        {
            // talley orders
            //int burritoCount = 0;
            //int saladCount = 0;
            //int tacoCount = 0;
            //foreach (Order anOrder in myOrders)
            //{
            //    if (anOrder.Item.Equals(GlobalResource.OrderSelections_SelectItems_burrito))
            //        burritoCount++;
            //    else if (anOrder.Item.Equals(GlobalResource.OrderSelections_SelectItems_taco))
            //        tacoCount++;
            //    else if (anOrder.Item.Equals(GlobalResource.OrderSelections_SelectItems_salad))
            //        saladCount++;
            //}

            //var itemCounts = new List<CounterViewModel> // example of collection initialization
            //{
            //    new CounterViewModel {Item = GlobalResource.OrderSelections_SelectItems_burrito, Count = burritoCount}, //example of object initialization
            //    new CounterViewModel {Item = GlobalResource.OrderSelections_SelectItems_taco, Count = tacoCount},
            //    new CounterViewModel {Item = GlobalResource.OrderSelections_SelectItems_salad, Count = saladCount}
            //};

            // this is LINQ code equivalent to above 


            var itemCounts = from anOrder in myOrders
                             group anOrder by anOrder.Item into g
                             orderby g.Count() descending
                             select new CounterViewModel { Item = g.Key, Count = g.Count() };

            
            return itemCounts;
        }
    }
}