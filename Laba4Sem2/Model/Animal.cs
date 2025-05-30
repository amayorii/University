﻿using System.ComponentModel;

namespace Laba4Sem2.Model
{
    public class Animal : INotifyPropertyChanged
    {
        private string animalName;
        private string country;
        private string ownName;
        private DateTime born;

        public Animal()
        {
            this.AnimalName = "Dog";
            this.Country = "Kaniv";
            this.OwnName = "Maksim";
            this.Born = new DateTime(2001, 09, 11);
        }
        public Animal(string animalName, string country, string ownName, DateTime born)
        {
            this.AnimalName = animalName;
            this.Country = country;
            this.OwnName = ownName;
            this.Born = born;
        }

        public string AnimalName
        {
            get => animalName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Animal must have a name!");
                }
                else if (!value.Any(x => char.IsLetterOrDigit(x)))
                {
                    throw new Exception("Animal name must contain only letters or digits");
                }
                else
                {
                    animalName = value;
                    OnPropertyChanged(nameof(AnimalName));
                }
            }
        }
        public string Country
        {
            get => country;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Country cannot be empty.");
                }
                else
                {
                    country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }
        public string OwnName
        {
            get => ownName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Own name cannot be empty.");
                }
                else
                {
                    ownName = value;
                    OnPropertyChanged(nameof(OwnName));
                }
            }
        }
        public DateTime Born
        {
            get => born;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("You need to choose a date");
                }
                else
                {
                    born = value;
                    OnPropertyChanged(nameof(Born));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToString)));
        }

        public override string ToString()
        {
            return $"Animal type: {AnimalName}\nName: {OwnName}\nCountry: {Country}\nBorn: {Born.ToShortDateString()}";
        }
    }
}
