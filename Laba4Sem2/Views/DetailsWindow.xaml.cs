using System.Windows;
using System.Windows.Controls;
using Laba4Sem2.Model;

namespace Laba4Sem2.Views
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public Room Room { get; set; }

        public DetailsWindow(Room room)
        {
            InitializeComponent();
            Room = room;
            DataContext = this;
        }
        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e) => editBtn.IsEnabled = table.SelectedItem != null;

        private void NewAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalForm aAW = new AnimalForm(Room)
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            aAW.ShowDialog();
        }

        private void EditAnimal_Click(object sender, RoutedEventArgs e)
        {
            var selectedAnimal = table.SelectedItem as AccUnit;
            AnimalForm aAW = new AnimalForm(Room, table.SelectedIndex)
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            aAW.animalName.Text = selectedAnimal.Animal.AnimalName;
            aAW.country.Text = selectedAnimal.Animal.Country;
            aAW.ownName.Text = selectedAnimal.Animal.OwnName;
            aAW.bornDate.Text = selectedAnimal.Animal.Born.ToShortDateString();
            aAW.maintenanceCost.Text = selectedAnimal.MaintenanceCost.ToString();
            aAW.ShowDialog();
            table.Items.Refresh();
        }
    }
}
