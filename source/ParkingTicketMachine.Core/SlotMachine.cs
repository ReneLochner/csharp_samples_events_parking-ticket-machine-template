using System;
using System.Collections.Generic;

namespace ParkingTicketMachine.Core
{
    public class SlotMachine
    {
        public event EventHandler<Ticket> LogTicket;
        private Ticket _ticket;
        public static readonly List<int> COIN_INSERT_OPTIONS = new List<int>() { 10, 20, 50, 100, 200 };
        public static readonly int MIN_COIN_INPUT = 50;
        public static readonly int HALF_AN_HOUR_TARIFF = 30;
        public static readonly int MAX_PARKING_TIME = 90;
        public static readonly DateTime FREE_PARKING_START_TIME = DateTime.Parse("18:00");
        public static readonly DateTime FREE_PARKING_END_TIME = DateTime.Parse("8:00");

        public string Title { get; }
        public int Sum { get; private set; }
        public DateTime ValidUntil { get; private set; }
        public SlotMachine(string title)
        {
            this.Title = title;
        }
        }
    }
}
