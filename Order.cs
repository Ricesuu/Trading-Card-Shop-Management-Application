using System;

namespace PassTask13
{
    /// <summary>
    /// Represents an order.
    /// </summary>
    public class Order
    {
        private string _orderId;
        private DateTime _orderDate;
        private OrderType _orderType;
        private double _orderPrice;

        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order(string orderID, DateTime orderDate, OrderType orderType, double orderPrice)
        {
            _orderId = orderID;
            _orderDate = orderDate;
            _orderType = orderType;
            _orderPrice = orderPrice;
        }

        /// <summary>
        /// Gets the ID of the order.
        /// </summary>
        public string OrderId{
            get { return _orderId; }
        }

        /// <summary>
        /// Gets the date of the order.
        /// </summary>
        public DateTime OrderDate{
            get { return _orderDate; }
        }

        /// <summary>
        /// Gets the type of the order.
        /// </summary>
        public OrderType OrderType{
            get { return _orderType; }
        }

        /// <summary>
        /// Gets or sets the price of the order.
        /// </summary>
        public double OrderPrice{
            get { return _orderPrice; }
            set { _orderPrice = value; }
        }
    }

    /// <summary>
    /// Represents the type of an order.
    /// </summary>
    public enum OrderType{
            Membership,
            TradingCard,
            Booking
    }
}