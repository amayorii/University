using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Laba4Sem2.Model
{
    public class Room : INotifyPropertyChanged
    {
        private RoomType roomType;
        private int roomId, size, cleaningCost;
        private List<AccUnit> animals = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        public int RoomId
        {
            get => roomId;
            set
            {
                if (value < 0)
                {
                    throw new Exception("what?");
                }
                else
                {
                    roomId = value;
                    OnPropertyChanged(nameof(RoomId));
                }
            }
        }

        [Range(2, int.MaxValue, ErrorMessage = "Room size must be at least 2x2 m.")]
        public int Size
        {
            get => size;
            set
            {
                if (value < 2)
                {
                    throw new Exception("Room size must be at least 2x2 m.");
                }
                else
                {
                    size = value;
                    OnPropertyChanged(nameof(Size));
                }
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "Cleaning cost cannot be negative.")]
        public int CleaningCost
        {
            get => cleaningCost;
            set
            {
                if (value < 0) throw new Exception("Cleaning cost cannot be negative.");
                else
                {
                    cleaningCost = value;
                    OnPropertyChanged(nameof(CleaningCost));
                }
            }
        }

        public RoomType RoomType
        {
            get => roomType;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("You need to choose room type!");
                }
                else
                {
                    roomType = value;
                    OnPropertyChanged(nameof(RoomType));
                }
            }
        }

        public string ShortString => ToShortString();

        [JsonInclude]
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
        public Room()
        {
            RoomType = RoomType.Cage;
            RoomId = 0;
            Size = 20;
            CleaningCost = 10;
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
        public void RemoveAnimal(AccUnit accUnit)
        {
            var newList = new List<AccUnit>(Animals);
            newList.Remove(accUnit);
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
