using System.Collections.Generic;
using System.Web.Mvc;
using chipoltle.Models;

namespace chipoltle.ViewModel
{ //A view model represents only the data that you want to display on your view, 
    // whether it be used for static text or for selection values (like textboxes and dropdowns).
    // a view model prepares a set of data for the view to display
    public class OrderSelections : Order // notice this inherits from the model
    {
        public List<SelectListItem> CustomerGroup =
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_CustomerGroup_corporate,
                    Value = GlobalResource.OrderSelections_CustomerGroup_corporate
                },
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_CustomerGroup_student,
                    Value = GlobalResource.OrderSelections_CustomerGroup_student
                },
                new SelectListItem
                {
                    Text =  GlobalResource.OrderSelections_CustomerGroup_regular_customer,
                    Value = GlobalResource.OrderSelections_CustomerGroup_regular_customer
                }
            };

        // choice of beans dropdown items
        public List<SelectListItem> SelectBeans =
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_SelectBeans_black,
                    Value = GlobalResource.OrderSelections_SelectBeans_black
                },
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_SelectBeans_brown,
                    Value = GlobalResource.OrderSelections_SelectBeans_brown
                }
            };

        // choice of entree dropdown items
        public List<SelectListItem> SelectItems =
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_SelectItems_burrito,
                    Value = GlobalResource.OrderSelections_SelectItems_burrito
                },
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_SelectItems_taco,
                    Value = GlobalResource.OrderSelections_SelectItems_taco
                },
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_SelectItems_salad,
                    Value = GlobalResource.OrderSelections_SelectItems_salad
                }
            };

        // choice of meat dropdown items
        public List<SelectListItem> SelectMeats =
            new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_SelectMeats_chicken,
                    Value = GlobalResource.OrderSelections_SelectMeats_chicken
                },
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_SelectMeats_steak,
                    Value = GlobalResource.OrderSelections_SelectMeats_steak
                },
                new SelectListItem
                {
                    Text = GlobalResource.OrderSelections_SelectMeats_veggie,
                    Value = GlobalResource.OrderSelections_SelectMeats_veggie
                }
            };
    }
}