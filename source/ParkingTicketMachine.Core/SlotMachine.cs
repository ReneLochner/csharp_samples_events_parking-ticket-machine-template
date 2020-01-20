using System;
using System.Collections.Generic;

namespace ParkingTicketMachine.Core
{
    public class SlotMachine
    {
        public static readonly List<int> COIN_INSERT_OPTIONS = new List<int>() { 10, 20, 50, 100, 200 };
        public static readonly int MIN_COIN_INPUT = 50;
        public static readonly int HALF_AN_HOUR_TARIFF = 30;
        public static readonly int MAX_PARKING_TIME = 90;
        public static readonly int FREE_PARKING_START_TIME = 18;
        public static readonly int FREE_PARKING_END_TIME = 8;

        public string Title { get; }
        public List<int> Coins { get; }
        public DateTime ParkingDuration { get; set; }

        public SlotMachine(string title)
        {
            this.Title = title;
            this.Coins = new List<int>();
        }
    }
}
