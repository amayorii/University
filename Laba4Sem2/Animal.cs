namespace Laba4Sem2
{
    class Animal
    {
        private string animalName;
        private string country;
        private string ownName;
        private DateTime born;

        public Animal(string animalName, string country, string ownName, DateTime born)
        {
            this.animalName = animalName;
            this.country = country;
            this.ownName = ownName;
            this.born = born;
        }

        public override string ToString()
        {
            return $"Animal type: {animalName}\nCountry: {country}\nName: {ownName}\nBorn: {born}";
        }
    }
}
