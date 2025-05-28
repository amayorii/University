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
            SaveAndClose sac = new SaveAndClose();
            int _maintCost = Convert.ToInt32(maintenanceCost.Text);
            string _animalName = animalName.Text;
            string _country = country.Text;
            string _ownName = ownName.Text;
            DateTime _bornDate = bornDate.SelectedDate!.Value;

            if (selectedIndex == -1)
            {
                Animal animal = new Animal(_animalName, _country, _ownName, _bornDate);
                AccUnit accU = new AccUnit(animal, DateTime.Now, _maintCost);

                room.AddAnimal(accU);
                if (sac.ShowDialog() == false) room.RemoveAnimal(accU);
            }
            else
            {
                AccUnit prevAnimal = room.Animals[selectedIndex];
                DateTime dateOfArrival = room.Animals[selectedIndex].DateOfArrival;

                room.UpdateAnimal(selectedIndex, new AccUnit(new Animal(_animalName, _country, _ownName, _bornDate), dateOfArrival, _maintCost));
                if (sac.ShowDialog() == false) room.UpdateAnimal(selectedIndex, prevAnimal);
            }
            this.Close();
        }
    }
}
