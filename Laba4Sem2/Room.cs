using System.Text;

namespace Laba4Sem2
{
    class Room
    {
        private RoomType roomType;
        private int roomId, size, cleaningCost;
        private List<AccUnit> animals = [];

        public Room(RoomType roomType, int roomId, int size, int cleaningCost)
        {
            this.roomType = roomType;
            this.roomId = roomId;
            this.size = size;
            this.cleaningCost = cleaningCost;
        }

        public Room(RoomType roomType, int roomId, int size, int cleaningCost, List<AccUnit> animals)
        {
            this.roomType = roomType;
            this.roomId = roomId;
            this.size = size;
            this.cleaningCost = cleaningCost;
            this.animals = animals;
        }

        public void AddAnimal(AccUnit accUnit)
        {
            animals.Add(accUnit);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (AccUnit accUnit in animals)
            {
                sb.Append(accUnit + "\n");
            }
            return $"Room type: {roomType}\nId: {roomId}\nSize: {size}\nCleaning cost: {cleaningCost}\nList of residents:\n\n{sb.ToString()}";
        }

        public string ToShortString()
        {
            int sum = 0;
            foreach (AccUnit accUnit in animals)
            {
                sum += accUnit.MaintenanceCost;
            }
            return $"Room id: {roomId}\nMaintenance cost for room: {sum}";
        }

    }
}
