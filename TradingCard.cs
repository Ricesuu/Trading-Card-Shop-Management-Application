using System;

namespace PassTask13
{
    /// <summary>
    /// Represents a trading card.
    /// </summary>
    public class TradingCard{
        private string _cardName;
        private int _cardSeries;
        private Rarity _cardRarity;
        private string _cardColour;
        private bool _isFoil;
        private double _cardPrice;
        private int _cardStock;
        private bool _isPromotion;

        /// <summary>
        /// Initializes a new instance of the TradingCard class.
        /// </summary>
        public TradingCard(int cardSeries, string cardName, Rarity cardRarity, string cardColour, bool isFoil, double cardPrice, int cardStock, bool isPromotion){
            _cardSeries = cardSeries;
            _cardName = cardName;
            _cardRarity = cardRarity;
            _cardColour = cardColour;
            _isFoil = isFoil;
            _cardPrice = cardPrice;
            _cardStock = cardStock;
            _isPromotion = isPromotion;
        }

        /// <summary>
        /// Gets or sets the series of the card.
        /// </summary>
        public int CardSeries
        {
            get { return _cardSeries; }
            set { _cardSeries = value; }
        }

        /// <summary>
        /// Gets or sets the name of the card.
        /// </summary>
        public string CardName
        {
            get { return _cardName; }
            set { _cardName = value; }
        }

        /// <summary>
        /// Gets or sets the rarity of the card.
        /// </summary>
        public Rarity CardRarity
        {
            get { return _cardRarity; }
            set { _cardRarity = value; }
        }

        /// <summary>
        /// Gets or sets the colour of the card.
        /// </summary>
        public string CardColour
        {
            get { return _cardColour; }
            set { _cardColour = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the card is foil.
        /// </summary>
        public bool IsFoil
        {
            get { return _isFoil; }
            set { _isFoil = value; }
        }

        /// <summary>
        /// Gets or sets the price of the card.
        /// </summary>
        public double CardPrice
        {
            get { return _cardPrice; }
            set { _cardPrice = value; }
        }

        /// <summary>
        /// Gets or sets the stock of the card.
        /// </summary>
        public int CardStock
        {
            get { return _cardStock; }
            set { _cardStock = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the card is on promotion.
        /// </summary>
        public bool IsPromotion
        {
            get { return _isPromotion; }
            set { _isPromotion = value; }
        }
    }

    /// <summary>
    /// Represents the rarity of a trading card.
    /// </summary>
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary
    }
}