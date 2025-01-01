using System;
using System.Collections.Generic;
using System.Data.Common;

namespace PassTask13
{
    /// <summary>
    /// Represents a shop admin.
    /// </summary>
    public class ShopAdmin:User{

        #nullable disable
        private List<Customer> _customers;
        private List<TradingCard> _tradingCardsInventory;

        /// <summary>
        /// Initializes a new instance of the ShopAdmin class.
        /// </summary>
        public ShopAdmin(string username, string password):base(username, password){
            _customers = new List<Customer>();
            _tradingCardsInventory = new List<TradingCard>();
        }


        /// <summary>
        /// Gets or sets the list of customers.
        /// </summary>
        public List<Customer> GetCustomersList{
            get{return _customers;}
            set{_customers = value;}
        }

        /// <summary>
        /// Gets or sets the trading cards inventory.
        /// </summary>
        public List<TradingCard> GetTradingCardsInventory{
            get{return _tradingCardsInventory;}
            set{_tradingCardsInventory = value;}
        }


        /// <summary>
        /// Adds a new customer.
        /// </summary>
        public void AddCustomer(){
            var random = new Random();
            int id = random.Next(10000, 100000);
        
            Console.WriteLine("Enter new customer name:");
            string name = Console.ReadLine();
        
            Customer newCustomer = new Customer(id, name);
            _customers.Add(newCustomer);
        }

        /// <summary>
        /// Adds a new trading card.
        /// </summary>
        public void AddTradingCard(){
            Console.WriteLine("Enter card series:");
            int cardSeries = int.Parse(Console.ReadLine());
        
            Console.WriteLine("Enter card name:");
            string cardName = Console.ReadLine();
        
            Console.WriteLine("Enter card rarity (Common, Uncommon, Rare, Legendary):");
            Rarity cardRarity;
            Enum.TryParse(Console.ReadLine(), out cardRarity);
        
            Console.WriteLine("Enter card colour:");
            string cardColour = Console.ReadLine();
        
            Console.WriteLine("Is the card foil? (yes/no):");
            bool isFoil = Console.ReadLine().ToLower() == "yes";
        
            Console.WriteLine("Enter card price:");
            double cardPrice = double.Parse(Console.ReadLine());
        
            Console.WriteLine("Enter card stock:");
            int cardStock = int.Parse(Console.ReadLine());
        
            Console.WriteLine("Is the card on promotion? (yes/no):");
            bool isPromotion = Console.ReadLine().ToLower() == "yes";
        
            TradingCard newCard = new TradingCard(cardSeries, cardName, cardRarity, cardColour, isFoil, cardPrice, cardStock, isPromotion);
            _tradingCardsInventory.Add(newCard);
            Console.WriteLine($"Card {cardName} has been successfully added.");
        }


        /// <summary>
        /// Adds a new booking for a customer.
        /// </summary>
        public void AdminAddBooking(Customer newCustomer)
        {
            Console.WriteLine("Enter booking name:");
            string bookingName = Console.ReadLine();
        
            Console.WriteLine("Enter booking start date and time (dd-MM-yyyy HH:mm):");
            DateTime bookingStart = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter booking end date and time (dd-MM-yyyy HH:mm):");
            DateTime bookingEnd = DateTime.Parse(Console.ReadLine());
        
            foreach (Customer customer in _customers)
            {
                foreach (Booking existingBooking in customer.Bookings)
                {
                    if ((bookingStart >= existingBooking.BookingStart && bookingStart <= existingBooking.BookingEnd) ||
                        (bookingEnd >= existingBooking.BookingStart && bookingEnd <= existingBooking.BookingEnd))
                    {
                        Console.WriteLine("Booking dates clash with an existing booking.");
                        return;
                    }
                }
            }
        
            Booking booking = new Booking(bookingName, bookingStart, bookingEnd);
            double bookingPrice = booking.CalculateBookingPrice();
        
            string orderId = Guid.NewGuid().ToString();
            Order bookingOrder = new Order(orderId, DateTime.Now, OrderType.Booking, bookingPrice);
        
            newCustomer.Orders.Add(bookingOrder);
            newCustomer.Bookings.Add(booking);
        
            Console.WriteLine("Booking successfully added. (Admin)");
        }


        /// <summary>
        /// Edits a customer.
        /// </summary>
        public void EditCustomer(){
            Console.WriteLine("Enter customer ID to edit:");
            int id = int.Parse(Console.ReadLine());

            foreach (Customer currentCus in _customers){
                if (currentCus.CustomerID == id){
                    Console.WriteLine("Enter new customer name:");
                    currentCus.CustomerName = Console.ReadLine();

                    Console.WriteLine("Is the customer a member? (yes/no):");
                    currentCus.IsMember = Console.ReadLine().ToLower() == "yes";

                    if (currentCus.IsMember){
                        Console.WriteLine("Customer is now a member");
                    }else{
                        Console.WriteLine("Customer is no longer a member");
                    }
                    return;
                }
            }
            Console.WriteLine("Customer not found");
        }

        /// <summary>
        /// Edits a trading card.
        /// </summary>
        public void EditTradingCard(){
            Console.WriteLine("Enter card series to edit:");
            int cardSeries = int.Parse(Console.ReadLine());

            foreach (TradingCard card in _tradingCardsInventory){
                if (card.CardSeries == cardSeries){
                    Console.WriteLine("Enter new card name:");
                    card.CardName = Console.ReadLine();

                    Console.WriteLine("Enter new card rarity (Common, Uncommon, Rare, Legendary):");
                    Rarity cardRarity;
                    Enum.TryParse(Console.ReadLine(), out cardRarity);
                    card.CardRarity = cardRarity;

                    Console.WriteLine("Enter new card colour:");
                    card.CardColour = Console.ReadLine();

                    Console.WriteLine("Is the card foil? (yes/no):");
                    card.IsFoil = Console.ReadLine().ToLower() == "yes";

                    Console.WriteLine("Enter new card price:");
                    card.CardPrice = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter new card stock:");
                    card.CardStock = int.Parse(Console.ReadLine());

                    Console.WriteLine("Is the card on promotion? (yes/no):");
                    card.IsPromotion = Console.ReadLine().ToLower() == "yes";
                    return;
                }
            }
        }


        /// <summary>
        /// Deletes a customer.
        /// </summary>
        public void DeleteCustomer(){
            Console.WriteLine("Enter customer ID to delete:");
            int id = int.Parse(Console.ReadLine());

            foreach (Customer removeCus in _customers){
                if (removeCus.CustomerID == id){
                    _customers.Remove(removeCus);
                    return;
                }
            }
            Console.WriteLine("Customer not found");
        }

        /// <summary>
        /// Deletes a trading card.
        /// </summary>
        public void DeleteTradingCard(){
            Console.WriteLine("Enter card series to delete:");
            int cardSeries = int.Parse(Console.ReadLine());

            foreach (TradingCard card in _tradingCardsInventory){
                if (card.CardSeries == cardSeries){
                    _tradingCardsInventory.Remove(card);
                    return;
                }
            }
        }

        /// <summary>
        /// Cancels a booking.
        /// </summary>
        public void CancelBooking()
        {
            Console.WriteLine("Enter customer ID:");
            int customerId = int.Parse(Console.ReadLine());
        
            Console.WriteLine("Enter booking name:");
            string bookingName = Console.ReadLine();
        
            Customer customer = _customers.Find(c => c.CustomerID == customerId);
        
            if (customer == null)
            {
                Console.WriteLine("No customer found with that ID.");
                return;
            }
        
            Booking bookingToCancel = customer.Bookings.FirstOrDefault(b => b.BookingName == bookingName);
        
            if (bookingToCancel != null)
            {
                if (bookingToCancel.BookingStart > DateTime.Now.AddHours(24))
                {
                    customer.Bookings.Remove(bookingToCancel);
                    Console.WriteLine("Booking cancelled successfully. (Admin).");
                }
                else
                {
                    Console.WriteLine("Cancellation can only be made 24 hours prior to the start of the game.");
                }
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }


        /// <summary>
        /// Views all customers.
        /// </summary>
        public void ViewAllCustomers(){
            foreach (Customer customer in _customers){
                string membershipStatus = customer.IsMember ? "Member" : "Non-member";
                Console.WriteLine($"Customer ID: {customer.CustomerID}, Name: {customer.CustomerName}, Membership: {membershipStatus}");
            }
        }

        /// <summary>
        /// Searches for a trading card.
        /// </summary>
        public TradingCard SearchTradingCard()
        {
            Console.WriteLine("Enter card name to search:");
            string cardName = Console.ReadLine();
        
            foreach (TradingCard card in _tradingCardsInventory)
            {
                if (card.CardName == cardName)
                {
                    Console.WriteLine("\nCard found!\n");
                    Console.WriteLine($"Card Name: {card.CardName}");
                    Console.WriteLine($"Series Name: {card.CardSeries}");
                    Console.WriteLine($"Colour: {card.CardColour}");
                    Console.WriteLine($"Rarity: {card.CardRarity}");
                    Console.WriteLine($"Foil: {card.IsFoil}");
                    Console.WriteLine($"Price: {card.CardPrice}");
                    Console.WriteLine($"Stock: {card.CardStock}");
                    Console.WriteLine($"Promotion: {card.IsPromotion}");
                    return card;
                }
            }
            Console.WriteLine("Card doesn't exist.");
            return null;
        }

        /// <summary>
        /// Views booking details for a customer on a specific date.
        /// </summary>
        public void ViewBookingDetailsCustomerNameAndDate(){
            Console.WriteLine("Enter customer ID:");
            int customerId = int.Parse(Console.ReadLine());
        
            Console.WriteLine("Enter date (dd-MM-yyyy):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Customer customer = _customers.Find(c => c.CustomerID == customerId);
        
            if (customer == null)
            {
                Console.WriteLine("No customer found with that ID.");
                return;
            }
        
            var bookingsOnDate = customer.Bookings.Where(b => b.BookingStart.Date == date.Date);
        
            if (!bookingsOnDate.Any())
            {
                Console.WriteLine("No bookings found on that date for this customer.");
                return;
            }
        
            foreach (var booking in bookingsOnDate)
            {
                Console.WriteLine($"Booking for {customer.CustomerName}: Name: {booking.BookingName}, Start: {booking.BookingStart}, End: {booking.BookingEnd}");
            }
        }

        /// <summary>
        /// Views low inventory stock.
        /// </summary>
        public void ViewLowInventoryStock(){
            int LowStockThreshold = 5;

            foreach (TradingCard card in _tradingCardsInventory){
                if (card.CardStock < LowStockThreshold){
                    Console.WriteLine($"Card Series: {card.CardSeries}, Name: {card.CardName}, Stock: {card.CardStock}");
                }
            }
        }

        /// <summary>
        /// Views customer purchases.
        /// </summary>
        public void ViewCustomerPurchases()
        {
            Console.WriteLine("Enter customer ID to view purchases:");
            int id = int.Parse(Console.ReadLine());
        
            Customer customer = _customers.Find(c => c.CustomerID == id);
        
            if (customer == null)
            {
                Console.WriteLine("No customer found with that ID.");
                return;
            }
        
            Console.WriteLine($"Purchases for {customer.CustomerName}:");
            foreach (Order order in customer.Orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}, Type: {order.OrderType}, Price: {order.OrderPrice}");
            }
        }
    }
}
