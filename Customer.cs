using System;
using System.Collections.Generic;

namespace PassTask13
{
    /// <summary>
    /// Represents a customer.
    /// </summary>
    public class Customer
    {
        #nullable disable
        private int _customerID;
        private string _customerName;
        private bool _isMember;
        private List<Order> _orders;
        private List<Booking> _bookings;
        private double _totalPurchases;

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        public Customer(int customerID, string customerName) 
        {
            _customerID = customerID;
            _customerName = customerName;
            _isMember = false;
            _orders = new List<Order>();
        }

        /// <summary>
        /// Gets the ID of the customer.
        /// </summary>
        public int CustomerID
        {
            get { return _customerID; }
        }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is a member.
        /// </summary>
        public bool IsMember
        {
            get { return _isMember; }
            set { _isMember = value; }
        }

        /// <summary>
        /// Gets or sets the orders of the customer.
        /// </summary>
        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        /// <summary>
        /// Gets or sets the bookings of the customer.
        /// </summary>
        public List<Booking> Bookings
        {
            get { return _bookings; }
            set { _bookings = value; }
        }

        /// <summary>
        /// Gets or sets the total purchases of the customer.
        /// </summary>
        public double TotalPurchases{
            get { return _totalPurchases; }
            set { _totalPurchases = value; }
        }

        /// <summary>
        /// Allows the customer to make an order.
        /// </summary>
        public void CustomerMakeOrder(ShopAdmin shopAdmin)
        {
            Console.WriteLine("Enter order type (Membership, TradingCard, Booking):");
            OrderType orderType = (OrderType)Enum.Parse(typeof(OrderType), Console.ReadLine());
        
            string orderId = Guid.NewGuid().ToString();
        
            switch (orderType)
            {
                case OrderType.Membership:
                    Order membershipOrder = new Order(orderId, DateTime.Now, OrderType.Membership, 20);
                    _isMember = true;
                    _orders.Add(membershipOrder);
                    break;
        
                case OrderType.TradingCard:
                    Console.WriteLine("Enter the name of the trading card:");
                    string cardName = Console.ReadLine();

                    TradingCard selectedCard = shopAdmin.GetTradingCardsInventory.FirstOrDefault(card => card.CardName == cardName);

                    if (selectedCard != null) {
                        Console.WriteLine("Enter the quantity you want to purchase:");
                        int quantity = int.Parse(Console.ReadLine());

                        if (selectedCard.CardStock < quantity) {
                            Console.WriteLine("Not enough stock available.");
                            break;
                        }

                        BuyTradingCard buyCard = new BuyTradingCard(selectedCard, quantity);
                        double totalPrice = buyCard.CalculateTotalPrice();

                        if (_isMember && !selectedCard.IsPromotion) {
                            totalPrice *= 0.8; 
                        }

                        Order tradingCardOrder = new Order(orderId, DateTime.Now, OrderType.TradingCard, totalPrice);
                        _orders.Add(tradingCardOrder);
                        Console.WriteLine("Total price: " + totalPrice);

                        selectedCard.CardStock -= quantity;
                    } else {
                        Console.WriteLine("Card not found/Transaction failed.");
                    }
                    break;
        
                case OrderType.Booking:
                    Console.WriteLine("Enter booking name:");
                    string bookingName = Console.ReadLine();
                
                    Console.WriteLine("Enter booking start date (dd-MM-yyyy HH:mm):");
                    DateTime bookingStart = DateTime.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Enter booking end date (dd-MM-yyyy HH:mm):");
                    DateTime bookingEnd = DateTime.Parse(Console.ReadLine());

                    foreach (Booking existingBooking in _bookings)
                    {
                        if ((bookingStart >= existingBooking.BookingStart && bookingStart <= existingBooking.BookingEnd) ||
                            (bookingEnd >= existingBooking.BookingStart && bookingEnd <= existingBooking.BookingEnd))
                        {
                            Console.WriteLine("Booking dates clash with an existing booking.");
                            return;
                        }
                    }

                    Booking booking = new Booking(bookingName, bookingStart, bookingEnd);
                    double bookingPrice = booking.CalculateBookingPrice();
                
                    Order bookingOrder = new Order(orderId, DateTime.Now, OrderType.Booking, bookingPrice);
                
                    _orders.Add(bookingOrder);
                    _bookings.Add(booking);
                    break;
                default:
                    Console.WriteLine("Invalid order type.");
                    break;
            }
        }

        /// <summary>
        /// Allows the customer to cancel a booking.
        /// </summary>
        public void CustomerCancelBooking()
        {
            Console.WriteLine("Enter booking name to cancel:");
            string bookingName = Console.ReadLine();
        
            Booking bookingToRemove = null;
        
            foreach (Booking booking in _bookings)
            {
                if (booking.BookingName == bookingName)
                {
                    if (booking.BookingStart > DateTime.Now.AddHours(24))
                    {
                        bookingToRemove = booking;
                        Console.WriteLine("Booking cancelled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Cancellation can only be made 24 hours prior to the start of the game.");
                    }
                    break;
                }
            }
        
            if (bookingToRemove != null)
            {
                _bookings.Remove(bookingToRemove);
            }
        }

        /// <summary>
        /// Calculates the total purchases of the customer.
        /// </summary>
        public void CalculateTotalPurchases()
        {
            TotalPurchases = 0;
            foreach (var order in _orders){
                TotalPurchases += order.OrderPrice;
            }
        }
    }
}