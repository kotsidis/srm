using System;
using System.Collections.Generic;
using System.Text;

namespace scrm {
    public class customer {
        public int CustId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<order> Order { get; set; }
        public customer(string LastName) { }
        }
}
