using System;
using System.ComponentModel.DataAnnotations;

namespace chipoltle.Models
{
    public class Order
    {
     [Display(ResourceType = typeof (GlobalResource), Name = "Order_Item_Wild_and_Crazy")]
        public String Item { get; set; }
     
        [Display(ResourceType = typeof (GlobalResource), Name = "Order_Meat_Meat")]
        public String Meat { get; set; }

       [Display(ResourceType = typeof (GlobalResource), Name = "Order_Beans_Beans")]
        public String Beans { get; set; }

         [Display(ResourceType = typeof (GlobalResource), Name = "Order_PriceGroup_Discount_Group")]
        public String PriceGroup { get; set; }
        
        [Display(ResourceType = typeof (GlobalResource), Name = "Order_OrderCost_Cost")]
        public Decimal OrderCost { get; set; }
    }
}