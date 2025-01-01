using System;

namespace PassTask13{
    /// <summary>
    /// Represents a purchase of a trading card.
    /// </summary>
    public class BuyTradingCard{
        private TradingCard _card;
        private int _orderQuantity;


        /// <summary>
        /// Initializes a new instance of the BuyTradingCard class.
        /// </summary>
        public BuyTradingCard(TradingCard card, int orderQuantity){
            _card = card;
            _orderQuantity = orderQuantity;
        }

        /// <summary>
        /// Calculates the total price of the trading card purchase.
        /// </summary>
        public double CalculateTotalPrice(){
            return _card.CardPrice * _orderQuantity;
        }
    }
}