using System;
using System.Collections.Generic;
using System.Text;

namespace scrm {
     public class order {
        public  int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string DeliveryAddress { get; set; }
        public List<product> ProductList { get; set; }
    }
}
