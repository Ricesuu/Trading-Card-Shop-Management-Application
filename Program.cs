using System;
using SplashKitSDK;

namespace PassTask13
{
    public class Program
    {
        #nullable disable
        public static void Main()
        {
            // Create Manager and ShopAdmin objects
            Manager manager = new Manager("manager", "manager");
            ShopAdmin shopAdmin = new ShopAdmin("admin", "admin");

            bool loggedIn = false;
            bool managerLoggedIn = false;
            bool adminLoggedIn = false;

            // Predefined list of customers
            shopAdmin.GetCustomersList = new List<Customer>{
                new Customer(10277, "Ivan Sim"),
                new Customer(10278, "Kok Khin Heng"),
                new Customer(10279, "Ling"),
                new Customer(10280, "Haziq"),
                new Customer(10281, "Isaac")
            };
            
            // Predefined list of orders for each customer
            foreach (var customer in shopAdmin.GetCustomersList)
            {
                customer.Orders = new List<Order>{
                    new Order(Guid.NewGuid().ToString(), DateTime.Now, OrderType.Membership, 1000),
                    new Order(Guid.NewGuid().ToString(), DateTime.Now, OrderType.TradingCard, 1000),
                    new Order(Guid.NewGuid().ToString(), DateTime.Now, OrderType.Booking, 1000)
                };
            }
            
            // Predefined list of bookings for each customer
            foreach (var customer in shopAdmin.GetCustomersList)
            {
                customer.Bookings = new List<Booking>{
                    new Booking("Booking1", new DateTime(2024, 06, 22, 05, 0, 0), new DateTime(2024, 06, 22, 08, 0, 0)),
                    new Booking("Booking2", new DateTime(2024, 02, 26, 14, 0, 0), new DateTime(2024, 02, 26, 17, 0, 0)),
                    new Booking("Booking3", new DateTime(2024, 11, 30, 18, 0, 0), new DateTime(2024, 11, 30, 21, 0, 0))
                };
            }

            shopAdmin.GetTradingCardsInventory = new List<TradingCard>{
                new TradingCard(1, "Charizard", Rarity.Legendary, "Orange", true, 100.0, 1, false),
                new TradingCard(2, "Squirtle", Rarity.Common, "Blue", false, 8.0, 100, true),
                new TradingCard(3, "Bulbasaur", Rarity.Rare, "Green", false, 15.0, 6, false),
                new TradingCard(4, "Pikachu", Rarity.Common, "Yellow", true, 10.0, 9, false),
            };



            // Loop until a user is logged in
            while (!loggedIn)
            {
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                if (username == "manager" && password == "manager")
                {
                    managerLoggedIn = true;
                    loggedIn = true;
                }
                else if (username == "admin" && password == "admin")
                {
                    adminLoggedIn = true;
                    loggedIn = true;
                }
                else
                {
                    Console.WriteLine("Login failed. Try Again.");
                }
            }

            // Loop for Manager
            while (managerLoggedIn)
            {
                Console.WriteLine("\n================================");
                Console.WriteLine("Welcome Neko Neko Nyaa Shop Manager!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("================================");
                Console.WriteLine("Trading Card Management:");
                Console.WriteLine("1. Filter trading cards");
                Console.WriteLine("\nBooking Management:");
                Console.WriteLine("2. View booking details (by date and time)");
                Console.WriteLine("\nSales Management:");
                Console.WriteLine("3. View sales daily/monthly");
                Console.WriteLine("\nCustomer Management:");
                Console.WriteLine("4. View loyal customers");
                Console.WriteLine("\n5. Exit");
                Console.WriteLine("================================\n");
            
                Console.WriteLine("Enter your choice:");
                string input = Console.ReadLine();
            
                switch (input)
                {
                    case "1":
                        manager.ViewAndFilterTradingCards(shopAdmin);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        manager.ViewBookingDetailsDateAndTime(shopAdmin);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        manager.ViewSalesDailyMonthly(shopAdmin);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        manager.ViewLoyalCustomers(shopAdmin);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Logging out...");
                        managerLoggedIn = false;
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }

            // Loop for ShopAdmin
            while (adminLoggedIn)
            {
                Console.Write("\n==================================\n");
                Console.Write("Welcome Neko Neko Nyaa Shop Admin!\n");
                Console.Write("What would you like to do?\n");
                Console.Write("==================================\n");
                Console.Write("Customer Management:\n");
                Console.Write("1. Add a customer\n");
                Console.Write("2. Edit a customer\n");
                Console.Write("3. Delete a customer\n");
                Console.Write("4. View all customers\n");
                Console.Write("5. View customer purchases\n");
                Console.Write("\nTrading Card Management:\n");
                Console.Write("6. Add a trading card\n");
                Console.Write("7. Edit a trading card\n");
                Console.Write("8. Delete a trading card\n");
                Console.Write("9. Search for trading card\n");
                Console.Write("10. View low inventory stock\n");
                Console.Write("\nBooking Management:\n");
                Console.Write("11. Add a booking for a customer\n");
                Console.Write("12. Cancel a booking for a customer\n");
                Console.Write("13. View booking details (by customer ID and date)\n");
                Console.Write("\n14. Exit\n");
                Console.Write("==================================\n\n");
            
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();
            
                switch (input)
                {
                    case "1":
                        shopAdmin.AddCustomer();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        shopAdmin.EditCustomer();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        shopAdmin.DeleteCustomer();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        shopAdmin.ViewAllCustomers();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        shopAdmin.ViewCustomerPurchases();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "6":
                        shopAdmin.AddTradingCard();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "7":
                        shopAdmin.EditTradingCard();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "8":
                        shopAdmin.DeleteTradingCard();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "9":
                        shopAdmin.SearchTradingCard();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "10":
                        shopAdmin.ViewLowInventoryStock();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "11":
                        Console.WriteLine("Enter Customer ID for booking: ");
                        int bookingCustomerId = int.Parse(Console.ReadLine());
                        var bookingCustomer = shopAdmin.GetCustomersList.FirstOrDefault(c => c.CustomerID == bookingCustomerId);
                        if (bookingCustomer != null)
                        {
                            shopAdmin.AdminAddBooking(bookingCustomer);
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                        break;
                    case "12":
                            shopAdmin.CancelBooking();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        break;
                    case "13":
                        shopAdmin.ViewBookingDetailsCustomerNameAndDate();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "14":
                        Console.WriteLine("Logging out...");
                        adminLoggedIn = false;
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
