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
        public event EventHandler<Ticket> TicketEventHandler;

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
                SlotMachineWindow window = new SlotMachineWindow(title, TicketEventHandler);
                window.Owner = slotMachine;
                window.Show();
            } else
            {
                MessageBox.Show("Keine gültige Adresse.");
            }
        }
    }
}
