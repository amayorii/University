using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Laba4Sem2.Model
{
    public class Room : INotifyPropertyChanged
    {
        private RoomType roomType;
        private int roomId, size, cleaningCost;
        private List<AccUnit> animals = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        [Range(0, int.MaxValue)]
        public int RoomId { get => roomId; set => roomId = value; }

        [Range(2, int.MaxValue)]
        public int Size { get => size; set => size = value; }

        [Range(0, int.MaxValue)]
        public int CleaningCost { get => cleaningCost; set => cleaningCost = value; }

        public RoomType RoomType { get => roomType; private set => roomType = value; }

        public string ShortString => ToShortString();

        public List<AccUnit> Animals
        {
            get => animals;
            private set
            {
                animals = value;
                OnPropertyChanged(nameof(Animals));
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShortString)));
        }

        public Room(RoomType roomType, int roomId, int size, int cleaningCost)
        {
            RoomType = roomType;
            RoomId = roomId;
            Size = size;
            CleaningCost = cleaningCost;
        }

        public Room(RoomType roomType, int roomId, int size, int cleaningCost, List<AccUnit> animals)
        {
            RoomType = roomType;
            this.RoomId = roomId;
            this.Size = size;
            this.CleaningCost = cleaningCost;
            this.Animals = animals;
        }

        public void AddAnimal(AccUnit accUnit)
        {
            var newList = new List<AccUnit>(Animals) { accUnit };
            Animals = newList;
        }

        public void UpdateAnimal(int index, AccUnit updatedAccUnit)
        {
            animals[index] = updatedAccUnit;
            OnPropertyChanged(nameof(Animals));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (AccUnit accUnit in Animals)
            {
                sb.Append(accUnit + "\n");
            }
            return $"Room type: {RoomType}\nId: {RoomId}\nSize: {Size}\nCleaning cost: {CleaningCost}\nList of residents:\n\n{sb.ToString()}";
        }

        public string ToShortString()
        {
            int sum = 0;
            foreach (AccUnit accUnit in Animals)
            {
                sum += accUnit.MaintenanceCost;
            }
            return $"Amount of animals: {Animals.Count}\nMaintenance cost for room: {sum}";
        }

    }
}
