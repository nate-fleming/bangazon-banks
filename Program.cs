using System;
using System.Collections.Generic;
using System.Linq;

namespace banks
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class BankReport
    {
        public string Bank { get; set; }

        public int NumberOfMillionares { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            List<BankReport> millionares = (from person in customers
                                            where person.Balance >= 1000000
                                            group person by person.Bank into bankGroup
                                            select new BankReport
                                            {
                                                Bank = bankGroup.Key,
                                                NumberOfMillionares = bankGroup.Count()
                                            }).ToList();


            foreach (BankReport report in millionares)
            {
                Console.WriteLine($"{report.Bank}: {report.NumberOfMillionares}");
            }



        }
    }
}
