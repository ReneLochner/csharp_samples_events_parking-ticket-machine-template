using System;
using System.Windows;
using ParkingTicketMachine.Core;

namespace ParkingTicketMachine.Wpf
{
    /// <summary>
    /// Interaction logic for SlotMachineWindow.xaml
    /// </summary>
    public partial class SlotMachineWindow
    {
        public SlotMachine SlotMachine { get; set; }
        public SlotMachineWindow(string title, EventHandler<Ticket> ticketReady)
        {
            InitializeComponent();
            this.Title = title;
            SlotMachine = new SlotMachine(Title);
            SlotMachine.LogTicket += ticketReady;
        }

        private void ButtonInsertCoin_Click(object sender, RoutedEventArgs e)
        {
            int selectedCoinIndex = ListBoxCoins.SelectedIndex;
            if(selectedCoinIndex < -1)
            {
                MessageBox.Show("Keine Münze eingeworfen.");
                return;
            }
            int selectedCoinValue = SlotMachine.COIN_INSERT_OPTIONS[selectedCoinIndex];
            TextBoxTimeUntil.Text = SlotMachine.CalcTotalParkingTime(selectedCoinValue);
        }

        private void ButtonPrintTicket_Click(object sender, RoutedEventArgs e)
        {
            SlotMachine.Print(SlotMachine.Title, SlotMachine.Sum);
            MessageBox.Show($"Sie dürfen bis {SlotMachine.ValidUntil.ToString("dd.MM.yyyy HH:mm")} parken!");
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            SlotMachine.Cancel();
            TextBoxTimeUntil.Text = "";

            FastClock.Instance.IsRunning = true;
        }
    }
}
