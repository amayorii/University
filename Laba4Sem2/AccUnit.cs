
namespace Laba4Sem2
{
    class AccUnit
    {
        private Animal animal;
        private DateTime dateOfArrival;
        private int maintenanceCost;



        public AccUnit(Animal animal, DateTime dateOfArrival, int maintenanceCost)
        {
            this.animal = animal;
            this.dateOfArrival = dateOfArrival;
            this.MaintenanceCost = maintenanceCost;
        }

        public int MaintenanceCost
        {
            get => maintenanceCost;
            set
            {
                if (value > 0)
                {
                    this.maintenanceCost = value;
                }
                else maintenanceCost = 0;
            }
        }

        public override string ToString()
        {

            return $"{animal}\nDate of arrival: {dateOfArrival}\nMaintenance cost: {MaintenanceCost}\n";
        }
    }
}
