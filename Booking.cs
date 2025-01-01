using System;

namespace PassTask13
{
    /// <summary>
    /// Represents a booking.
    /// </summary>
    public class Booking
    {
        private string _bookingName;
        private DateTime _bookingStart;
        private DateTime _bookingEnd;

        /// <summary>
        /// Initializes a new instance of the Booking class.
        /// </summary>
        public Booking(string bookingName, DateTime bookingStart, DateTime bookingEnd)
        {
            _bookingName = bookingName;
            _bookingStart = bookingStart;
            _bookingEnd = bookingEnd;
        }

        /// <summary>
        /// Gets or sets the name of the booking.
        /// </summary>
        public string BookingName
        {
            get { return _bookingName; }
            set { _bookingName = value; }
        }

        /// <summary>
        /// Gets or sets the start time of the booking.
        /// </summary>
        public DateTime BookingStart
        {
            get { return _bookingStart; }
            set { _bookingStart = value; }
        }

        /// <summary>
        /// Gets or sets the end time of the booking.
        /// </summary>
        public DateTime BookingEnd
        {
            get { return _bookingEnd; }
            set { _bookingEnd = value; }
        }

        /// <summary>
        /// Gets the duration of the booking in hours.
        /// </summary>
        public double GetDurationInHours()
        {
            return (_bookingEnd - _bookingStart).TotalHours; 
        }

        /// <summary>
        /// Calculates the price of the booking.
        /// </summary>
        public double CalculateBookingPrice()
        {
            double hoursBooked = GetDurationInHours();
            int twoHourBlocks = (int)Math.Ceiling(hoursBooked / 2);
            return twoHourBlocks * 10; 
        }
    }
}