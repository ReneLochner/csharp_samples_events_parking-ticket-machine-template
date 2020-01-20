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
        public SlotMachine Owner { get; set; }
        public SlotMachineWindow(string name, EventHandler<Ticket> ticketReady)
        {
            InitializeComponent();
            this.Title = name;
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
            Owner.Coins.Add(selectedCoinValue);
        }

        private void ButtonPrintTicket_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
