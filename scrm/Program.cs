using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using scrm;

namespace Scrm {
    class Program {
        public static List<product> products = new List<product>();
        public static List<string> idList = new List<string>();
        static void Main(string[] args)
        {
            var path = @"C:\Users\KCA12\source\repos\scrm\bin/products.csv";
            readFile(path);
            var firstCustomer = new customer("Georgios")
            {
                CustId = 1
            };
            var secondCustomer = new customer("Kotsidis")
            {
                CustId = 2
            };
            var firstOrder = new order();
            var seconOrder = new order();
            for (var i = 0; i < products.Count; i++) {
                Console.WriteLine($"product Id is   {products[i].ProductId} " +
                    $" description is    {products[i].Description}" +
                    $" price is  {products[i].Price} ");
            }
            decimal sumFirst = 0;
            decimal sumSecond = 0;
            firstOrder.ProductList = (CustomerProductListGenerate(products));
            foreach (product X in firstOrder.ProductList) {
                firstOrder.TotalAmount += X.Price;
            }
            foreach (product y in seconOrder.ProductList) {
               seconOrder.TotalAmount += y.Price;
            }
            for (var i = 0; i < 10; i++) {
                firstOrder.ProductList.Add(products[i]);
                Console.WriteLine(products[i].Description);
                sumFirst = sumFirst + products[i].Price;
            }
            for (var i = 0; i < 10; i++) {
                seconOrder.ProductList.Add(products[i]);
                sumSecond = sumSecond + products[i].Price;
            }
             firstCustomer.Order.Add(firstOrder);
             secondCustomer.Order.Add(seconOrder);
            if (sumFirst == null || sumSecond == null) {
                throw new ArgumentNullException();
            }
            if (sumFirst > sumSecond) {
                Console.WriteLine($"The {firstCustomer}make a bigger order");
            } else if (sumSecond > sumFirst) {
                Console.WriteLine($"The {secondCustomer}make a biger order");
            } else
                Console.WriteLine("the two orders are equals");
        }
            public static void readFile(string file)
        {
            if (file == null) {
                throw new ArgumentNullException();
            }
            using (var read = File.OpenText(file)) {
                while (!read.EndOfStream) {
                    var line = read.ReadLine();
                    var spliting = line.Split(';');
                    var productEntry = new product();
                    var price = RandomNum();
                    idList.Add(spliting[0]);
                    if (!checkId(idList, spliting[0])) {
                        productEntry.Price = price;
                        productEntry.ProductId = spliting[0];
                        productEntry.Description = spliting[1];
                        products.Add(productEntry);
                    }
                }
            }
        }
        public static decimal RandomNum()
        {
            Random value = new Random();
            var randomNum = value.NextDouble() + value.Next(1, 1000);
            var randomNum2 = randomNum.ToString("0.00");
            var price = System.Convert.ToDecimal(randomNum2);
            if (price == 0) {
                throw new ArgumentNullException();
            }
            return price;
        }
        public static List<product> CustomerProductListGenerate(List<product> productList)
        {
            var CustomerProductList = new List<product>();
            Random r = new Random();
            for (var i = 0; i < 10; i++) {
                var randomIndex = r.Next(0, productList.Count);
                CustomerProductList.Add(productList[randomIndex]);
            }
            return CustomerProductList;
        }
        public static bool checkId(List<string> list, string id)
        {
            if (list == null) {
                throw new ArgumentNullException();
            }
            if (id == null) {
                throw new ArgumentNullException();
            }
            if (!string.IsNullOrWhiteSpace(id)) {
                list.SingleOrDefault(s => s.Equals(id));
                return false;
            } else {
                throw new Exception("Id is not unique");
            }
        }
    }
}