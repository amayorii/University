using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Laba4Sem2.Model
{
    public class AccUnit : INotifyPropertyChanged
    {
        private Animal animal;
        private DateTime dateOfArrival;
        private int maintenanceCost;

        public event PropertyChangedEventHandler? PropertyChanged;

        public AccUnit(Animal animal, DateTime dateOfArrival, int maintenanceCost)
        {
            Animal = animal;
            DateOfArrival = dateOfArrival;
            MaintenanceCost = maintenanceCost;
        }

        [Range(0, int.MaxValue, ErrorMessage = "Maintenance cost must be greater than 0.")]
        public int MaintenanceCost
        {
            get => maintenanceCost;
            set
            {
                maintenanceCost = value;
                OnPropertyChanged(nameof(MaintenanceCost));
            }
        }
        public DateTime DateOfArrival
        {
            get => dateOfArrival;
            set
            {
                dateOfArrival = value;
                OnPropertyChanged(nameof(DateOfArrival));
            }
        }
        public Animal Animal
        {
            get => animal;
            set
            {
                animal = value;
                OnPropertyChanged(nameof(Animal));
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return $"{Animal}\nDate of arrival: {DateOfArrival}\nMaintenance cost: {MaintenanceCost}\n";
        }
    }
}
