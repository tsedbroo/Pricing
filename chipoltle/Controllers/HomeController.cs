using System.Collections.Generic;
using System.Web.Mvc;
using chipoltle.Models;
using chipoltle.ViewModel;

namespace chipoltle.Controllers
{
    public class HomeController : Controller

    {
        // this is for demonstration purpose -- we will utimately need a repository to hold orders

        private static readonly List<Order> MyOrders = new List<Order>();
       
        //*******************************************************

        public ActionResult Index()
        {
            // use a view model to support display of information in the view
            var vm = new OrderSelections();
            return View(vm);
        }

        // this method will handle the form HttpPost method
        [HttpPost]
        public ActionResult Index(Order anOrder)
        {
            // pricing pipeline - apply pricing rules  
            IPricingStrategy pricing =   IOC.IocPricingContainer.Gimme(anOrder.PriceGroup);
            anOrder.OrderCost = pricing.CalculateCost(anOrder);  // set order cost

            MyOrders.Add(anOrder);
          
            return View("Thanks",  anOrder);
        }

        public ActionResult ShowOrders()
        {
            // use a view model to count up the numbers of orders of each item
            CounterViewModel vm = new CounterViewModel();

            // ask the view model to determine the counts of each order type ( burrito, taco, salad)
            IEnumerable<CounterViewModel> results = vm.CountResults(MyOrders);

            return View("ShowOrders", results);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}