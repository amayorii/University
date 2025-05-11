using System.Windows;
using Laba4Sem2.Model;

namespace Laba4Sem2.Views
{
    /// <summary>
    /// Interaction logic for ViewMoreWindow.xaml
    /// </summary>
    public partial class ViewMoreWindow : Window
    {
        public Room Room { get; set; }

        public ViewMoreWindow(Room room)
        {
            InitializeComponent();
            Room = room;
            DataContext = this;
        }
        private void NewAnimal_Click(object sender, RoutedEventArgs e)
        {
            AddAnimalWindow aAW = new AddAnimalWindow(Room)
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            aAW.ShowDialog();
        }
    }
}
