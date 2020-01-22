using ParkingTicketMachine.Core;
using System;
using System.Text;
using System.Windows;

namespace ParkingTicketMachine.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public event EventHandler<SlotMachine> CreateNewSlotMachine;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            this.Title = SetWindowTitle();
            OnCreateNewSlotMachine(new SlotMachine("Limesstrasse"));
            OnCreateNewSlotMachine(new SlotMachine("Landstrasse"));
        }

        private string SetWindowTitle()
        {
            return $"Parkscheinzentrale, {FastClock.Instance.Time.ToString("HH:mm:ss")}";
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            OnCreateNewSlotMachine(new SlotMachine(TextBoxAddress.Text));
        }

        protected virtual void OnCreateNewSlotMachine(SlotMachine slotMachine)
        {
            string title = slotMachine.Title;
            if (title.Length > 0) {
                CreateNewSlotMachine?.Invoke(this, slotMachine);
                SlotMachineWindow window = new SlotMachineWindow(title, OnReadyTicket);
                window.Show();
            } else
            {
                MessageBox.Show("Keine gültige Adresse.");
            }
        }

        private void OnReadyTicket(object sender, Ticket ticket)
        {
            string text = $"{ticket.Title}: ";
            AddSoldTicketEntry(text, ticket.Sum);
        }

        private void AddSoldTicketEntry(string line, int sum)
        {
            StringBuilder text = new StringBuilder(TextBlockLog.Text);
            text.Append("\n");
            text.Append(FastClock.Instance.Time.ToString("HH:mm") + "\t");
            text.Append(line + "\t");
            text.Append(FastClock.Instance.Time.ToString() + "\t");
            text.Append($"{sum} Cent");
            TextBlockLog.Text = text.ToString();
        }
    }
}