using System.ComponentModel.DataAnnotations;

namespace Laba4Sem2.Model
{
    class AccUnit
    {
        private Animal animal;
        private DateTime dateOfArrival;
        private int maintenanceCost;

        public AccUnit(Animal animal, DateTime dateOfArrival, int maintenanceCost)
        {
            this.Animal = animal;
            this.DateOfArrival = dateOfArrival;
            MaintenanceCost = maintenanceCost;
        }

        [Range(0, int.MaxValue, ErrorMessage = "Maintenance cost must be greater than 0.")]
        public int MaintenanceCost
        {
            get => maintenanceCost;
            set => maintenanceCost = value;
        }
        public DateTime DateOfArrival { get => dateOfArrival; set => dateOfArrival = value; }
        public Animal Animal { get => animal; set => animal = value; }

        public override string ToString()
        {

            return $"{Animal}\nDate of arrival: {DateOfArrival}\nMaintenance cost: {MaintenanceCost}\n";
        }
    }
}
