using System.Windows;
using Laba4Sem2.Model;

namespace Laba4Sem2.Views
{
    /// <summary>
    /// Interaction logic for AnimalForm.xaml
    /// </summary>
    public partial class AnimalForm : Window
    {
        private readonly Room room;
        private readonly int selectedIndex;

        public AnimalForm(Room room, int index = -1)
        {
            InitializeComponent();
            DataContext = this;
            this.room = room;
            selectedIndex = index;
            Title = selectedIndex == -1 ? "Register" : "Edit";
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            int maintCost = Convert.ToInt32(maintenanceCost.Text);
            string _animalName = animalName.Text;
            string _country = country.Text;
            string _ownName = ownName.Text;
            DateTime _bornDate = bornDate.SelectedDate!.Value;

            if (selectedIndex == -1)
            {
                Animal animal = new Animal(_animalName, _country, _ownName, _bornDate);
                room.AddAnimal(new AccUnit(animal, DateTime.Now, maintCost));
            }
            else
            {
                DateTime dateOfArrival = room.Animals[selectedIndex].DateOfArrival;
                room.Animals[selectedIndex].Animal.AnimalName = _animalName;
                room.UpdateAnimal(selectedIndex, new AccUnit(new Animal(_animalName, _country, _ownName, _bornDate), dateOfArrival, maintCost));
            }
            this.Close();
        }
    }
}
