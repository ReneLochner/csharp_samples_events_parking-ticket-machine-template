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

        public string CalcTotalParkingTime(int coin)
        {
            int minutes = 0;
            DateTime time = DateTime.Now;

            FastClock.Instance.IsRunning = false;

            Sum += coin;

            if(Sum >= MIN_COIN_INPUT && Sum < 100)
            {
                minutes = HALF_AN_HOUR_TARIFF;
            }
            else if(Sum >= 100 && Sum < 150)
            {
                minutes = 2 * HALF_AN_HOUR_TARIFF;
            }
            else if(Sum >= 150)
            {
                minutes = MAX_PARKING_TIME;
            }

            if(time >= FREE_PARKING_START_TIME && time <= FREE_PARKING_END_TIME)
            {
                ValidUntil = FastClock.Instance.Time.AddMinutes(minutes + FREE_PARKING_START_TIME.TimeOfDay.TotalMinutes);
            }

            ValidUntil = FastClock.Instance.Time.AddMinutes(minutes);

            return ValidUntil.ToString("dd.MM.yyyy HH:mm");
        }

        public void Print(string title, int sum)
        {
            _ticket = new Ticket();
            _ticket.Title = title;
            _ticket.Sum = sum;
            sum = 0;
            LogTicket?.Invoke(this, _ticket);
        }

        public void Cancel()
        {
            Sum = 0;
        }
    }
}
