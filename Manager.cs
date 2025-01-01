using System;
using System.Collections.Generic;
using System.Linq;

namespace PassTask13
{
    /// <summary>
    /// Represents a manager user.
    /// </summary>
    public class Manager:User
    {
        #nullable disable

        /// <summary>
        /// Initializes a new instance of the Manager class.
        /// </summary>
        public Manager(string username, string password):base(username, password){
        }

        /// <summary>
        /// Allows the manager to view and filter trading cards.
        /// </summary>
        public void ViewAndFilterTradingCards(ShopAdmin adminView){
            Console.WriteLine("Enter filter type (Name, Series, Rarity, Colour, Foiled, NonFoil):");
            string filter = Console.ReadLine();

            switch (filter){
                case "Name":
                    Console.WriteLine("What name would you like to filter by?");
                    string name = Console.ReadLine();
                    foreach (TradingCard card in adminView.GetTradingCardsInventory){
                        if (card.CardName == name){
                            Console.WriteLine($"Card Series: {card.CardSeries}, Name: {card.CardName}, Rarity: {card.CardRarity}, Colour: {card.CardColour}, Foil: {card.IsFoil}, Stock: {card.CardStock}");
                        }
                    }
                    break;
                case "Series":
                    Console.WriteLine("What series number would you like to filter by?");
                    int series = int.Parse(Console.ReadLine());
                    foreach (TradingCard card in adminView.GetTradingCardsInventory){
                        if (card.CardSeries == series){
                            Console.WriteLine($"Card Series: {card.CardSeries}, Name: {card.CardName}, Rarity: {card.CardRarity}, Colour: {card.CardColour}, Foil: {card.IsFoil}, Stock: {card.CardStock}");
                        }
                    }
                    break;
                case "Rarity":
                    Console.WriteLine("What rarity would you like to filter by?");
                    string rarity = Console.ReadLine();
                    foreach (TradingCard card in adminView.GetTradingCardsInventory){
                        if (card.CardRarity.ToString() == rarity){
                            Console.WriteLine($"Card Series: {card.CardSeries}, Name: {card.CardName}, Rarity: {card.CardRarity}, Colour: {card.CardColour}, Foil: {card.IsFoil}, Stock: {card.CardStock}");
                        }
                    }
                    break;
                case "Colour":
                    Console.WriteLine("What colour would you like to filter by?");
                    string colour = Console.ReadLine();
                    foreach (TradingCard card in adminView.GetTradingCardsInventory){
                        if (card.CardColour == colour){
                            Console.WriteLine($"Card Series: {card.CardSeries}, Name: {card.CardName}, Rarity: {card.CardRarity}, Colour: {card.CardColour}, Foil: {card.IsFoil}, Stock: {card.CardStock}");
                        }
                    }
                    break;
                case "Foiled":
                    foreach (TradingCard card in adminView.GetTradingCardsInventory){
                        if (card.IsFoil){
                            Console.WriteLine($"Card Series: {card.CardSeries}, Name: {card.CardName}, Rarity: {card.CardRarity}, Colour: {card.CardColour}, Foil: {card.IsFoil}, Stock: {card.CardStock}");
                        }
                    }
                    break;
                case "NonFoil":
                    foreach (TradingCard card in adminView.GetTradingCardsInventory){
                        if (!card.IsFoil){
                            Console.WriteLine($"Card Series: {card.CardSeries}, Name: {card.CardName}, Rarity: {card.CardRarity}, Colour: {card.CardColour}, Foil: {card.IsFoil}, Stock: {card.CardStock}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid filter");
                    break;
            }
        }

        /// <summary>
        /// Allows the manager to view booking details by date and time.
        /// </summary>
        public void ViewBookingDetailsDateAndTime(ShopAdmin admin)
        {
            Console.WriteLine("Enter start date (dd-MM-yyyy):");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
        
            Console.WriteLine("Enter end date (dd-MM-yyyy):");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
        
            foreach (Customer customer in admin.GetCustomersList)
            {
                foreach (Booking booking in customer.Bookings)
                {
                    if (booking.BookingStart.Date >= startDate.Date && booking.BookingEnd.Date <= endDate.Date)
                    {
                        Console.WriteLine($"Booking Name: {booking.BookingName}, Start Date: {booking.BookingStart}, End Date: {booking.BookingEnd}");
                    }
                }
            }
        }

        /// <summary>
        /// Allows the manager to view loyal customers.
        /// </summary>
        public void ViewLoyalCustomers(ShopAdmin admin)
        {
            foreach (Customer customer in admin.GetCustomersList){
                if (customer.TotalPurchases > 1000){
                    Console.WriteLine($"Customer Name: {customer.CustomerName}, Total Purchases: {customer.TotalPurchases}");
                }
            }
        }

        /// <summary>
        /// Allows the manager to view sales daily or monthly.
        /// </summary>
        public void ViewSalesDailyMonthly(ShopAdmin admin)
        {
            Console.WriteLine("Enter time period (Daily or Monthly):");
            string timePeriod = Console.ReadLine();

            switch (timePeriod)
            {
                case "Daily":
                    DateTime today = DateTime.Today;
                    double totalSales = 0;
                    foreach (Customer customer in admin.GetCustomersList)
                    {
                        foreach (Order order in customer.Orders)
                        {
                            if (order.OrderType == OrderType.TradingCard && order.OrderDate.Date == today)
                            {
                                totalSales += order.OrderPrice;
                            }
                        }
                    }
                    Console.WriteLine($"Total sales for today: {totalSales}");
                    break;
                case "Monthly":
                    DateTime thisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    double totalMonthlySales = 0;
                    foreach (Customer customer in admin.GetCustomersList)
                    {
                        foreach (Order order in customer.Orders)
                        {
                            if (order.OrderType == OrderType.TradingCard && order.OrderDate.Month == thisMonth.Month && order.OrderDate.Year == thisMonth.Year)
                            {
                                totalMonthlySales += order.OrderPrice;
                            }
                        }
                    }
                    Console.WriteLine($"Total sales for this month: {totalMonthlySales}");
                    break;
                default:
                    Console.WriteLine("Invalid time period");
                    break;
            }
        }

        /// <summary>
        /// For Unit Testing
        /// </summary>
        /// 
        public List<string> ViewBookingDetailsDateAndTimeTest(ShopAdmin admin, DateTime startDate, DateTime endDate)
        {
            List<string> bookingDetails = new List<string>();
        
            foreach (Customer customer in admin.GetCustomersList)
            {
                foreach (Booking booking in customer.Bookings)
                {
                    if (booking.BookingStart.Date >= startDate.Date && booking.BookingEnd.Date <= endDate.Date)
                    {
                        string detail = $"Booking Name: {booking.BookingName}, Start Date: {booking.BookingStart}, End Date: {booking.BookingEnd}";
                        bookingDetails.Add(detail);
                        Console.WriteLine(detail);
                    }
                }
            }
        
            return bookingDetails;
        }
        
        public List<string> ViewLoyalCustomersTest(ShopAdmin admin)
        {
            List<string> loyalCustomers = new List<string>();
        
            foreach (Customer customer in admin.GetCustomersList)
            {
                if (customer.TotalPurchases > 1000)
                {
                    string detail = $"Customer Name: {customer.CustomerName}, Total Purchases: {customer.TotalPurchases}";
                    loyalCustomers.Add(detail);
                    Console.WriteLine(detail);
                }
            }
        
            return loyalCustomers;
        }
    }
}
