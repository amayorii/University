namespace Laba4Sem2.Model
{
    public class Animal
    {
        private string animalName;
        private string country;
        private string ownName;
        private DateTime born;

        public Animal(string animalName, string country, string ownName, DateTime born)
        {
            this.AnimalName = animalName;
            this.Country = country;
            this.OwnName = ownName;
            this.Born = born;
        }

        public string AnimalName { get => animalName; set => animalName = value; }
        public string Country { get => country; set => country = value; }
        public string OwnName { get => ownName; set => ownName = value; }
        public DateTime Born { get => born; set => born = value; }

        public override string ToString()
        {
            return $"Animal type: {AnimalName}\nCountry: {Country}\nName: {OwnName}\nBorn: {Born}";
        }
    }
}
